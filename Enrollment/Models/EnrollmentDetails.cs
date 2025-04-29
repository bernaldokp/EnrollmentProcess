using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enrollments.Models
{
    public class EnrollmentDetails
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public double ContactNumber { get; set; }
        public string ID { get; set; }
        public Course Course { get; set; }
        public YearLevel YearLevel { get; set; }
        public Section Section { get; set; }
        public bool Status { get; set; }
    }
    public enum Course
    {
        ComputerScience,
        InformationTechnology,
        SoftwareEngineering,
        WebDevelopment,
        DataScience,
        CyberSecurity,
        NetworkEngineering,
        DatabaseManagement,
        MobileAppDevelopment,
        GameDevelopment,
        CloudComputing,
        ArtificialIntelligence,
        MachineLearning
    }
    public enum YearLevel
    {
        FirstYear,
        SecondYear,
        ThirdYear,
        FourthYear
    }
    public enum Section
    {
        A,
        B,
        C,
        D
    }
}