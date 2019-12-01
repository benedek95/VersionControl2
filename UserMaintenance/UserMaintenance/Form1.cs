using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblLastName.Text = Resource1.LastName; // label1
            
            btnAdd.Text = Resource1.Add; // button1
            button1.Text = Resource1.WriteFile; // button1

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtLastName.Text,
                
            };
            users.Add(u);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "DefaultOutputName.txt";

            saveFileDialog.Filter = "Text File | *.txt";
            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile());

                foreach (var item in users)
                {
                    writer.Write(item.ID);
                    writer.Write(item.FullName);
                    writer.WriteLine();
                }

                writer.Dispose();

                writer.Close();
            }
        }
    }
}
