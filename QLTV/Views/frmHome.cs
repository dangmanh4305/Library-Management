using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            // 1. Chuyển "cha" của dòng chữ thành cái ảnh 
            label1.Parent = pictureBox1;

            // 2. Làm nền chữ trong suốt
            label1.BackColor = Color.Transparent;

            // 3. Căn giữa dòng chữ ra giữa bức ảnh
            label1.Left = (pictureBox1.Width - label1.Width) / 2;
            label1.Top = (pictureBox1.Height - label1.Height) / 2;

            // 4. Bật bộ đếm thời gian đếm 3 giây rồi tắt
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop(); // Bảo đồng hồ ngừng đếm
            this.Close();
        }
    }
}
