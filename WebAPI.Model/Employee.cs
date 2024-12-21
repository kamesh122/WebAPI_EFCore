using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class Employee
    {
        [Key]
        public int Empno { get; set; }
        public string? Ename { get; set; }
        public string? Job { get; set; }
        public int? MGR { get; set; }
        public DateTime? Hiredate { get; set; }
        public decimal? Salary { get; set; }
        public decimal? Commission { get; set; }

        public int DeptId { get; set; }
        //Navigation property
        public virtual Department Department { get; set; }
    }
}
