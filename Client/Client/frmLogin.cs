using System;
using System.Windows.Forms;

namespace Client
{
    public partial class frmLogin : Form
    {
        DbProvider dbProvider;

        public frmLogin(DbProvider dbProvider)
        {
            this.dbProvider = dbProvider;
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // login button
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_Password.Text == "" || txt_UserName.Text == "")
            {
                MessageBox.Show("Please provide username and password");
                return;
            }
            else
            {
                string response = dbProvider.sendAndGetMessage("login " + txt_UserName.Text + " " + txt_Password.Text + "$");
                // i did this to remove the spaces from the end of the response
                string separators = "\r\n ";
                string[] words = response.Split(separators.ToCharArray());
                if (words[0] == "OK")
                {
                    dbProvider.currentUser = txt_UserName.Text;
                    this.Hide();
                    JTorrentFormSearch tfs = new JTorrentFormSearch(dbProvider);
                    tfs.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect username/password");
                    return;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // register button
        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_Password.Text == "" || txt_UserName.Text == "")
            {
                MessageBox.Show("Please provide username and password");
                return;
            }
            else
            {
                string response = dbProvider.sendAndGetMessage("register " + txt_UserName.Text + " " + txt_Password.Text + "$");
                // i did this to remove the spaces from the end of the response
                string separators = "\r\n ";
                string[] words = response.Split(separators.ToCharArray());
                Console.WriteLine(words[0]);
                if (words[0] == "OK")
                {
                    MessageBox.Show("The user has been registered");
                    this.Hide();
                    JTorrentFormSearch tfs = new JTorrentFormSearch(dbProvider);
                    tfs.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The user already exists");
                    return;
                }
            }
        }
    }
}
