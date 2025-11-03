using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PayRollManagementSyatem.Model;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
namespace PayRollManagementSyatem.Attendance
{
    public partial class AttendanceForm : Form
    {
        PayRollManagementSystemEntities db = new PayRollManagementSystemEntities();

        List<tbl_Attendance> li = new List<tbl_Attendance>();
        public AttendanceForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //.....read butoon
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            int rw = 0;
            int cl = 1;

            xlApp = new Excel.Application();

            xlWorkBook = xlApp.Workbooks.Open(@"C:\Users\Cocomo\Desktop\Attendance.xlsx", 0, true, 5, "", "", true,Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,"\t", false,false,0,true,1,0);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;

            rw = range.Rows.Count;

            //data read
            for(int i = 2; i < rw; i++)
            {
                tbl_Attendance atd = new tbl_Attendance();

                atd.a_emp_id_fk = (int)(range.Cells[i, 1] as Excel.Range).Value;
                atd.a_day = (int)(range.Cells[i, 2] as Excel.Range).Value;
                atd.a_month = (int)(range.Cells[i, 3] as Excel.Range).Value;
                atd.a_year = (int)(range.Cells[i, 4] as Excel.Range).Value;
                atd.a_timein = (string)(range.Cells[i, 5] as Excel.Range).Value;
                atd.a_timeout = (string)(range.Cells[i, 6] as Excel.Range).Value;
                atd.a_difference = (int)(range.Cells[i, 7] as Excel.Range).Value;

                cl = 1;

                li.Add(atd);

            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            dataGridView1.DataSource = li;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            foreach(var item in li)
            {
                db.tbl_Attendance.Add(item);
                
            }
            db.SaveChanges();
            MessageBox.Show("Data imported successfully...");
        }
    }
}
