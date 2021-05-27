//Hoda Khier + Yusef Aboroken 44/5

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace test_list_box
{
    public partial class form_listbox : Form
    {


        private DBSQL mySQL;

        public form_listbox()
        {
            InitializeComponent();
            DBSQL.DaseDataBaseName = "students";
            DBSQL.UserName = "root";
            DBSQL.Password = string.Empty;

            mySQL = DBSQL.Instance;

            fillCities();
        }

        private void fillCities()
        {
            pdf PDF = new pdf();
            person[] pp = mySQL.GetStudentsData();
            PDF.students_array(pp);
            add_text_to_pdf.Text = "Done!";
            PDF.CloseReport();


            city[] cities = mySQL.GetCityData();
            lstTest.Items.Clear();

            for(int i=0;i<mySQL.GetCityData().Length;i++)
            {
                lstTest.Items.Add(cities[i].CityName);
            }

           






        }

     

        private void lstTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = lstTest.SelectedItem.ToString();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_cities_Click(object sender, EventArgs e)
        {

            bool same = false;
            if (text_cities.Text != "")
            {

                city[] cities = mySQL.GetCityData();
                city citi = new city();
                string cityTemp = text_cities.Text;

                for (int i = 0; i < cities.Length; i++)
                {
                    if (cityTemp.Equals(cities[i].CityName))
                    {
                        same = true;
                    }
                    
                }

                if(same)
                {
                    MessageBox.Show("The city name already inserted\n try another city name");
                    text_cities.Text = string.Empty;
                    
                }
                else
                {
                    citi.CityName = cityTemp;
                    citi.CityCode = cities.Length + 1;
                    mySQL.InsertCity(citi);
                    text_cities.Text = string.Empty;
                }
            }
            else
                MessageBox.Show("Enter city name");

            fillCities();


            
        }

        private void form_listbox_Load(object sender, EventArgs e)
        {
            //int i, j;

            //dataGridView1.RowCount = 10;
            //dataGridView1.ColumnCount = 5;

            //for (i = 1; i <= 10; i++)
            //{
            //    dataGridView1.Columns[i - 1].HeaderText = i.ToString();
            //    dataGridView1.Columns[i - 1].Width = dataGridView1.Width / 11;
            //    dataGridView1.Rows[i - 1].HeaderCell.Value = i.ToString();

               
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            person[] per = mySQL.GetStudentsData();
            grades[] grade = mySQL.GetGradesData();
            pdf PDF = new pdf("students_grades_image");
            PDF.SetTitle("Students");
            PDF.SetImage("students.jfif");
            PDF.students_grades(per, grade);
            PDF.CloseReport();

        }
    }
}
