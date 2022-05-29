using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USIP.Model
{
    public class CourseSubject
    {
        public int Id { get; set; }
        public int IdSubject { get; set; }
        public int IdCourse { get; set; }
        //public virtual Subject Subject { get; set; }
        //public virtual Course Course { get; set; }
    }
}
