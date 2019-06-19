using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ImagesAnimation
{
    public partial class PMD : Form
    {
        public PMD()
        {
            InitializeComponent();
            FormLayout();
        }

        PictureBox pb_PicRoll;  //显示区域
        PictureBox pb_PicRoll2;  //显示区域

        /// /// <summary>
        /// 窗体布局
        /// </summary>
        void FormLayout()
        {
            DoubleBuffered = true;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(600, 300);
            BackColor = Color.LightBlue;

            pb_PicRoll = new PictureBox();
            pb_PicRoll.Location = new Point(50, 50);
            pb_PicRoll2 = new PictureBox();
            pb_PicRoll2.Location = new Point(150, 50);
            pb_PicRoll2.Size = new Size(410, 70);
            Controls.Add(pb_PicRoll);
            Controls.Add(pb_PicRoll2);            
        }

        private void PMD_Load(object sender, EventArgs e)
        {
            InitPicRoll();
        }
        List<Image> ls_images = new List<Image>(); //存放图片组
        Timer t_remain = new Timer(); //切换
        Timer t_roll = new Timer();   //滚动
        int n_index = 0;    //滚动索引
        int n_height;   //滚动高度
        int n_width;    //滚动宽度
        int n_top;  //滚动上边距
        Graphics gh_bg;    //画笔

        void InitPicRoll()
        {
            string[] img_files = Directory.GetFiles(string.Format("{0}/Images", Application.StartupPath), "*.png");
            foreach (string img_path in img_files)
            {
                ls_images.Add(Image.FromFile(img_path));
            }
            //pb_PicRoll.SizeMode = PictureBoxSizeMode.AutoSize;
            if(ls_images!=null&& ls_images.Count>0)
                pb_PicRoll.Size = new Size(ls_images[0].Width, ls_images[0].Height);
            n_height = pb_PicRoll.Height;
            n_width = pb_PicRoll.Width;
            gh_bg = pb_PicRoll.CreateGraphics();
            t_remain.Interval = 3 * 1000;
            t_remain.Tick += new EventHandler(t_remain_Tick);
            t_roll.Interval = 30;
            t_roll.Tick += new EventHandler(t_roll_Tick);
            t_remain.Start();
            t_roll.Start();
        }
        void t_remain_Tick(object sender, EventArgs e)
        {
            n_index = ++n_index % ls_images.Count;
            n_top = 0;
            t_roll.Start();
        }

        void t_roll_Tick(object sender, EventArgs e)
        {
            n_top -= 5;
            if (n_top <= -n_height)
            {
                t_roll.Stop();
            }
            Bitmap bt = new Bitmap(n_width, n_height);
            Graphics gh = Graphics.FromImage(bt);
            for (int i = 0; i < 2; i++)
            {
                gh.DrawImage(Image.FromFile(string.Format("{0}/Images/bg.jpg", Application.StartupPath)), new Rectangle(new Point(0, n_top + i * n_height), new Size(n_width, n_height)));
                gh.DrawImage(ls_images[(n_index + i) % ls_images.Count], new Rectangle(new Point(0, n_top + i * n_height), new Size(n_width, n_height)));
            }
            gh_bg.DrawImage(bt, new Rectangle(new Point(0, 0), new Size(n_width, n_height)));
            gh.Dispose();
            bt.Dispose();
        }
        /// <summary>
        /// 处理图片透明操作
        /// </summary>
        /// <param name="srcImage">原始图片</param>
        /// <param name="opacity">透明度(0.0---1.0)</param>
        /// <returns></returns>
        private Image TransparentImage(Image srcImage, float opacity)
        {
            float[][] nArray ={ new float[] {1, 0, 0, 0, 0},
                        new float[] {0, 1, 0, 0, 0},
                        new float[] {0, 0, 1, 0, 0},
                        new float[] {0, 0, 0, opacity, 0},
                        new float[] {0, 0, 0, 0, 1}};
            ColorMatrix matrix = new ColorMatrix(nArray);
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Bitmap resultImage = new Bitmap(srcImage.Width, srcImage.Height);
            Graphics g = Graphics.FromImage(resultImage);
            g.DrawImage(srcImage, new Rectangle(0, 0, srcImage.Width, srcImage.Height), 0, 0, srcImage.Width, srcImage.Height, GraphicsUnit.Pixel, attributes);

            return resultImage;
        }
        float fo = 0.0f;
        private void button1_Click(object sender, EventArgs e)
        {            
            pb_PicRoll2.Image = TransparentImage(Image.FromFile(string.Format("{0}/Images/TOPCenter.png", Application.StartupPath)), fo);
            fo += 0.1f;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pb_PicRoll2.Image = TransparentImage(Image.FromFile(string.Format("{0}/Images/TOPCenter.png", Application.StartupPath)), fo);
            fo -= 0.1f;
        }
    }
}
