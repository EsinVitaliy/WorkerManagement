using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WorkerManagementDAL.DataModel
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string FirstName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public bool SexIsMale { get; set; }

        [Required]
        public bool ChildrenExists { get; set; }
    }
}
