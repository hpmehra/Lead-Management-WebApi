using IC.LMS.Domain.EnumContract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.LMS.Domain
{
  
    public class CompanyPersonContact
    {
              
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        public int CompanyId { get; set; }
        public string PersonName { get; set; }
        public string EmailId { get; set; }    
        public string ContactNo { get; set; }       
        public string SkypeId { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public bool IsPrimary { get; set; }
        [ForeignKey("CompanyId")]
        public virtual CompanyInfo CompanyInfo { get; set; }

    }
}
