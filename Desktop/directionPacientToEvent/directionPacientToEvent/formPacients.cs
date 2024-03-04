using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace directionPacientToEvent
{
    public partial class formPacients : Form
    {
        public formPacients()
        {
            InitializeComponent();
        }

        private void formPacientsLoad(object sender, EventArgs e)
        {
            ApplicationContext db = new ApplicationContext();
            var users = db.user.ToList();
            dgvUsers.DataSource = users;
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
