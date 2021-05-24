using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace test_list_box
{
    public class DBSQL:DBconnection
    {
        private static DBSQL instance;

        private DBSQL()
        {
            baseDataBaseName = "students";
            baseUserName = "root";
            basePassword = string.Empty;
        }

        public static DBSQL Instance
        {
            get
            {
                if(instance==null)
                {
                    DBconnection connection = DBconnection.Instance();
                    instance = new DBSQL();
                }
                return instance;
            }
        }

        public static string DaseDataBaseName
        {
            set
            {
                if(value != string.Empty)
                {
                    baseDataBaseName = value;
                }
            }
            get
            {
                return baseDataBaseName;
            }
        }

        public static string UserName
        {
            set
            {
                if (value != string.Empty)
                {
                    baseUserName = value;
                }
            }
            get
            {
                return baseUserName;
            }
        }


        public static string Password
        {
            set
            {
                if (value != string.Empty)
                {
                    basePassword = value;
                }
            }
            get
            {
                return basePassword;
            }
        }

        public int GetCityMaxNumber()
        {
            int result;
            string cmdStr = "SELECT Max(cityCode) FROM city";

            using(MySqlCommand command=new MySqlCommand(cmdStr))
            {
                result = ExecuteScalarIntQuery(command);
            }
            return result;
        }

        public void InsertCity(city Item)
        {
            string cmdStr = "INSERT INTO City (cityCode,cityName) VALUES (@cityCode,@cityName)";

            using(MySqlCommand command = new MySqlCommand(cmdStr))
            {
                command.Parameters.AddWithValue("@cityCode", Item.CityCode);
                command.Parameters.AddWithValue("@cityName", Item.CityName);

                base.ExecuteSimpleQuery(command);
            }
        }

        public bool checkCity(string cityName)
        {
            bool result = false;

            string cmdStr = "SELECT count(*) FROM city WHERE cityName=@cityName";

            using (MySqlCommand command = new MySqlCommand(cmdStr))
            {
                command.Parameters.AddWithValue("@cityName", cityName);
                result = ExecuteScalarIntQuery(command) > 0;
            }

            return result;
        }


        public person[] GetStudentsData()
        {
            DataSet ds = new DataSet();
            person[] students = null;
            string cmdStr = "SELECT * FROM persons";

            using (MySqlCommand command = new MySqlCommand())
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();

            try
            {
                dt = ds.Tables[0];
            }

            catch
            { }
                if (dt.Rows.Count > 0)
                {
                    students = new person[dt.Rows.Count];
                    for (int i = 0; i < students.Length; i++)
                    {
                        students[i] = new person();
                        students[i].CityCode = Convert.ToInt64(dt.Rows[i][0]);
                        students[i].FirstName = dt.Rows[i][1].ToString();
                        students[i].Id = Convert.ToInt64(dt.Rows[i][2]);
                        students[i].LastName = dt.Rows[i][3].ToString();
                        students[i].LastName = dt.Rows[i][4].ToString();
                        students[i].Password = dt.Rows[i][5].ToString();
                    }
                }

            return students;
        }

        public city[] GetCityData()
        {
            DataSet ds = new DataSet();
            city[] city = null;
            string cmdStr = "SELECT * FROM city ORDER BY cityName";

            using(MySqlCommand command =new MySqlCommand(cmdStr))
            {
                ds = GetMultipleQuery(command);
            }

            DataTable dt = new DataTable();
            try
            {
                dt = ds.Tables[0];
            }

            catch
            {

            }

            if(dt.Rows.Count>0)
            {
                city = new city[dt.Rows.Count];
                for(int i=0;i<city.Length;i++)
                {
                    city[i] = new city();
                    city[i].CityCode = Convert.ToInt64(dt.Rows[i][0]);
                    city[i].CityName = dt.Rows[i][1].ToString();
                }
            }
            return city;
        }
    }
}
