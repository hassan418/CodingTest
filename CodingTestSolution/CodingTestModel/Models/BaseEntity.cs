using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodingTestModel.Models
{
    public class baseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string Updatedby { get; set; }
    }
}
