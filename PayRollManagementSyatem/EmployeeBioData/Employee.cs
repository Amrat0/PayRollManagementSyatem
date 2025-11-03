using PayRollManagementSyatem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PayRollManagementSyatem.Attendance;

namespace PayRollManagementSyatem.EmployeeBioData
{
    public partial class Employee : Form
    {
       
        PayRollManagementSystemEntities db = new PayRollManagementSystemEntities();
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            List<tbl_departments> li = db.tbl_departments.OrderBy(x => x.dep_name).ToList();
            cmdept.DataSource = li;
            cmdept.DisplayMember = "dep_name";
            cmdept.ValueMember = "dep_id";

            udepartment.DataSource = li;
            udepartment.DisplayMember = "dep_name";
            udepartment.ValueMember = "dep_id";

            getEmployee();
        }

        public void getEmployee()
        {
            dataGridView1.DataSource = db.VW_GETEMPLOYEE.ToList();

        }
        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog opFile = new OpenFileDialog();
            opFile.Title = "Select an Image";
            opFile.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (opFile.ShowDialog()== DialogResult.OK)
            {
                try
                {
                    string iName = opFile.FileName;
                    File.Copy(iName, Path.Combine(@"../../Resources/", Path.GetFileName(iName)));
                    pictureBox1.Image = new Bitmap(opFile.OpenFile());

                    label17.Text = "../../Resources/" + Path.GetFileName(iName);

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Unable to open file " + ex.Message);
                    label17.Text = "0";
                }

            }
            else
            {
              opFile.Dispose();
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {



            if (label17.Text.Equals("0"))
            {
                MessageBox.Show("Please Upload latest / every picture uploaded once..");
            }
            else
            {

            

            tbl_employee emp = new tbl_employee();
            emp.emp_name = txtname.Text;
            emp.emp_contact = txtphone.Text;
            emp.emp_cnic = txtcnic.Text;
            emp.emp_dob = txtdob.Value;
            emp.emp_img = label17.Text;


            if (radioButton1.Checked)
            {
                emp.emp_Gender = true;
            }
            else
            {
                emp.emp_Gender = false;
            }
            emp.emp_email = txtemail.Text;
            emp.emp_hiredate = txthiredate.Value;
            emp.emp_status = true;

            db.tbl_employee.Add(emp);
            db.SaveChanges();

            tbl_employeeworkingstatus st = new tbl_employeeworkingstatus();
            st.status_emp_fk = emp.emp_id;
            st.status_dep_fk =  (int)cmdept.SelectedValue;
            st.status_year = System.DateTime.Now.Year;
            st.status_basicsalary = Convert.ToInt32(txtsalary.Text);
            st.status_bouns = Convert.ToInt32(txtbouns.Text);
            st.status_medical = Convert.ToInt32(txtmedical.Text);
            st.status_casualleaves = Convert.ToInt32(txtannualleave.Text);
            st.status_sickleaves = Convert.ToInt32(txtsickleave.Text);
            st.status_halfdays = Convert.ToInt32(txthalfday.Text);
            st.status_annualleaves = Convert.ToInt32(txtannualleave.Text);
            db.tbl_employeeworkingstatus.Add(st);
            db.SaveChanges();

            MessageBox.Show("Record Successfully Inserted...");

            }

        }


        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {


           int  id = Convert.ToInt32(textBox12.Text);

            tbl_employee emp = db.tbl_employee.Where(x => x.emp_id == id).SingleOrDefault();

            if (emp != null)
            {

                utxtname.Text = emp.emp_name;
                utxtphone.Text = emp.emp_contact;
                utxtcnic.Text = emp.emp_cnic;
                udob.Value = (DateTime)emp.emp_dob;
                utxtemail.Text = emp.emp_email;
                uhiredate.Text = emp.emp_hiredate.ToString();

                pictureBox2.Image = Image.FromFile(emp.emp_img);


                if (emp.emp_Gender == true)
                {
                    urdmale.Checked = true;

                }
                else
                {
                    urdfemale.Checked = true;

                }
                tbl_employeeworkingstatus ews=db.tbl_employeeworkingstatus.Where(x=>x.status_emp_fk==emp.emp_id).SingleOrDefault();
                utxtsalary.Text = ews.status_basicsalary.ToString();
                utxtbouns.Text = ews.status_bouns.ToString();
                utxtmedical.Text = ews.status_medical.ToString();
                utxtcasualleave.Text = ews.status_casualleaves.ToString();
                utxtsickleave.Text = ews.status_sickleaves.ToString();
                utxthalfday.Text = ews.status_halfdays.ToString();
                utxtannualleave.Text = ews.status_annualleaves.ToString();
            }
            else
            {
                MessageBox.Show("No records were Founds......");
            }


        }

      

        private void button6_Click(object sender, EventArgs e)
        {
            //update data 
            int id = Convert.ToInt32(textBox12.Text);

            tbl_employee emp = db.tbl_employee.Where(x => x.emp_id == id).SingleOrDefault();

            emp.emp_name = utxtname.Text;
            emp.emp_contact = utxtphone.Text;
            emp.emp_cnic = utxtcnic.Text;
            emp.emp_dob = udob.Value;

            if (urdfemale.Checked)
            {
                emp.emp_Gender = true;
            }
            else
            {
                emp.emp_Gender = false;

            }
            emp.emp_email = utxtemail.Text;
            if (checkBox1.Checked == true)
            {
                emp.emp_status = true;

            }
            else
            {
                emp.emp_status = false;
            }
            // status table update
            tbl_employeeworkingstatus ews = db.tbl_employeeworkingstatus.Where(x => x.status_emp_fk == emp.emp_id).SingleOrDefault();

            ews.status_basicsalary = Convert.ToInt32(utxtsalary.Text);
            ews.status_bouns = Convert.ToInt32(utxtbouns.Text);
            ews.status_medical = Convert.ToInt32(utxtmedical.Text);
            ews.status_casualleaves = Convert.ToInt32(utxtcasualleave.Text);
            ews.status_sickleaves = Convert.ToInt32(utxtsickleave.Text);
            ews.status_halfdays = Convert.ToInt32(utxthalfday.Text);
            ews.status_annualleaves = Convert.ToInt32(utxtannualleave.Text);


            //image uploaded code............................
            if (label33.Text.Equals("0"))
            {

            }
            else
            {
                emp.emp_img = label33.Text;
            }

            db.SaveChanges();
            MessageBox.Show("Data Successfully Updated.");
         

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFile = new OpenFileDialog();
            opFile.Title = "Select an Image";
            opFile.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (opFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string iName = opFile.FileName;
                    File.Copy(iName, Path.Combine(@"../../Resources/", Path.GetFileName(iName)));
                    pictureBox2.Image = new Bitmap(opFile.OpenFile());

                    label33.Text = "../../Resources/" + Path.GetFileName(iName);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to open file " + ex.Message);
                    label33.Text = "0";
                }

            }
            else
            {
                opFile.Dispose();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            //--------------------searching button-----------------------
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                dataGridView1.DataSource = db.VW_GETEMPLOYEE.ToList();
                return;
            }
            //--------------------end search code-------------------------
            //--------------------if any records not found and enter wrong numeric then give error--------------
            if (int.TryParse(textBox1.Text, out int id))
            {
                var result = db.tbl_employee.Where(x => x.emp_id == id).ToList();
                if (result.Any())
                    dataGridView1.DataSource = result;
                else
                    MessageBox.Show("Employee not found.");
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric ID.");
            }


        }
    }
}
