namespace CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeesSalary")]
    public partial class EmployeesSalary
    {
        [Key]
        [Column("Full Name", Order = 0)]
        [StringLength(101)]
        public string Full_Name { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "money")]
        public decimal Salary { get; set; }
    }
}
