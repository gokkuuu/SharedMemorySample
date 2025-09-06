# SharedMemorySample
Two WinForms applications that exchange an image across processes using a named MemoryMappedFile and a named AutoReset event. Image data is handled with OpenCvSharp and displayed in PictureBox controls.

- .NET target: .NET Framework 4.8
- Language: C# 7.3
- UI: Windows Forms (WinForms)
- Libraries: OpenCvSharp, OpenCvSharp.Extensions

Projects:
- SharedMemorySender (namespace: SharedMemoryTest)
- SharedMemoryReceiver (namespace: SharedMemoryReceiver)

## How it works
The sender loads an image into an OpenCvSharp `Mat`, writes a small header followed by the raw pixel bytes to a named memory-mapped file, then signals a named event. The receiver waits on the event, reads the header and data from the same memory, reconstructs the `Mat`, and displays it.

Named objects (must match exactly in both apps):
- Memory-mapped file name: `SharedMemoryTest`
- Event name: `SharedMemoryTest_ImageReady`

Shared memory layout (byte offsets):
- Header (5 x 32-bit integers, 20 bytes total)
  1. type    (int) OpenCV Mat type (e.g., CV_8UC3), written as `mat.Type()`
  2. step    (int) stride in bytes per row, written as `(int)mat.Step()`
  3. width   (int) `mat.Cols`
  4. height  (int) `mat.Rows`
  5. dataSize(int) total raw byte size = `mat.Total() * mat.ElemSize()`
- Pixel data (`dataSize` bytes): raw copy of `mat.Data`

Memory limits:
- Sender allocates 100 MB for the shared memory.
- Sender rejects images if `HeaderSize + dataSize > 100 MB`.
- Receiver rejects payloads if width <= 0, height <= 0, dataSize <= 0, or dataSize > 90 MB.

Note: Data is uncompressed raw bytes; the receiver constructs the Mat with `new Mat(height, width, (MatType)type)` and copies the bytes into it.

## Requirements
- Windows with .NET Framework 4.8
- Visual Studio 2022
- NuGet packages:
  - OpenCvSharp
  - OpenCvSharp.Extensions

## Build
1. Open the solution in Visual Studio 2022.
2. Restore NuGet packages (e.g., from Solution Explorer or the __Manage NuGet Packages__ UI).
3. Build the solution (__Build__).

Both projects are WinForms apps targeting .NET Framework 4.8.

## Run
You need both apps running to see inter-process image transfer.

Order considerations:
- Sender creates or opens the shared memory and event on startup.
- Receiver opens existing objects only when you click Start. If the sender has not created them yet, Start will fail with “Start failed: ...”.
- Practical guidance: Start the sender first, or start the receiver but click Start only after the sender has launched.

### SharedMemorySender (FrmSender)

Controls:
- Load image (btnLoad)
- Show image (btnShow)
- PictureBox (630 x 420, StretchImage)
- StatusStrip (RoyalBlue) with labels:
  - Status, Width, Height, Type, Size, KB Step

Behavior:
- Load image:
  - Opens a file dialog filtered to: `*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.tif;*.bmp`
  - Loads the file with `ImreadModes.Unchanged` into `Mat`.
  - Calculates header values:
    - `type = mat.Type()`
    - `step = (int)mat.Step()`
    - `width = mat.Cols`
    - `height = mat.Rows`
    - `dataSize = (int)(mat.Total() * mat.ElemSize())`
  - Writes header + data to the memory-mapped file (offset 0 for header, then pixels).
  - Flushes the accessor and signals the event.
  - Updates UI:
    - Displays the loaded image in the sender’s PictureBox.
    - Status text set to “Image loaded”.
    - Width/Height/Type/KB Step shown from header.
    - Size label shows `dataSize / 1024` (numeric value, no “KB” suffix).
  - If the image does not fit: sets Status to “Image too large for shared memory.” and aborts.

- Show image:
  - Reads back the current header and data from the same shared memory (local verification).
  - Reconstructs a `Mat` from the memory and displays it locally.
- Form close: disposes the event and memory-mapped file.

DPI handling:
- On Load, measures current DPI and sets the Status label width to a DPI-scaled value (approx. 630 px at 100% scaling).

