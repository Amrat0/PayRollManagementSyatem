using PayRollManagementSyatem.Attendance;
using PayRollManagementSyatem.EmployeeBioData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayRollManagementSyatem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addNewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Employee EMP = new Employee();
            EMP.Show();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttendanceForm attendance = new AttendanceForm();
            attendance.Show();
        }

        private void viewAttendenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAttendancecs viewattendence = new ViewAttendancecs();
            viewattendence.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
        }

        bool sidebarExpand = true;
        private void sidebarTrans_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 55)
                {
                    sidebarExpand = false;
                    sidebarTrans.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if(sidebar.Width >= 195)
                {
                    sidebarExpand = true;
                    sidebarTrans.Stop();
                }
               
            }
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTrans.Start();
        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            
            emp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewAttendancecs vattend = new ViewAttendancecs();
            vattend.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            AttendanceForm af = new AttendanceForm();
            af.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 emp = new Form1();
            emp.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
