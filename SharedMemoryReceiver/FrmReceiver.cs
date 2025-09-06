using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using dSize = System.Drawing.Size;

namespace SharedMemoryReceiver
{
    public partial class FrmReceiver : Form
    {
        private const string MmfName = "SharedMemoryTest";
        private const string EventName = "SharedMemoryTest_ImageReady";
        private const int HeaderIntCount = 5;
        private static readonly int HeaderSize = sizeof(int) * HeaderIntCount;

        private MemoryMappedFile _mmf;
        private EventWaitHandle _imgEvent;
        private volatile bool _running;
        private volatile bool _oneShot;

        private Mat _currentMat;
        private readonly object _matLock = new object();

        private double dpiX;
        private double dpiY;

        public FrmReceiver()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_running) return;
            try
            {
                if (_mmf == null)
                    _mmf = MemoryMappedFile.OpenExisting(MmfName, MemoryMappedFileRights.Read);
                if (_imgEvent == null)
                    _imgEvent = EventWaitHandle.OpenExisting(EventName);

                _oneShot = chkOneShot.Checked;
                _running = true;

                btnStart.Enabled = false;
                btnStop.Enabled = !_oneShot;      // In one-shot mode stop is not needed
                chkOneShot.Enabled = false;

                if (pictureBox1.Image != null)
                {
                slblStatus.Size = new dSize(
                    (int)(130 * dpiX / 96),
                    (int)(19 * dpiY / 96)
                    );
                SetStatus(_oneShot ? "Waiting (one shot)" : "Waiting for images...");
                }
                else
                {
                    slblStatus.Size = new dSize(
                        (int)(630 * dpiX / 96),
                        (int)(19 * dpiY / 96)
                        );
                    SetStatus(_oneShot ? "Waiting (one shot)" : "Waiting for images...");
                }

                Task.Run(ReceiveLoop);
            }
            catch (Exception ex)
            {
                slblStatus.Size = new dSize(
                    (int)(630 * dpiX / 96),
                    (int)(19 * dpiY / 96)                    
                    );

                SetStatus("Start failed: " + ex.Message);
                _running = false;
                _oneShot = false;
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                chkOneShot.Enabled = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopRunning("Stopped");
        }

        private void StopRunning(string status)
        {
            _running = false;
            _oneShot = false;
            BeginInvoke((Action)(() =>
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                chkOneShot.Enabled = true;

                slblStatus.Size = new dSize(
                    (int)(130 * dpiX / 96),
                    (int)(19 * dpiY / 96)
                    );

                SetStatus(status);
            }));
        }

        // (Legacy) No longer used; one-shot now handled by chkOneShot + Start button.
        private void btnOneShot_Click(object sender, EventArgs e)
        {
            // Intentionally left for reference; not wired in designer.
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Mat copy;
            lock (_matLock)
            {
                if (_currentMat == null)
                    return;
                copy = _currentMat.Clone();
            }
            using (var sfd = new SaveFileDialog
            {
                Filter = "PNG (*.png)|*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|BMP (*.bmp)|*.bmp|TIFF (*.tif;*.tiff)|*.tif;*.tiff",
                FileName = "received.png"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        slblStatus.Size = new dSize(
                            (int)(630 * dpiX / 96),
                            (int)(19 * dpiY / 96)
                            );
                        copy.SaveImage(sfd.FileName);
                        SetStatus("Saved: " + sfd.FileName);
                    }
                    catch (Exception ex)
                    {
                        slblStatus.Size = new dSize(
                            (int)(630 * dpiX / 96),
                            (int)(19 * dpiY / 96)
                            );
                        SetStatus("Save failed: " + ex.Message);
                    }
                }
            }
            copy.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lock (_matLock)
            {
                _currentMat?.Dispose();
                _currentMat = null;
            }
            pictureBox1.Image = null;
            btnSave.Enabled = false;

            slblStatus.Size = new dSize(
                (int)(630 * dpiX / 96),
                (int)(19 * dpiY / 96)
                );
            SetStatus("Cleared");
        }

        private void ReceiveLoop()
        {
            bool localOneShot = _oneShot;
            while (_running)
            {
                try
                {
                    if (!_imgEvent.WaitOne(500))
                        continue;
                    if (!_running) break;

                    slblStatus.Size = new dSize(
                        (int)(130 * dpiX / 96),
                        (int)(19 * dpiY / 96)
                        );

                    ReadImage();

                    if (localOneShot)
                    {
                        // After first successful image in one-shot mode, stop.
                        StopRunning("One shot received");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    slblStatus.Size = new dSize(
                        (int)(630 * dpiX / 96),
                        (int)(19 * dpiY / 96)
                        );
                    SetStatus("Error: " + ex.Message);
                    Thread.Sleep(1000);
                }
            }
        }

        private void ReadImage()
        {
            if (_mmf == null) return;

            using (var accessor = _mmf.CreateViewAccessor(0, 0, MemoryMappedFileAccess.Read))
            {
                int[] header = new int[HeaderIntCount];
                accessor.ReadArray(0, header, 0, HeaderIntCount);

                int type = header[0];
                int step = header[1];
                int width = header[2];
                int height = header[3];
                int dataSize = header[4];

                if (width <= 0 || height <= 0 || dataSize <= 0 || dataSize > 90 * 1024 * 1024)
                {
                    slblStatus.Size = new dSize(
                        (int)(630 * dpiX / 96),
                        (int)(19 * dpiY / 96)
                        );
                    
                    SetStatus("Invalid header");
                    return;
                }

                byte[] buffer = new byte[dataSize];
                accessor.ReadArray(HeaderSize, buffer, 0, dataSize);

                Mat mat = new Mat(height, width, (MatType)type);
                Marshal.Copy(buffer, 0, mat.Data, dataSize);

                lock (_matLock)
                {
                    _currentMat?.Dispose();
                    _currentMat = mat;
                }

                BeginInvoke((Action)(() =>
                {
                    try
                    {
                        pictureBox1.Image?.Dispose();
                        pictureBox1.Image = mat.ToBitmap();
                        btnSave.Enabled = true;
                        slblHeight.Text = height.ToString();
                        slblWidth.Text = width.ToString();  
                        slblType.Text = type.ToString();
                        slblKBStep.Text = step.ToString();
                        slblSize.Text = (dataSize / 1024).ToString() + " KB";
                    }
                    catch (Exception ex)
                    {
                        slblStatus.Size = new dSize(
                            (int)(630 * dpiX / 96),
                            (int)(19 * dpiY / 96)
                            );

                        SetStatus("Display failed : " + ex.Message);
                    }
                }));
            }
        }

        private void SetStatus(string text)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => slblStatus.Text = text));
            }
            else
            {
                slblStatus.Text = text;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _running = false;
            _imgEvent?.Dispose();
            _mmf?.Dispose();
            lock (_matLock)
            {
                _currentMat?.Dispose();
                _currentMat = null;
            }
        }

        private void FrmReceiver_Load(object sender, EventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                dpiX = g.DpiX;
                dpiY = g.DpiY;
            }

            slblStatus.Size = new dSize(
                (int)(630 * dpiX / 96),
                (int)(19 * dpiY / 96)
            );
        }

        private void FrmReceiver_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                dpiX = g.DpiX;
                dpiY = g.DpiY;
            }
        }

        private void FrmReceiver_DpiChangedAfterParent(object sender, EventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                dpiX = g.DpiX;
                dpiY = g.DpiY;
            }
        }

        private void FrmReceiver_DpiChangedBeforeParent(object sender, EventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                dpiX = g.DpiX;
                dpiY = g.DpiY;
            }
        }
    }
}