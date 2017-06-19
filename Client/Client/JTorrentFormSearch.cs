using System;
using System.IO;
using System.Windows.Forms;

namespace Client
{
    public partial class JTorrentFormSearch : Form
    {
        DbProvider dbProvider;
        public JTorrentFormSearch(DbProvider dbProvider)
        {
            this.dbProvider = dbProvider;
            InitializeComponent();
        }

        private static void AppendData(string filename, string stringData)
        {
            using (var fileStream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.None))
            using (var bw = new BinaryWriter(fileStream))
            {
                bw.Write(stringData);
                bw.Close();
                fileStream.Close();
            }

            
        }

        private static void AppendData(string filename, byte[] array)
        {
            using (var fileStream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.None))
            using (var bw = new BinaryWriter(fileStream))
            {
                bw.Write(array);
                bw.Close();
                fileStream.Close();
            }
        }

        private void JTorrentFormSearch_Load(object sender, EventArgs e)
        {
            user.Text = "Hi, " + dbProvider.currentUser;
        }

        private void searchForm_btnSearch_Click(object sender, EventArgs e)
        {
            // clear the result table
            listViewSearch.Text = String.Empty;

            string response = dbProvider.sendAndGetMessage("search " + searchForm_txtSearch.Text + "$");

            string[] results = response.Split("\r\n".ToCharArray());

            foreach (string r in results)
            {
                if (r == null || r == "")
                    continue;

                string[] details = r.Split("\t".ToCharArray());
                ListViewItem lvi = new ListViewItem(details[0]);
                for (int i = 1; i < details.Length; i++)
                    lvi.SubItems.Add(details[i]);

                listViewSearch.Items.Add(lvi);
            }
        }

        private void searchForm_txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchForm_btnSearch_Click(this, new EventArgs());
            }
        }

        private void searchForm_txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (browseFile.Text == "")
            {
                MessageBox.Show("Please choose a file to upload");
                return;
            }
            else
            {
                string path = browseFile.Text;
                long size = new FileInfo(path).Length;
                string response = dbProvider.sendAndGetMessage("upload " + path + " " + size + " " + dbProvider.currentUser + "$");
                // i did this to remove the spaces from the end of the response
                string separators = "\r\n ";
                string[] words = response.Split(separators.ToCharArray());
                if (words[0] == "OK")
                {
                    MessageBox.Show("The file was uploaded");
                }
                else
                {
                    MessageBox.Show("The file already exists on the server");
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Browse";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                browseFile.Text = fdlg.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dbProvider.currentUser = "";
            this.Hide();
            frmLogin login = new frmLogin(dbProvider);
            login.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void listViewSearch_DoubleClick(object sender, EventArgs e)
        {
            if (listViewSearch.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listViewSearch.SelectedItems;

                ListViewItem path = items[0];
                string path_string = path.SubItems[2].Text;
                string[] parts = path_string.Split("\\".ToCharArray());

                double file_dimension = Convert.ToDouble(path.SubItems[3].Text);
                
                dbProvider.sendMessage("download " + path_string + "$");

                int contor = (int)file_dimension / 1024;
                int rest = (int)file_dimension % 1024;

                for (int i = 0; i < contor; i++)
                {
                    byte[] array = dbProvider.getBytesFromStream(1024);
                    AppendData(Application.StartupPath + "\\" + parts[parts.Length - 1], array);
                }

                if (rest != 0)
                {
                    byte[] array = dbProvider.getBytesFromStream(rest);
                    AppendData(Application.StartupPath + "\\" + parts[parts.Length - 1], array);
                }

                MessageBox.Show("The download has finished successfully!");
            }
        }
    }
}
