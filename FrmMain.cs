using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using Size = OpenCvSharp.Size;

namespace VideoSuperResolution {
    public partial class FrmMain : Form {
        public FrmMain() {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e) {

        }

        private async void BtnFile_ClickAsync(object sender, EventArgs e) {
            OpenFileDialog fileDialog = new OpenFileDialog {
                Multiselect = false,
                Title = "Please choose a video file:",
                Filter = "Video File (*.mp4)|*.mp4"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK) {
                BtnFile.Enabled = false;
                string file = fileDialog.FileName;
                // string path = Path.GetDirectoryName(file);
                // string filename = Path.GetFileName(file);
                // string subdir = filename.Substring(0, 5).ToLower();
                // string dir = Path.Combine(path, subdir);
                // if (Directory.Exists(dir)) {
                //     Directory.Delete(dir, true);
                // }
                // Directory.CreateDirectory(dir);

                int index = 0;
                var video_in = VideoCapture.FromFile(file);
                FourCC fourCC = FourCC.DIVX;
                double fps = video_in.Fps;
                Size dsize = new Size(video_in.FrameWidth * 2, video_in.FrameHeight * 2);
                VideoWriter video_out = new VideoWriter("output.mp4", fourCC, fps, dsize, true);
                var max = video_in.FrameCount;
                progressBar1.Maximum = max;
                while (video_in.IsOpened()) {
                    Mat frame_in = new Mat();
                    var status = video_in.Read(frame_in);
                    if (!status) {
                        break;
                    }
                    var frame_out = await Task.Run(() => ExtractFrame(frame_in));
                    video_out.Write(frame_out);
                    MemoryStream ms_in = new MemoryStream(frame_in.ToBytes());
                    var image_in = Image.FromStream(ms_in);
                    PicVidIn.Image = image_in;
                    MemoryStream ms_out = new MemoryStream(frame_out.ToBytes());
                    Image image_out = Image.FromStream(ms_out); 
                    PicVidOut.Image = image_out;
                    var percentage = Math.Round((float)index / max * 100, 2);
                    label2.Text = index + "/" + max + " - " + percentage + "%";
                    progressBar1.Value++;
                    index++;
                }
                video_in.Release();
                video_out.Release();
                BtnFile.Enabled = true;
            }
        }

        private Mat ExtractFrame(Mat frame_in) {
            Size dsize = new Size(frame_in.Width * 2, frame_in.Height * 2);
            double fx = 0, fy = 0;
            InterpolationFlags interpolation = InterpolationFlags.Lanczos4;
            Mat frame_out = frame_in.Resize(dsize, fx, fy, interpolation);
            // MemoryStream ms = new MemoryStream(frame_out.ToBytes());
            // Image image = System.Drawing.Image.FromStream(ms);
            // image.Save(Path.Combine(dir, string.Format("{0:d10}", index) + ".png"));
            return frame_out;
        }
    }
}
