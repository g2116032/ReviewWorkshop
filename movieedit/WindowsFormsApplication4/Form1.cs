using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{

    public partial class Form1 : Form
    {
        int flag = 1;
        string FilePath;
        string FolderPath;
        string movie1, movie2, movie3;

        int smile_flag = 1;
        int hand_flag = 1;
        int flag3 = 0;


        public Form1()
        {
            InitializeComponent();
        }

        

        private static void WriteCsv(int second, int select, string place)
        {
            try
            {
                // appendをtrueにすると，既存のファイルに追記
                //         falseにすると，ファイルを新規作成する
                var append = true;
                // 出力用のファイルを開く
                using (var sw = new System.IO.StreamWriter(place + "\\test.csv", append))
                {
                    if (select == 1)
                    {
                        sw.WriteLine("{0}, {1}, {2},", second, " ", " ");
                    }
                    else if (select == 2)
                    {
                        sw.WriteLine("{0}, {1}, {2},", "", second, "");
                    }
                    else if (select == 3)
                    {
                        sw.WriteLine("{0}, {1}, {2},", "", "", second);
                    }
                }
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したときエラーメッセージを表示
                System.Console.WriteLine(e.Message);
            }
        }

        Image createThumbnail(Image image, int w, int h)
        {
            Bitmap canvas = new Bitmap(w, h);

            Graphics g = Graphics.FromImage(canvas);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, w, h);

            float fw = (float)w / (float)image.Width;
            float fh = (float)h / (float)image.Height;

            float scale = Math.Min(fw, fh);
            fw = image.Width * scale;
            fh = image.Height * scale;

            g.DrawImage(image, (w - fw) / 2, (h - fh) / 2, fw, fh);
            g.Dispose();

            return canvas;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Multiview Video Editor";
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox14.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox15.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox16.SizeMode = PictureBoxSizeMode.StretchImage;

            axWindowsMediaPlayer2.uiMode = "none";
            axWindowsMediaPlayer3.uiMode = "none";
            axWindowsMediaPlayer4.uiMode = "none";

            pictureBox4.ImageLocation = @"C:\play_off.png";
            pictureBox5.ImageLocation = @"C:\stop.png";
            pictureBox6.ImageLocation = @"C:\playspeed.png";
            pictureBox14.ImageLocation = @"C:\selectmovie.jpg";
            pictureBox15.ImageLocation = @"C:\makemovie.jpg";
        }

        int count_top = 0;
        int count_org = 0;
        int count_par = 0;
        int count = 1;

        private void axWindowsMediaPlayer2_Enter(object sender, EventArgs e)
        {
            if (flag3 == 1)
            {
                Bitmap bmp = new Bitmap(axWindowsMediaPlayer2.Width, axWindowsMediaPlayer2.Height);

                Form f = Form.ActiveForm;

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(new Point(f.Left + axWindowsMediaPlayer2.Left + 5, f.Top + axWindowsMediaPlayer2.Top + 30), new Point(0, 0), bmp.Size);
                }


                string url = "C:\\Users\\Tsuka\\Desktop\\picture\\top\\" + trackBar1.Value + ".jpg";
                
                bmp.Save(url, System.Drawing.Imaging.ImageFormat.Jpeg);
                string imageDir = @"C:\\Users\\Tsuka\\Desktop\\picture\\top"; // 画像ディレクトリ

                string[] jpgFiles = System.IO.Directory.GetFiles(imageDir, "*.jpg");

                int width = 112;
                int height = 84;

                imageList1.ImageSize = new Size(width, height);
                listView1.LargeImageList = imageList1;


                Image original = Bitmap.FromFile(jpgFiles[0]);
                    Image thumbnail = createThumbnail(original, width, height);

                    imageList1.Images.Add(thumbnail);
                    listView1.Items.Add(jpgFiles[0], count_top);

                    original.Dispose();
                    thumbnail.Dispose();
                    count_top++;
                
                System.IO.File.Delete(url);

                int start = trackBar1.Value - 2;
                int end = trackBar1.Value + 2;

                if (start <= 0)
                {
                    start = 0;
                }
                
                string START = start.ToString();
                string END = end.ToString();
                string command = @"-i C:\\ffmpeg\\bin\\org.mp4 -t 4 -ss " + START + " C:\\ffmpeg\\bin\\movie\\output" + count + ".mp4";
                System.Diagnostics.Process.Start("C:\\ffmpeg\\bin\\ffmpeg", command);
                count = count + 1;
            }
        }

        private void axWindowsMediaPlayer3_Enter(object sender, EventArgs e)
        {
            if (flag3 == 1)
            {
                Bitmap bmp = new Bitmap(axWindowsMediaPlayer3.Width, axWindowsMediaPlayer3.Height);

                Form f = Form.ActiveForm;

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(new Point(f.Left + axWindowsMediaPlayer3.Left + 5, f.Top + axWindowsMediaPlayer3.Top + 30), new Point(0, 0), bmp.Size);
                }

                //this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                //this.pictureBox2.Image = bmp;

                string url = "C:\\Users\\Tsuka\\Desktop\\picture\\top\\" + trackBar1.Value + ".jpg";

                bmp.Save(url, System.Drawing.Imaging.ImageFormat.Jpeg);
                string imageDir = @"C:\\Users\\Tsuka\\Desktop\\picture\\top"; // 画像ディレクトリ

                string[] jpgFiles = System.IO.Directory.GetFiles(imageDir, "*.jpg");

                int width = 112;
                int height = 84;

                imageList2.ImageSize = new Size(width, height);
                listView2.LargeImageList = imageList2;


                Image original = Bitmap.FromFile(jpgFiles[0]);
                Image thumbnail = createThumbnail(original, width, height);

                imageList2.Images.Add(thumbnail);
                listView2.Items.Add(jpgFiles[0], count_top);

                original.Dispose();
                thumbnail.Dispose();
                count_org++;

                System.IO.File.Delete(url);

                int start = trackBar1.Value - 2;
                int end = trackBar1.Value + 2;

                if (start <= 0)
                {
                    start = 0;
                }
                
                string START = start.ToString();
                string END = end.ToString();
                string command = @"-i C:\\ffmpeg\\bin\\par.mp4 -t 4 -ss " + START + "  C:\\ffmpeg\\bin\\movie\\output" + count + ".mp4";
                System.Diagnostics.Process.Start("C:\\ffmpeg\\bin\\ffmpeg", command);
                count = count + 1;
            }
        }

        private void axWindowsMediaPlayer4_Enter(object sender, EventArgs e)
        {
            if (flag3 == 1)
            {
                Bitmap bmp = new Bitmap(axWindowsMediaPlayer4.Width, axWindowsMediaPlayer4.Height);

                Form f = Form.ActiveForm;

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(new Point(f.Left + axWindowsMediaPlayer4.Left + 5, f.Top + axWindowsMediaPlayer4.Top + 30), new Point(0, 0), bmp.Size);
                }

                

                string url = "C:\\Users\\Tsuka\\Desktop\\picture\\top\\" + trackBar1.Value + ".jpg";

                bmp.Save(url, System.Drawing.Imaging.ImageFormat.Jpeg);
                string imageDir = @"C:\\Users\\Tsuka\\Desktop\\picture\\top"; // 画像ディレクトリ

                string[] jpgFiles = System.IO.Directory.GetFiles(imageDir, "*.jpg");

                int width = 112;
                int height = 84;

                imageList3.ImageSize = new Size(width, height);
                listView3.LargeImageList = imageList3;

                Image original = Bitmap.FromFile(jpgFiles[0]);
                Image thumbnail = createThumbnail(original, width, height);

                imageList3.Images.Add(thumbnail);
                listView3.Items.Add(jpgFiles[0], count_top);

                original.Dispose();
                thumbnail.Dispose();
                count_par++;

                System.IO.File.Delete(url);

                int start = trackBar1.Value - 2;
                int end = trackBar1.Value + 2;

                if (start <= 0)
                {
                    start = 0;
                }
                
                string START = start.ToString();
                string END = end.ToString();
                string command = @"-i C:\\ffmpeg\\bin\\top.mp4 -t 4 -ss " + START + " C:\\ffmpeg\\bin\\movie\\output" + count + ".mp4";
                System.Diagnostics.Process.Start("C:\\ffmpeg\\bin\\ffmpeg", command);
                count = count + 1;
            }
        }


        int flag2 = 0;
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            flag3 = 1;
            if (flag2 == 0)
            {
                movie1 = FolderPath + "top.mp4";
                movie2 = FolderPath + "org.mp4";
                movie3 = FolderPath + "par.mp4";

                axWindowsMediaPlayer2.URL = movie1;
                axWindowsMediaPlayer2.stretchToFit = true;

                axWindowsMediaPlayer3.URL = movie2;
                axWindowsMediaPlayer3.stretchToFit = true;

                axWindowsMediaPlayer4.URL = movie3;
                axWindowsMediaPlayer4.stretchToFit = true;

                pictureBox4.ImageLocation = @"C:\play_on.png";
                
                flag2 = 1;
            }
            else if (flag2 == 1)
            {
                axWindowsMediaPlayer2.Ctlcontrols.play();
                axWindowsMediaPlayer3.Ctlcontrols.play();
                axWindowsMediaPlayer4.Ctlcontrols.play();
                pictureBox4.ImageLocation = @"C:\play_on.png";
                
            }
            timer1.Start();
            timer2.Start();
            timer3.Start();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialogクラスのインスタンスを作成
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する
            fbd.Description = "フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            //RootFolder以下にあるフォルダである必要がある
            fbd.SelectedPath = @"C:\Windows";
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                flag = 0;
            }
            FolderPath = fbd.SelectedPath;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.pause();
            axWindowsMediaPlayer3.Ctlcontrols.pause();
            axWindowsMediaPlayer4.Ctlcontrols.pause();
            pictureBox4.ImageLocation = @"C:\play_off.png";
            
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.currentPosition = (double)trackBar1.Value;
            axWindowsMediaPlayer3.Ctlcontrols.currentPosition = (double)trackBar1.Value;
            axWindowsMediaPlayer4.Ctlcontrols.currentPosition = (double)trackBar1.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            trackBar1.Value = (int)axWindowsMediaPlayer2.Ctlcontrols.currentPosition;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //label1.Text = (axWindowsMediaPlayer2.Ctlcontrols.currentPositionString);
            trackBar1.Value = (int)axWindowsMediaPlayer3.Ctlcontrols.currentPosition;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //label1.Text = (axWindowsMediaPlayer2.Ctlcontrols.currentPositionString);
            trackBar1.Value = (int)axWindowsMediaPlayer4.Ctlcontrols.currentPosition;
        }

        private void axWindowsMediaPlayer2_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            switch (e.newState)
            {
                case 6:
                    pictureBox16.ImageLocation = @"C:\missload.jpg";
                    break;

                case 13:
                    pictureBox16.ImageLocation = @"C:\playing.png";
                    trackBar1.Maximum = (int)axWindowsMediaPlayer2.currentMedia.duration;
                    break;

                case 20:
                    pictureBox16.ImageLocation = @"C:\wait.jpg";
                    break;


                default:
                    break;
            }
        }

        private void axWindowsMediaPlayer3_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            switch (e.newState)
            {
                case 6:
                    pictureBox16.ImageLocation = @"C:\missload.jpg";
                    break;

                case 13:
                    pictureBox16.ImageLocation = @"C:\playing.png";
                    if (trackBar1.Maximum < (int)axWindowsMediaPlayer3.currentMedia.duration)
                    {
                        trackBar1.Maximum = (int)axWindowsMediaPlayer3.currentMedia.duration;
                    }
                    break;

                case 20:
                    pictureBox16.ImageLocation = @"C:\wait.jpg";
                    break;


                default:
                    break;
            }
        }

        private void axWindowsMediaPlayer4_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            switch (e.newState)
            {
                case 6:
                    pictureBox16.ImageLocation = @"C:\missload.jpg";
                    break;

                case 13:
                    pictureBox16.ImageLocation = @"C:\playing.png";
                    if (trackBar1.Maximum < (int)axWindowsMediaPlayer4.currentMedia.duration)
                    {
                        trackBar1.Maximum = (int)axWindowsMediaPlayer4.currentMedia.duration;
                    }
                    break;

                case 20:
                    pictureBox16.ImageLocation = @"C:\wait.jpg";
                    break;


                default:
                    break;
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }


        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.play();
            timer1.Start();
            //pictureBox8.ImageLocation = @"C:\play_on.png";

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer3.Ctlcontrols.play();
            timer2.Start();
            //pictureBox10.ImageLocation = @"C:\play_on.png";
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            timer3.Start();
            axWindowsMediaPlayer4.Ctlcontrols.play();
            //pictureBox12.ImageLocation = @"C:\play_on.png";
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.pause();
            timer1.Stop();
            //pictureBox8.ImageLocation = @"C:\play_off.png";
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer3.Ctlcontrols.pause();
            timer2.Stop();
            //pictureBox10.ImageLocation = @"C:\play_off.png";
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer4.Ctlcontrols.pause();
            timer3.Stop();
            //pictureBox12.ImageLocation = @"C:\play_off.png";
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            if (smile_flag == 1)
            {
                smile_flag = 0;
                //pictureBox6.ImageLocation = @"C:\smile_on.jpg";
            }
            else
            {
                smile_flag = 1;
                //pictureBox6.ImageLocation = @"C:\smile_off.jpg";
            }


        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (hand_flag == 1)
            {
                hand_flag = 0;
                //pictureBox13.ImageLocation = @"C:\hand_on.jpg";
            }
            else
            {
                hand_flag = 1;
                //pictureBox13.ImageLocation = @"C:\hand_off.jpg";
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\ffmpeg\\bin\\ffmpeg", @"-i C:\\ffmpeg\\bin\\movie\\output1.mp4 -i C:\\ffmpeg\\bin\\movie\\output2.mp4 -i C:\\ffmpeg\\bin\\movie\\output3.mp4 -i C:\\ffmpeg\\bin\\movie\\output4.mp4 -i C:\\ffmpeg\\bin\\movie\\output5.mp4 -i C:\\ffmpeg\\bin\\movie\\output6.mp4 -i C:\\ffmpeg\\bin\\movie\\output7.mp4 -i C:\\ffmpeg\\bin\\movie\\output8.mp4 -filter_complex ""concat=n=8:v=1:a=1"" C:\\ffmpeg\\bin\\movie\\output.mp4");
            //System.Diagnostics.Process.Start("C:\\ffmpeg\\bin\\ffmpeg", @"-i C:\\ffmpeg\\bin\\movie\\output1.mp4 -i C:\\ffmpeg\\bin\\movie\\output2.mp4 -i C:\\ffmpeg\\bin\\movie\\output4.mp4 -filter_complex ""concat=n=3:v=1:a=1"" C:\\ffmpeg\\bin\\movie\\output.mp4");
        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.settings.rate = trackBar4.Value;
            axWindowsMediaPlayer3.settings.rate = trackBar4.Value;
            axWindowsMediaPlayer4.settings.rate = trackBar4.Value;
        }

        private void label1_Click_4(object sender, EventArgs e)
        {

        }
    }
}
