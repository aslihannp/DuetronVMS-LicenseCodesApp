using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VMS.LisansKoduKayit
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_yeniKayit_Click(object sender, EventArgs e)
        {
            string hata="";
            BusinessLogicLayer.BLL bLL = new BusinessLogicLayer.BLL();
            int ReturnValue= bLL.SatisKaydiEkle(Convert.ToInt32(numUpD_y_ULC.Value), Convert.ToInt32(combo_y_isim.SelectedValue),combo_y_isim.Text, Convert.ToInt32(numUpD_y_kamera.Value), Convert.ToInt32(numUpD_y_nvr.Value), Convert.ToInt32(numUpD_y_videoDuvar.Value), Convert.ToInt32(numUpD_y_isistasyonu.Value), Convert.ToInt32(numUpD_y_klavye.Value), dateTime_y_tarih.Value, txt_y_lisanskodu.Text, txt_y_donanimid.Text,txt_y_aciklama.Text, out hata);
            if (ReturnValue > 0)
            {
                MessageBox.Show("Yeni kayıt eklendi","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                yenile();
            }
            else
            {
                MessageBox.Show("Hatali giriş", hata, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        SqlConnection baglanti = new SqlConnection("Data Source =LAPTOP-A1R7KQJ1\\DENEME; Initial Catalog = LicenseCodes; User ID = sa; Password=Ahmetfaruk1!");

        private void AnaForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'licenseCodesDataSet3.SalesTable' table. You can move, or remove it, as needed.
            this.salesTableTableAdapter2.Fill(this.licenseCodesDataSet3.SalesTable);
            // TODO: This line of code loads data into the 'licenseCodesDataSet.SalesTable' table. You can move, or remove it, as needed.
            this.salesTableTableAdapter1.Fill(this.licenseCodesDataSet.SalesTable);
            // TODO: This line of code loads data into the 'licenseCodesDataSet2.ClientTable' table. You can move, or remove it, as needed.
            this.clientTableTableAdapter.Fill(this.licenseCodesDataSet2.ClientTable);
            // TODO: This line of code loads data into the 'licenseCodesDataSet1.SalesTable' table. You can move, or remove it, as needed.
            this.salesTableTableAdapter.Fill(this.licenseCodesDataSet1.SalesTable);

            


            DataSet daset = new DataSet();
            SqlDataAdapter adptr = new SqlDataAdapter("select * from ClientTable",baglanti);
            adptr.Fill(daset, "ClientTable");
            combo_y_isim.DisplayMember = "ClientName";
            combo_y_isim.ValueMember = "UC";
            combo_y_isim.DataSource = daset.Tables["ClientTable"];


            DataSet daset2 = new DataSet();
            SqlDataAdapter adptr2 = new SqlDataAdapter("select * from ClientTable", baglanti);
            adptr.Fill(daset2, "ClientTable");
            combo_d_isim.DisplayMember = "ClientName";
            combo_d_isim.ValueMember = "UC";
            combo_d_isim.DataSource = daset2.Tables["ClientTable"];



        }

        private void  yenile()
        {
            baglanti.Open();

            this.salesTableTableAdapter2.Fill(this.licenseCodesDataSet3.SalesTable);
            baglanti.Close();

           

        }



        private void FillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.clientTableTableAdapter.FillBy(this.licenseCodesDataSet2.ClientTable);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void Btn_kayitDuzenle_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL bLL = new BusinessLogicLayer.BLL();
            int ReturnValue = bLL.SatisKaydiDuzenle(Convert.ToInt32(numUpD_d_ULC.Value), Convert.ToInt32(combo_d_isim.SelectedValue), Convert.ToInt32(numUpD_d_kamera.Value), Convert.ToInt32(numUpD_d_nvr.Value), Convert.ToInt32(numUpD_d_videoDuvar.Value), Convert.ToInt32(numUpD_d_isistasyonu.Value), Convert.ToInt32(numUpD_d_klavye.Value), dateTime_d_tarih.Value, txt_d_lisanskodu.Text, txt_d_donanimid.Text, txt_d_aciklama.Text);

            if (ReturnValue > 0)
            {
                MessageBox.Show("Kayıt düzenlendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                yenile();
            }
            else
            {
                MessageBox.Show("Hatali giriş", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void FillByToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Btn_satisKaydiSil_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL bLL = new BusinessLogicLayer.BLL();
            if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int ReturnValue = bLL.SatisKaydiSil(Convert.ToInt32(numUpd_ks_ULC.Value));
                if (ReturnValue > 0)
                {
                    MessageBox.Show("Kayıt başarıyla silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    yenile();
                }
                else
                {
                    MessageBox.Show("Hatali giriş", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Musteri M = new Musteri();
            M.Show();
        }

       

        private void GridView_satisTablosu_SelectionChanged(object sender, EventArgs e)
        {
            if (gridView_satisTablosu.SelectedRows==null)
            {
                return;
            }
            if (gridView_satisTablosu.SelectedRows.Count == 0)
            {
                return;
            }
            txt_d_aciklama.Text = gridView_satisTablosu[11, gridView_satisTablosu.SelectedRows[0].Index].Value.ToString();
            txt_d_donanimid.Text = gridView_satisTablosu[10, gridView_satisTablosu.SelectedRows[0].Index].Value.ToString();
            txt_d_lisanskodu.Text = gridView_satisTablosu[9, gridView_satisTablosu.SelectedRows[0].Index].Value.ToString();
            numUpD_d_kamera.Value =Convert.ToDecimal(gridView_satisTablosu[3, gridView_satisTablosu.SelectedRows[0].Index].Value);
            numUpD_d_ULC.Value = Convert.ToDecimal(gridView_satisTablosu[0, gridView_satisTablosu.SelectedRows[0].Index].Value);
            numUpD_d_nvr.Value = Convert.ToDecimal(gridView_satisTablosu[4, gridView_satisTablosu.SelectedRows[0].Index].Value);
            numUpD_d_videoDuvar.Value = Convert.ToDecimal(gridView_satisTablosu[5, gridView_satisTablosu.SelectedRows[0].Index].Value);
            numUpD_d_isistasyonu.Value = Convert.ToDecimal(gridView_satisTablosu[6, gridView_satisTablosu.SelectedRows[0].Index].Value);
            numUpD_d_klavye.Value = Convert.ToDecimal(gridView_satisTablosu[7, gridView_satisTablosu.SelectedRows[0].Index].Value);
            dateTime_d_tarih.Value = Convert.ToDateTime(gridView_satisTablosu[8, gridView_satisTablosu.SelectedRows[0].Index].Value);
            combo_d_isim.Text = gridView_satisTablosu[2, gridView_satisTablosu.SelectedRows[0].Index].Value.ToString();

        }

        private void Btn_dgv_yenileme_Click(object sender, EventArgs e)
        {
            yenile();
        }
    }
}
