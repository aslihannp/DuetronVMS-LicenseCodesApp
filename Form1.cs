using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMS.LisansKoduKayit
{
    public partial class Form1 : Form
    {
        BusinessLogicLayer.BLL bll;
        public Form1()
        {
            InitializeComponent();
            bll = new BusinessLogicLayer.BLL();
        }

        private void Btn_giris_Click(object sender, EventArgs e)
        {
            int ReturnValues = bll.SistemKontrolu(txt_kullanici_adi.Text, txt_sifre.Text);
            if (ReturnValues > 0)
            {
                AnaForm AF = new AnaForm();
                AF.Show();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre girişi", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Txt_sifre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
