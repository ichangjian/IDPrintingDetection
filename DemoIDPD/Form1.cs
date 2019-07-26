using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDPrintingDetection;
namespace DemoIDPD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bitmap_sh, bitmap_st;
        IDPrintingDetection.IDPD idpd = new IDPrintingDetection.IDPD();

        private void button_select_st_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            textBox_st.Text = file.FileName;
            file.Dispose();

            try
            {
                bitmap_st = (Bitmap)Bitmap.FromFile(textBox_st.Text);
                Bitmap copyBmm = (Bitmap)bitmap_st.Clone();
                IntPtr data = new IntPtr();
                int width = copyBmm.Width;
                int height = copyBmm.Height;
                BitmapData bd = copyBmm.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                data = bd.Scan0;
                idpd.setStImage(data, width, height);
                copyBmm.UnlockBits(bd);
            }
            catch (Exception)
            {
                textBox_st.Text = null;
                MessageBox.Show("选图不对");
            }

        }

        private void button_select_sh_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            textBox_sh.Text = file.FileName;
            file.Dispose();
            try
            {
                bitmap_sh = (Bitmap)Bitmap.FromFile(textBox_sh.Text);
                Bitmap copyBmm = (Bitmap)bitmap_sh.Clone();
                IntPtr data = new IntPtr();
                int width = copyBmm.Width;
                int height = copyBmm.Height;
                BitmapData bd = copyBmm.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                data = bd.Scan0;
                idpd.setShImage(data, width, height);
                copyBmm.UnlockBits(bd);
            }
            catch (Exception)
            {
                textBox_sh.Text = null;
                MessageBox.Show("选图不对");
            }
        }

        private void button_run_Click(object sender, EventArgs e)
        {
            int re = idpd.sum(1, 2);
            MessageBox.Show(textBox_st.Text+"\n"+ textBox_sh.Text+"\nresult" + re);

            
        }



    }
}
