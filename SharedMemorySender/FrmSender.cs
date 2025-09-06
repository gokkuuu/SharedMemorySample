using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using dSize = System.Drawing.Size;

namespace SharedMemoryTest
{
    public partial class FrmSender : Form
    {
        private const string MmfName = "SharedMemoryTest";
        private const string EventName = "SharedMemoryTest_ImageReady";
        private const long SharedMemorySize = 100L * 1024 * 1024; // 100 MB
        private const int HeaderIntCount = 5;
        private const int HeaderSize = sizeof(int) * HeaderIntCount;

        private MemoryMappedFile _mmf;
        private EventWaitHandle _imgReadyEvent;

        private double dpiX;
        private double dpiY;

        public FrmSender()
        {
            InitializeComponent();

            // CreateOrOpen so receiver can start first safely.
            _mmf = MemoryMappedFile.CreateOrOpen(MmfName, SharedMemorySize, MemoryMappedFileAccess.ReadWrite);
            _imgReadyEvent = new EventWaitHandle(false, EventResetMode.AutoReset, EventName);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image files (*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.tif;*.bmp)|*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.tif;*.bmp";
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                Mat mat = new Mat(ofd.FileName, ImreadModes.Unchanged);
                int dataSize = (int)(mat.Total() * mat.ElemSize());
                int type = mat.Type();
                int step = (int)mat.Step();
                int width = mat.Cols;
                int height = mat.Rows;

                pictureBox1.Image = mat.ToBitmap();

                if (HeaderSize + dataSize > SharedMemorySize)
                {
                    slblStatus.Size = new dSize(
                        (int)(630 * dpiX / 96),
                        (int)(19 * dpiY / 96)
                        );
                    slblStatus.Text = "Image too large for shared memory.";
                    mat.Dispose();
                    return;
                }

                int[] header = { type, step, width, height, dataSize };

                byte[] pixelBytes = new byte[dataSize];
                Marshal.Copy(mat.Data, pixelBytes, 0, dataSize);

                using (var accessor = _mmf.CreateViewAccessor(0, HeaderSize + dataSize, MemoryMappedFileAccess.Write))
                {
                    accessor.WriteArray(0, header, 0, HeaderIntCount);
                    accessor.WriteArray(HeaderSize, pixelBytes, 0, dataSize);
                    accessor.Flush();
                }

                _imgReadyEvent.Set();

                // Update status label with image info

                slblStatus.Size = new dSize(
                    (int)(130 * dpiX / 96),
                    (int)(19 * dpiY / 96)
                    );
                // slblStatus.Text = "Loaded : " + Path.GetFileName(ofd.FileName);
                slblStatus.Text = "Image loaded";
                slblHeight.Text = height.ToString();
                slblWidth.Text = width.ToString();
                slblType.Text = type.ToString();
                slblKBStep.Text = step.ToString();
                slblSize.Text = (dataSize / 1024).ToString();
                mat.Dispose();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            // Simple local read-back test (not another process)
            using (var accessor = _mmf.CreateViewAccessor(0, 0, MemoryMappedFileAccess.Read))
            {
                int[] header = new int[HeaderIntCount];
                accessor.ReadArray(0, header, 0, HeaderIntCount);

                int type = header[0];
                int step = header[1];
                int width = header[2];
                int height = header[3];
                int dataSize = header[4];

                if (dataSize <= 0 || dataSize > (SharedMemorySize - HeaderSize))
                {
                    slblStatus.Size = new dSize(
                        (int)(630 * dpiX / 96),
                        (int)(19 * dpiY / 96)
                        );

                    slblStatus.Text = "Invalid data size.";
                    return;
                }

                byte[] buffer = new byte[dataSize];
                accessor.ReadArray(HeaderSize, buffer, 0, dataSize);

                Mat mat = new Mat(height, width, (OpenCvSharp.MatType)type);
                Marshal.Copy(buffer, 0, mat.Data, dataSize);
                pictureBox1.Image = mat.ToBitmap();
                mat.Dispose();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _imgReadyEvent?.Dispose();
            _mmf?.Dispose();
            base.OnFormClosed(e);
        }

        private void FrmSender_Load(object sender, EventArgs e)
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
    }
}