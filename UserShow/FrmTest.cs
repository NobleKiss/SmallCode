using ImageInDll;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UserShow
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
            TpClose.SetToolTip(pictureBox1, "关闭");
            comboBox1.DataSource = Enum.GetNames(typeof(OutImageName));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FlpPicture.Controls.Clear();
            var imgs = OutImageCollection.SourceImgList;
            foreach (var iitem in imgs)
            {
                PictureBox pictemp = new PictureBox
                {
                    Name = "pic",
                    Image =iitem.Value,
                    SizeMode = PictureBoxSizeMode.AutoSize,
                };
                FlpPicture.Controls.Add(pictemp);
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            FLPLabel.Controls.Clear();
            var imgsname = OutImageCollection.GetAllImagesName();
            foreach (var iitem in imgsname)
            {
                Label lbltemp = new Label
                {
                    Name = "lbltemp",
                    Text = iitem,
                    AutoSize = true,
                    ForeColor = Color.Black,
                    BackColor = Color.White
                };
                FLPLabel.Controls.Add(lbltemp);
            }
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar.Equals((char)Keys.Enter))
            {
                label1.Text = OutImageCollection.ValidationContainImgByName(textBox1.Text.Trim()).ToString();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            FlpPicture.Controls.Clear();
            PictureBox pictemp = new PictureBox
            {
                Name = "pic",
                Image = OutImageCollection.GetImageByName(textBox1.Text.Trim()),
                SizeMode = PictureBoxSizeMode.AutoSize,
            };
            FlpPicture.Controls.Add(pictemp);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlpPicture.Controls.Clear();
            Enum.TryParse(comboBox1.SelectedValue.ToString(), out OutImageName iname);
            PictureBox pictemp = new PictureBox
            {
                Name = "pic",
                Image = OutImageCollection.GetImageByEnum(iname),
                SizeMode = PictureBoxSizeMode.AutoSize,
            };
            FlpPicture.Controls.Add(pictemp);
        }
    }
}
