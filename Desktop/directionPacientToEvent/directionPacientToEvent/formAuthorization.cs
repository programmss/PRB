namespace directionPacientToEvent
{
    public partial class formAuthorization : Form
    {
        public formAuthorization()
        {
            InitializeComponent();
        }

        private void btnSignInClick(object sender, EventArgs e)
        {
            //Получение логинов и паролей из БД
            ApplicationContext db = new ApplicationContext();
            var doctors = db.doctor.ToList();
            List<string> logins = doctors.Select(x => x.login).ToList();
            List<string> passwords = doctors.Select(x => x.password).ToList();

            //проверка существования введённых данных в БД
            string login = tbLogin.Text;
            string password = tbPassword.Text;

            if(logins.Any(l => l == login) && passwords[logins.IndexOf(logins.First(l => l == login))] == password)
            {
                formPacients formPacients = new formPacients();
                this.Hide();
                formPacients.Show();
            }
            else
            {
                MessageBox.Show("Вход не выполнен!");
            }
        }
    }
}