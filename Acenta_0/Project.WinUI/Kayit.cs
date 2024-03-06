using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.BLL.DesignPatterns.SingletonPattern;
using System.Diagnostics.Eventing.Reader;
using System.Xml.Linq;
using System.Data.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Project.WinUI
{
    
    public partial class Kayit : Form
    {
        private int deger = 10000;


        AppUsersRepository _appUserRepository;
        AppUserProfileRepository _appUserProfileRepository;
        public Kayit()
        {
            InitializeComponent();

            _appUserRepository = new AppUsersRepository();
            _appUserProfileRepository = new AppUserProfileRepository();
            txtMusteriNo.Text = deger.ToString();
            txtMusteriNo.Enabled = false;

        }
       
        private void button1_Click(object sender, EventArgs e)
        {

           
            deger++;
            txtMusteriNo.Text = deger.ToString();




            if (txtAcentaAdi.Text != string.Empty && txtSokak.Text != string.Empty && txtEMail.Text != string.Empty && txtTelNo.Text != string.Empty && txtMusteriNo.Text!=string.Empty)// kullanıcının bilgilerini bos bırakmamasını 
            {

                AppUser user = _appUserRepository.FirstOrDefault(x => x.AgencyNumber ==txtMusteriNo.Text);

                if (user != null)
                {
                    // Belirtilen müşteri numarasına sahip bir kullanıcı zaten var.
                    MessageBox.Show("Bu numaraya sahip bir müşteri var");
                }
                else if(user==null)
                {
                    // Belirtilen müşteri numarasına sahip bir kullanıcı yok, yeni kullanıcı oluşturabilirsiniz.
                    AppUserProfile ap = new AppUserProfile()
                    {

                        TelNo = txtTelNo.Text.ToLower(),
                        Email = txtEMail.Text.ToLower(),
                        Street = txtSokak.Text.ToLower(),
                        PostCode = txtPostCode.Text.ToLower(),
                        City = txtCity.Text.ToLower(),
                        Country=cmbCountry.SelectedItem.ToString().ToLower(),
                        FaxNo=txtFax.Text.ToLower()
                    
                    };
                    AppUser au = new AppUser()
                    {
                        UserName=txtIsim.Text.ToLower(),
                        Password=txtPass.Text.ToLower(),
                        AgencyName = txtAcentaAdi.Text.ToLower(),
                        AgencyNumber = txtMusteriNo.Text.ToLower(),
                        Admin=chbAdmin.Checked
                        
                        

                    };

                    ap.AppUser = au;
                    try
                    {
                        _appUserRepository.Add(au);
                        _appUserProfileRepository.Add(ap);
                        MessageBox.Show("Kayıt Başarılı");
                        var latestDatas = _appUserRepository.GetLastDatas().OrderByDescending(x => x.CreatedDate).ToList();

                        foreach (var latestData in latestDatas)
                        {
                            string agencyNumber = latestData.AgencyNumber;
                            string agencyName = latestData.AgencyName;

                            lst1.Items.Add(agencyNumber);
                            lst2.Items.Add(agencyName);
                        }



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen boşluk bırakmayınız");

            }
        }

        private void Kayit_Load(object sender, EventArgs e)
        {
            string[] countries = { "Turkey", "USA", "Germany", "France", "Italy" };

            // ComboBox'a başlangıç veri setini eklemek
            cmbCountry.Items.AddRange(countries);

            // Eğer istiyorsanız, varsayılan olarak ilk öğeyi seçebilirsiniz
            cmbCountry.SelectedIndex = 0;
            txtTelNo.Text = "Telefon No";
            txtSokak.Text = "Sokak";
            txtCity.Text = "Şehir";
            txtPostCode.Text = "Posta Kodu";
            txtFax.Text="Fax No";
            txtEMail.Text = "E-mail";
            txtTelNo.ForeColor = System.Drawing.Color.Gray;
            txtPostCode.ForeColor = System.Drawing.Color.Gray;
            txtSokak.ForeColor = System.Drawing.Color.Gray;
            txtCity.ForeColor = System.Drawing.Color.Gray;
            txtFax.ForeColor = System.Drawing.Color.Gray;
            txtEMail.ForeColor = System.Drawing.Color.Gray;

        }

        private void txtSokak_Enter(object sender, EventArgs e)
        {
            txtSokak.Text = "";
          
            txtSokak.ForeColor = System.Drawing.Color.Black;
            
        }

        private void txtPostCode_Enter(object sender, EventArgs e)
        {
           
            txtPostCode.Text = "";
            txtPostCode.ForeColor = System.Drawing.Color.Black;
           
        }

      

        private void txtFax_Enter(object sender, EventArgs e)
        {
            txtFax.Text = "";
            txtFax.ForeColor = System.Drawing.Color.Black;
        }

        private void txtTelNo_Enter(object sender, EventArgs e)
        {
            txtTelNo.Text = "";
            txtTelNo.ForeColor = System.Drawing.Color.Black;
        }

        private void txtCity_Enter(object sender, EventArgs e)
        {
            txtCity.Text = "";

            txtCity.ForeColor = System.Drawing.Color.Black;
        }

        private void txtEMail_Enter(object sender, EventArgs e)
        {
            txtEMail.Text = "";
            txtEMail.ForeColor = System.Drawing.Color.Black;
        }

       
    }
}
