using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW10B.Model
{
    public class StudentInfo
    {
        public string Name { get; set; }    
        public StudentInfo(string name)
        {
            Name = name;
        }

        public  string PrintMyName()
        {
            return $"my name is {Name} "; 
        }
        public string PrintTodayInfo()
        {
            //TODO
            return "";
        }
    }
}
