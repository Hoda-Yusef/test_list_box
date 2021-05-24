using System;
using System.Collections.Generic;
using System.Text;

namespace test_list_box
{
    public class city
    {
        private long cityCode;
        private string cityName;

        public city()
        {
            cityCode = 0;
            cityName = string.Empty;
        }

        public string CityName { get => cityName; set => cityName = value; }
        public long CityCode { get => cityCode; set => cityCode = value; }
    }
}
