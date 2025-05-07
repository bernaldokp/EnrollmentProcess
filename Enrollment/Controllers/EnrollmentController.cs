using Enrollments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enrollment.Controllers
{
    public class EnrollmentController : Controller
    {
        private static List<EnrollmentDetails> enrollments = new List<EnrollmentDetails>()
        {
            new EnrollmentDetails(){  Course= Course.SoftwareEngineering, Name = "John Doe", DateOfBirth = new DateTime(2000, 1, 1), Age = 23, Address = "123 Main St", ContactNumber = 123-456-7890, ID = "001",  Status = true},
            new EnrollmentDetails(){Course= Course.ComputerScience, Name = "Jane Smith", DateOfBirth = new DateTime(1999, 2, 2), Age = 24, Address = "456 Elm St", ContactNumber = 987 - 654 - 3210, ID = "002", Status = true},
            new EnrollmentDetails(){ Course= Course.ArtificialIntelligence,Name = "Alice Johnson", DateOfBirth = new DateTime(2001, 3, 3), Age = 22, Address = "789 Oak St", ContactNumber = 555 - 555 - 5555, ID = "003", Status = true},
            new EnrollmentDetails(){Course = Course.MobileAppDevelopment, Name = "Bob Brown", DateOfBirth = new DateTime(2002, 4, 4), Age = 21, Address = "321 Pine St", ContactNumber = 444 - 444 - 4444, ID = "004", Status = true},
            new EnrollmentDetails(){Course = Course.SoftwareEngineering, Name = "Charlie Davis", DateOfBirth = new DateTime(2003, 5, 5), Age = 20, Address = "654 Maple St", ContactNumber = 333 - 333 - 3333, ID = "005", Status = true},
        };
        

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Enrollment(string ID)
        {
            var user = enrollments.FirstOrDefault(e => e.ID == ID);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        public ActionResult Details(string id)
        {
            var user = enrollments.FirstOrDefault(e => e.ID == id.ToString());
            return View(user);
        } 
        public ActionResult EnrollmentProcess()
        {
            return View(enrollments);
        }
        [HttpPost]
        public ActionResult EnrollNewUser(EnrollmentDetails enrollment)
        {

            enrollments.Add(new EnrollmentDetails()
            {
                Name = enrollment.Name,
                DateOfBirth = enrollment.DateOfBirth,
                Age = enrollment.Age,
                Address = enrollment.Address,
                ContactNumber = enrollment.ContactNumber,
                ID = enrollment.ID,
                Course = enrollment.Course,
                YearLevel = enrollment.YearLevel,
                Section = enrollment.Section,
                Status = true
            });
            return RedirectToAction("Enrollments");
        }
        public ActionResult Search(EnrollmentDetails searchDetails)
        {
            var User = enrollments.Where(e =>

            (searchDetails.Name == null || e.Name.ToUpper().Contains(searchDetails.Name.ToUpper()))
            &&
                (searchDetails.Course == Course.None || e.Course == searchDetails.Course)).ToList();

            return View("EnrollmentProcess", User);
        }

        [HttpPost]
        public ActionResult UpdateEnrollment(EnrollmentDetails enrollment)
        {
            var existingEnrollment = enrollments.FirstOrDefault(e => e.ID == enrollment.ID);
            if (existingEnrollment != null)
            {
                existingEnrollment.Name = enrollment.Name;
                existingEnrollment.DateOfBirth = enrollment.DateOfBirth;
                existingEnrollment.Age = enrollment.Age;
                existingEnrollment.Address = enrollment.Address;
                existingEnrollment.ContactNumber = enrollment.ContactNumber;
                existingEnrollment.Course = enrollment.Course;
                existingEnrollment.YearLevel = enrollment.YearLevel;
                existingEnrollment.Section = enrollment.Section;
            }
            return RedirectToAction("EnrollmentDetails");
        }
        [HttpPost]
        public ActionResult DeleteEnrollment(string ID)
        {
            var enrollment = enrollments.FirstOrDefault(e => e.ID == ID);
            if (enrollment != null)
            {
                enrollments.Remove(enrollment);
            }
            return RedirectToAction("EnrollmentDetails");
        }
    }
}