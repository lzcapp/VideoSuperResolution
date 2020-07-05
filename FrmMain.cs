using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using OpenCvSharp;
using Size = OpenCvSharp.Size;
using Timer = System.Timers.Timer;

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
            if (fileDialog.ShowDialog() != DialogResult.OK) {
                return;
            }

            BtnFile.Enabled = false;
            string file = fileDialog.FileName;
            string path = Path.GetDirectoryName(file);
            string temppath = Path.GetTempPath();
            string filename = Path.GetFileName(file);
            string audio = Path.Combine(temppath, "output.mp3");
            string opencv_out = Path.Combine(temppath, "output.mp4");
            string file_output = Path.Combine(path, "[superresolution]" + filename);
            string ffmpegPath = ConfigurationManager.AppSettings["ffmpeg"];

            int index = 1;

            var video_in = VideoCapture.FromFile(file);

            var ffmpeg_extract = new Process();
            ffmpeg_extract.StartInfo.UseShellExecute = false;
            ffmpeg_extract.StartInfo.RedirectStandardInput = true;
            ffmpeg_extract.StartInfo.RedirectStandardOutput = true;
            ffmpeg_extract.StartInfo.RedirectStandardError = true;
            ffmpeg_extract.StartInfo.CreateNoWindow = true;
            ffmpeg_extract.StartInfo.FileName = ffmpegPath;
            ffmpeg_extract.StartInfo.Arguments = " -i " + file + " -vn -f mp3 " + audio + " -y";
            ffmpeg_extract.Start();
            ffmpeg_extract.WaitForExit();
            if (!ffmpeg_extract.HasExited) {
                ffmpeg_extract.Kill();
            }

            FourCC fourCC = FourCC.DIVX;
            double fps = video_in.Fps;
            Size dsize = new Size(video_in.FrameWidth * 2, video_in.FrameHeight * 2);
            VideoWriter video_out = new VideoWriter(opencv_out, fourCC, fps, dsize, true);
            var max = video_in.FrameCount;

            progressBar1.Value = 0;
            progressBar1.Maximum = max;

            TimeSpan interval_start = new TimeSpan(System.DateTime.Now.Ticks);

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

                TimeSpan interval_now = new TimeSpan(System.DateTime.Now.Ticks);
                TimeSpan countTime = interval_start.Subtract(interval_now).Duration();
                int second = (int)(countTime.TotalSeconds / ((float)index / max));
                int hour = second / 3600;
                second %= 3600;
                int minute = second / 60;
                second %= 60;
                label2.Text = index + "/" + max + " Frames  -  " + percentage + "%    Approximately " + hour + "H" + minute + "M" + second + "S Left";
                progressBar1.Value++;
                index++;
            }
            video_in.Release();
            video_out.Release();

            var ffmpeg_add = new Process();
            ffmpeg_add.StartInfo.UseShellExecute = false;
            ffmpeg_add.StartInfo.RedirectStandardInput = true;
            ffmpeg_add.StartInfo.RedirectStandardOutput = true;
            ffmpeg_add.StartInfo.RedirectStandardError = true;
            ffmpeg_add.StartInfo.CreateNoWindow = true;
            ffmpeg_add.StartInfo.FileName = ffmpegPath;
            ffmpeg_add.StartInfo.Arguments = " -i " + opencv_out + " -i " + audio + " -c copy " + file_output;
            ffmpeg_add.Start();
            ffmpeg_add.WaitForExit();
            if (!ffmpeg_add.HasExited) {
                ffmpeg_add.Kill();
            }

            File.Delete(opencv_out);
            File.Delete(audio);

            MessageBox.Show("Video file \"output_" + filename + "\" saved.", "Task Finished");
            BtnFile.Enabled = true;
        }

        private Mat ExtractFrame(Mat frame_in) {
            Size dsize = new Size(frame_in.Width * 2, frame_in.Height * 2);
            double fx = 0, fy = 0;
            InterpolationFlags interpolation = InterpolationFlags.Lanczos4;
            // InterpolationFlags interpolation = InterpolationFlags.Cubic;
            Mat frame_out = frame_in.Resize(dsize, fx, fy, interpolation);
            // MemoryStream ms = new MemoryStream(frame_out.ToBytes());
            // Image image = System.Drawing.Image.FromStream(ms);
            // image.Save(Path.Combine(dir, string.Format("{0:d10}", index) + ".png"));
            return frame_out;
        }
    }
}
