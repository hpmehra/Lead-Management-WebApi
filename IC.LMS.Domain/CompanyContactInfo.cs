using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.LMS.Domain
{
    public class CompanyContactInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyContactId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyAddress { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public int?FaxNo { get; set; }
        public string PostalCode { get; set; }
        public string LinkedInUrl { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual CompanyInfo CompanyInfo { get; set; }

    }
}
