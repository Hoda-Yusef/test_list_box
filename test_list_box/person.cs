using System;
using System.Collections.Generic;
using System.Text;

namespace test_list_box
{
    public class person
    {
        private long id;
        private string firstName;
        private string lastName;
        private long cityCode;
        private string userName;
        private string password;

        public person()
        {
            Id = -1;
            CityCode = -1;
            FirstName = string.Empty;
            LastName = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
        }

        public long Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public long CityCode { get => cityCode; set => cityCode = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
    }
}
