using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using ImageInDll;

namespace UserShow
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            TpClose.BackColor = ColorTranslator.FromHtml("#FFFFE1");
            TpClose.SetToolTip(pictureBox1, "关闭");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var imgs = OutImageCollection.SourceImgList;
            OutImageCollection.GetImageByEnum(OutImageName.Four);
            var d = OutImageCollection.GetImageByName("Fou1r");
            var f = OutImageCollection.ValidationContainImgByName("Four");
            //int prewidth = 0;
            //int preheight = 0;
            //for (int i = 0; i < imgs.Count; i++)
            //{
            //    PictureBox pictemp = new PictureBox
            //    {
            //        Name = "pic" + i,
            //        Image = imgs[i],
            //        SizeMode = PictureBoxSizeMode.AutoSize,
            //        Location = new Point(prewidth, preheight)
            //    };
            //    prewidth += pictemp.Width;
            //    preheight += pictemp.Height;
            //    Controls.Add(pictemp);
            //}
            //Image s = Resources._123;
            //s = TestResource._3;
            //pictureBox2.Image = s;
            //获得正在运行类所在的名称空间
            //ResourceManager resMan = new ResourceManager("ImageInDll.Images", Assembly.GetExecutingAssembly());
            //Image GetIcon = (Image)resMan.GetObject("_123"); //获取资源文件中的图片

            //Type type = MethodBase.GetCurrentMethod().DeclaringType;

            //string _namespace = "UserShow";//type.Namespace;

            ////获取当前主程序集

            //Assembly currentAssembly = Assembly.GetExecutingAssembly();

            ////资源的根名称

            //string resourceRootName = _namespace + ".Resources";

            ////实例化资源管理类

            //ResourceManager resourceManager =
            //    new ResourceManager(resourceRootName, currentAssembly);
            ////new ResourceManager("ImageInDll.Resources", typeof(Resources).Assembly);

            ////根据资源名获得资源对象

            //Image myIcon = (Image)resourceManager.GetObject("3");

            //ResourceManager resMan = new ResourceManager("ImageInDll", Assembly.GetExecutingAssembly());
            //Image GetIcon = (Image)resMan.GetObject("1"); //获取资源文件中的图片
        }
        //int i = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            //OutImageCollection outImage = new OutImageCollection();
            //pictureBox1.Image = outImage.GetImageById(2);
        }
    }
}
