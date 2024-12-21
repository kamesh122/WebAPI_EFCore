using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string? DeptName { get; set; }
        public string? Location { get; set; }

        [JsonIgnore]
        public  virtual IEnumerable<Employee> Employees { get; set; }
    }
}
