using PayRollManagementSyatem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayRollManagementSyatem.Attendance
{
    public partial class ViewAttendancecs : Form
    {
        PayRollManagementSystemEntities db = new PayRollManagementSystemEntities();




        public ViewAttendancecs()
        {
            InitializeComponent();
        }

        private void ViewAttendancecs_Load(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");


            for (int i = 1; i <= 12; i++)
            {
                comboBox1.Items.Add(i.ToString());

            }
            for (int i =2024; i<=System.DateTime.Now.Year;i++)
            {
                comboBox2.Items.Add(i.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int month = Convert.ToInt32(comboBox1.SelectedItem);
            int year = Convert.ToInt32(comboBox2.SelectedItem);
            dataGridView1.DataSource = db.tbl_Attendance.Where(x => x.a_month == month && x.a_year == year ).ToList();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
