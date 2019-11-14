using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RmgAPI.Models
{
    [Table("ListOfRequests")]
    public class ListOfRequests
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Number of Developers is Required")]
        public int NumOfDevelopers { get; set; }

        [Required(ErrorMessage = "Technology is Required")]
        public string Technology { get; set; }

        [Required(ErrorMessage = "Job Description is Required")]
        public string JobDescription { get; set; }

        [Required(ErrorMessage = "Start Date is Required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is Required")]
        public DateTime EndDate { get; set; }

        [ForeignKey("Account")]
        public int AccountID { get; set; }
    }
}
