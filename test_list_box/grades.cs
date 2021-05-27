using System;
using System.Collections.Generic;
using System.Text;

namespace test_list_box
{
    public class grades
    {
        private long id;
        private int math;
        private int english;
        private int comp;


        public grades()
        {
            Id = 0;
            Math = 0;
            English = 0;
            Comp = 0;
        }

        public long Id { get => id; set => id = value; }
        public int Math { get => math; set => math = value; }
        public int English { get => english; set => english = value; }
        public int Comp { get => comp; set => comp = value; }
    }

    
}
