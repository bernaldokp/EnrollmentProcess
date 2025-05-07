using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enrollment.Models
{
    public class  SchoolCourse
    {
        public string CourseId { get; set; }       // e.g., "CS101"
        public string CourseName { get; set; }     // e.g., "Introduction to Computer Science"
        public string Description { get; set; }    // Optional course description
        public int Credits { get; set; }           // e.g., 3 or 4
        public string Instructor { get; set; }     // Name of the instructor

      
    }


    //CR U* D MVC
    
}