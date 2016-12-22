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

            axWindowsMediaPlayer2.uiMode = "none";
            axWindowsMediaPlayer3.uiMode = "none";
            axWindowsMediaPlayer4.uiMode = "none";


            pictureBox4.ImageLocation = @"C:\play.png";
            pictureBox5.ImageLocation = @"C:\stop.png";
            pictureBox6.ImageLocation = @"C:\timer.png";
        }

        private void axWindowsMediaPlayer2_Enter(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer3_Enter(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer4_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            double sec = axWindowsMediaPlayer2.Ctlcontrols.currentPosition;
            int SEC = (int)sec;
            string car = SEC.ToString();
            

            WriteCsv(SEC, 1, FolderPath);

            Bitmap bmp = new Bitmap(283, 211);

            Form f = Form.ActiveForm;
            
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(new Point(f.Left + axWindowsMediaPlayer2.Left + 5, f.Top + axWindowsMediaPlayer2.Top +30), new Point(0, 0), bmp.Size);
            }

            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.Image = bmp;
            bmp.Save("C:\\Users\\Tsuka\\Desktop\\picture\\top\\sample.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            string imageDir = @"C:\\Users\\Tsuka\\Desktop\\picture\\top"; // 画像ディレクトリ

            string[] jpgFiles = System.IO.Directory.GetFiles(imageDir, "*.jpg");

            int width = 112;
            int height = 84;

            imageList1.ImageSize = new Size(width, height);
            listView1.LargeImageList = imageList1;

            for (int i = 0; i < jpgFiles.Length; i++)
            {
                Image original = Bitmap.FromFile(jpgFiles[i]);
                Image thumbnail = createThumbnail(original, width, height);

                imageList1.Images.Add(thumbnail);
                listView1.Items.Add(jpgFiles[i], i);

                original.Dispose();
                thumbnail.Dispose();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            double sec = axWindowsMediaPlayer3.Ctlcontrols.currentPosition;
            int SEC = (int)sec;
            string car = SEC.ToString();
            

            WriteCsv(SEC, 2, FolderPath);

            Bitmap bmp = new Bitmap(283, 211);

            Form f = Form.ActiveForm;
            
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(new Point(f.Left + axWindowsMediaPlayer3.Left + 5, f.Top + axWindowsMediaPlayer3.Top + 30), new Point(0, 0), bmp.Size);
            }

            this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox2.Image = bmp;
            bmp.Save("C:\\Users\\Tsuka\\Desktop\\picture\\org\\sample.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            string imageDir = @"C:\\Users\\Tsuka\\Desktop\\picture\\org"; // 画像ディレクトリ
            
            string[] jpgFiles = System.IO.Directory.GetFiles(imageDir, "*.jpg");

            int width = 112;
            int height = 84;

            imageList2.ImageSize = new Size(width, height);
            listView2.LargeImageList = imageList2;

            for (int i = 0; i < jpgFiles.Length; i++)
            {
                Image original = Bitmap.FromFile(jpgFiles[i]);
                Image thumbnail = createThumbnail(original, width, height);

                imageList2.Images.Add(thumbnail);
                listView2.Items.Add(jpgFiles[i], i);

                original.Dispose();
                thumbnail.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            double sec = axWindowsMediaPlayer4.Ctlcontrols.currentPosition;
            int SEC = (int)sec;
            string car = SEC.ToString();
           



            WriteCsv(SEC, 3, FolderPath);
            Bitmap bmp = new Bitmap(283, 211);

            Form f = Form.ActiveForm;
            if (f != null)
            
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(new Point(f.Left + axWindowsMediaPlayer4.Left + 5, f.Top + axWindowsMediaPlayer4.Top + 30), new Point(0, 0), bmp.Size);
            }

            this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox3.Image = bmp;
            bmp.Save("C:\\Users\\Tsuka\\Desktop\\picture\\par\\sample.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            string imageDir = @"C:\\Users\\Tsuka\\Desktop\\picture\\par"; // 画像ディレクトリ
            string[] jpgFiles = System.IO.Directory.GetFiles(imageDir, "*.jpg");

            int width = 112;
            int height = 84;

            imageList3.ImageSize = new Size(width, height);
            listView3.LargeImageList = imageList3;

            for (int i = 0; i < jpgFiles.Length; i++)
            {
                Image original = Bitmap.FromFile(jpgFiles[i]);
                Image thumbnail = createThumbnail(original, width, height);

                imageList3.Images.Add(thumbnail);
                listView3.Items.Add(jpgFiles[i], i);

                original.Dispose();
                thumbnail.Dispose();
            }
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog2_HelpRequest(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog3_HelpRequest(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        int flag2 = 0;
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (flag2 == 0)
            {


                movie1 = FolderPath + "Top.mp4";
                //movie2 = FolderPath + "Top.mp4";
                //movie3 = FolderPath + "Top.mp4";
                movie2 = FolderPath + "Organizer.mp4";
                movie3 = FolderPath + "Participant.mp4";

                axWindowsMediaPlayer2.URL = movie1;
                axWindowsMediaPlayer2.stretchToFit = true;

                axWindowsMediaPlayer3.URL = movie2;
                axWindowsMediaPlayer3.stretchToFit = true;

                axWindowsMediaPlayer4.URL = movie3;
                axWindowsMediaPlayer4.stretchToFit = true;


                /*axWindowsMediaPlayer2.Ctlcontrols.play();
                axWindowsMediaPlayer3.Ctlcontrols.play();
                axWindowsMediaPlayer4.Ctlcontrols.play();*/
                flag2 = 1;
            }
            else if (flag2 == 1)
            {
                axWindowsMediaPlayer2.Ctlcontrols.play();
                axWindowsMediaPlayer3.Ctlcontrols.play();
                axWindowsMediaPlayer4.Ctlcontrols.play();
            }
            timer1.Start();
            timer2.Start();
            timer3.Start();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.pause();
            axWindowsMediaPlayer3.Ctlcontrols.pause();
            axWindowsMediaPlayer4.Ctlcontrols.pause();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.currentPosition = (double)trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer3.Ctlcontrols.currentPosition = (double)trackBar2.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer4.Ctlcontrols.currentPosition = (double)trackBar3.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = (axWindowsMediaPlayer2.Ctlcontrols.currentPositionString);
            trackBar1.Value = (int)axWindowsMediaPlayer2.Ctlcontrols.currentPosition;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //label1.Text = (axWindowsMediaPlayer2.Ctlcontrols.currentPositionString);
            trackBar2.Value = (int)axWindowsMediaPlayer3.Ctlcontrols.currentPosition;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //label1.Text = (axWindowsMediaPlayer2.Ctlcontrols.currentPositionString);
            trackBar3.Value = (int)axWindowsMediaPlayer4.Ctlcontrols.currentPosition;
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer2_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            switch (e.newState)
            {
                case 0:
                    label2.Text = ("Undefined"); //WindowsMediaPlayerの状態が定義されていん
                    break;

                case 6:
                    label2.Text = ("NoMedia"); //再生リストは開いています
                    break;

                case 12:
                    label2.Text = ("Opening"); //メディアは取得済みで、現在開いているろです
                    break;

                case 13:
                    label2.Text = ("Opening"); //メディアは現在開いています
                    trackBar1.Maximum = (int)axWindowsMediaPlayer2.currentMedia.duration;
                    break;

                case 14:
                    label2.Text = ("BeginCodecAcquistion"); //コーデックの取得を開始してす
                    break;

               

                case 20:
                    label2.Text = ("Waiting"); //メディアを待機中です
                    break;

                case 21:
                    label2.Text = ("OpeningUnknownURL"); //不明な種類のURLを開いています
                    break;

                default:
                    break;
            }
        }

        private void axWindowsMediaPlayer3_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            switch (e.newState)
            {
                case 0:
                    label2.Text = ("Undefined"); //WindowsMediaPlayerの状態が定義されていん
                    break;

                case 6:
                    label2.Text = ("NoMedia"); //再生リストは開いています
                    break;

                case 12:
                    label2.Text = ("Opening"); //メディアは取得済みで、現在開いているろです
                    break;

                case 13:
                    label2.Text = ("Opening"); //メディアは現在開いています
                    trackBar2.Maximum = (int)axWindowsMediaPlayer3.currentMedia.duration;
                    break;

                case 14:
                    label2.Text = ("BeginCodecAcquistion"); //コーデックの取得を開始してす
                    break;

                

                case 20:
                    label2.Text = ("Waiting"); //メディアを待機中です
                    break;

                case 21:
                    label2.Text = ("OpeningUnknownURL"); //不明な種類のURLを開いています
                    break;

                default:
                    break;
            }
        }

        private void axWindowsMediaPlayer4_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            switch (e.newState)
            {
                case 0:
                    label2.Text = ("Undefined"); //WindowsMediaPlayerの状態が定義されていん
                    break;

                case 6:
                    label2.Text = ("NoMedia"); //再生リストは開いています
                    break;

                case 12:
                    label2.Text = ("Opening"); //メディアは取得済みで、現在開いているろです
                    break;

                case 13:
                    label2.Text = ("Opening"); //メディアは現在開いています
                    trackBar3.Maximum = (int)axWindowsMediaPlayer4.currentMedia.duration;
                    break;

                case 14:
                    label2.Text = ("BeginCodecAcquistion"); //コーデックの取得を開始してす
                    break;

                

                case 20:
                    label2.Text = ("Waiting"); //メディアを待機中です
                    break;

                case 21:
                    label2.Text = ("OpeningUnknownURL"); //不明な種類のURLを開いています
                    break;

                default:
                    break;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

       
    }
}
