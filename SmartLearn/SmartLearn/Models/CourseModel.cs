using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SmartLearn.Models
{
    public class CourseModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public System.DateTime Creation_Date { get; set; }
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }

        [Required]
        [Display(Name = "Trainer")]
        public Nullable<int> Trainer_Id { get; set; }
        public string TrainerName { get; set; }

        public SelectList Trainers { get; set; }
        public SelectList Categories { get; set; }
    }
}