### SharedMemoryReceiver (FrmReceiver)
Controls:
- Start (btnStart)
- Stop (btnStop)
- Save Image (btnSave)
- Clear (btnClear)
- Oneshot Mode (chkOneShot)
- PictureBox (630 x 420, StretchImage)
- StatusStrip (green) with labels:
  - Status, Width, Height, Type, Size, KB Step

Behavior:
- Start:
  - Opens existing memory-mapped file for read and existing event.
  - Sets “one-shot” mode based on checkbox.
  - Disables Start and checkbox; Stop is disabled in one-shot mode and enabled otherwise.
  - Status label width is set to a small or large size depending on whether an image is already displayed, then text set to “Waiting (one shot)” or “Waiting for images...”.
  - Starts a background receive loop.

- Receive loop:
  - Waits up to 500 ms for the event. On signal, reads the header and data.
  - Validates header and data size (width, height, 0 < dataSize ≤ 90 MB).
  - Constructs a `Mat`, copies bytes, replaces the current Mat under a lock.
  - On UI thread:
    - Converts to `Bitmap` and displays in PictureBox.
    - Enables Save.
    - Updates Width/Height/Type/KB Step/Size (Size shows `<KB> KB` with unit).
  - In one-shot mode, stops after the first image and sets Status to “One shot received”.

- Stop:
  - Stops receiving; re-enables Start and checkbox; sets Status to “Stopped”.

- Save Image:
  - Clones the current Mat under a lock and opens a SaveFileDialog:
    - Filter: PNG/JPEG/BMP/TIFF
    - Default filename: `received.png`
  - Saves with `Mat.SaveImage()`. On success, Status set to “Saved: <path>”. On failure, Status set to “Save failed: <message>”.

- Clear:
  - Disposes current Mat and clears the PictureBox.
  - Disables Save.
  - Status set to “Cleared”.

- Error handling:
  - Any read/display errors set Status accordingly (e.g., “Invalid header”, “Error: ...”, “Display failed : ...”).

DPI handling:
- On Load and on DPI change (DpiChanged, DpiChangedBeforeParent, DpiChangedAfterParent), measures current DPI and updates internal DPI values.
- The Status label width is toggled between two DPI-scaled widths (approx. 130 px for compact and 630 px for expanded) depending on context.

Cleanup:
- The receiver defines a `Form1_FormClosed` method that stops the loop and disposes resources (event, memory, Mat). The DPI change events are wired; the FormClosed handler is defined in code but is not wired in the designer.

## Protocol details (exact values from code)
Constants:
- Memory-mapped file name: `SharedMemoryTest`
- Event name: `SharedMemoryTest_ImageReady`
- Sender shared memory size: `100 * 1024 * 1024` bytes
- HeaderIntCount: `5`
- HeaderSize: `sizeof(int) * 5` (20 bytes)

Sender writes:
- Header: `{ type, step, width, height, dataSize }`
- Data: `byte[dataSize]` copied from `mat.Data`

Receiver reconstructs:
- `new Mat(height, width, (MatType)type)`
- `Marshal.Copy(buffer, 0, mat.Data, dataSize)`

Field meanings as displayed in the UI:
- Type: raw OpenCV Mat type integer (`Mat.Type()`)
- KB Step: row stride in bytes (`(int)mat.Step()`)
- Size: in KB; receiver shows with “ KB” suffix; sender shows number only
- Width/Height: in pixels

## Notes and limitations
- Single payload buffer; each new image overwrites the previous content.
- No versioning; both processes must agree on the header format.
- The receiver ignores `step` for reconstruction and assumes the provided buffer fits `height * width * elemSize`.
- The event is AutoReset; one waiting receiver is released per signal.
- The receiver enforces a stricter dataSize upper bound (90 MB) than the sender’s allocation (100 MB).

## UI reference
SharedMemorySender:
- Buttons: Load image, Show image
- PictureBox: shows the loaded or read-back image
- Status: “Image loaded”, errors like “Image too large for shared memory.”
- Status strip color: RoyalBlue

SharedMemoryReceiver:
- Buttons: Start, Stop, Save Image, Clear
- Checkbox: Oneshot Mode
- PictureBox: shows the received image
- Status: “Waiting for images...”, “Waiting (one shot)”, “One shot received”, “Stopped”, “Cleared”, failures as described
- Status strip color: green
