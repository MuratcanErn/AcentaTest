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
    public partial class AcentaEkle : Form
    {
        AppUser User;
        AppUsersRepository _appUsersRepository;
        public AcentaEkle(AppUser user)
        {
            InitializeComponent();
            _appUsersRepository = new AppUsersRepository();
            User = user;
            lblAdminAdi.Text =User.UserName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kayit kyt = new Kayit();
            kyt.Show();
            Hide();
        }

        private void AcentaEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
