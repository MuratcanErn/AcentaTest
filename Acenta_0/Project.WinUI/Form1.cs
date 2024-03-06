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

namespace Project.WinUI
{
    public partial class Form1 : Form
    {
        AppUsersRepository _appUserRepository;
        public Form1()
        {
            InitializeComponent();
            _appUserRepository = new AppUsersRepository();
        }

       

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try // program çökmesin diye giriş yapma işlemlerini trycathe aldık
            {
                if (txtKullaniciAdi.Text != string.Empty && txtAcentaAdi.Text!=string.Empty && txtAcentanNo.Text!= string.Empty && txtSifre.Text != string.Empty && txtSifre.Text.Length > 3) // giriş yapma textboxları null geçilmemesi için kontrol
                {

                    AppUser user = _appUserRepository.FirstOrDefault(x => x.UserName == txtKullaniciAdi.Text.ToLower() && x.Password == txtSifre.Text&&x.AgencyName==txtAcentaAdi.Text.ToLower() && x.AgencyNumber==(txtAcentanNo.Text)); //kutulardaki verilere uyan bir kullanıcı var ise dbize kullanıcıyı döncek yok ise null döncek sorgu. şifre tolower değil güvenlik amaçlı

                    if (user != null && user.Admin == false) // eğer bide firsordefault metodundan null değer dönmezse alttaki kodlar çalışsın
                    {
                        MessageBox.Show(" Admin Değilsiniz");
                       
                    }
                    else if (user != null && user.Admin == true)
                    {

                       
                        AcentaEkle ak = new AcentaEkle(user); 
                        ak.Show();
                        Hide();
                    }
                    else MessageBox.Show("Girdiğiniz Bilgileri kontrol ediniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
