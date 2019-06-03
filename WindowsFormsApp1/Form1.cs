using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqLiteTest;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.MessageInfo' table. You can move, or remove it, as needed.

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new Model1();
            var viberMessages = db.MessageInfo
                .Where(z => z.ChatId == 1)
                .OrderByDescending(z => z.TimeStamp)
                .Take(20)
                .ToList();
            messagesBindingSource.DataSource = viberMessages;
            dataGridView1.DataSource = messagesBindingSource;
        }
    }
}
