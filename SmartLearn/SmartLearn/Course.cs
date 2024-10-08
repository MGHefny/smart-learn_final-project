//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartLearn
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.Course_Lessons = new HashSet<Course_Lessons>();
            this.Trainee_Courses = new HashSet<Trainee_Courses>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public System.DateTime Creation_Date { get; set; }
        public string Description { get; set; }
        public int Categrory_Id { get; set; }
        public Nullable<int> Trainer_Id { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course_Lessons> Course_Lessons { get; set; }
        public virtual Trainer Trainer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainee_Courses> Trainee_Courses { get; set; }
    }
}
