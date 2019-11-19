using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentMVC.Models
{
    public class StudentVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please Enter your name")]
        public string Name { get; set; }
        public string Class { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}