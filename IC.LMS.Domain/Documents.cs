using IC.LMS.Domain.EnumContract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.LMS.Domain
{
    public class Documents
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentId { get; set; }
        public DocumentTypeId DocumentTypeID { get; set; }
        public int FK_PrimaryID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public virtual ProjectRequirement ProjectRequirement { get; set; }
    }
}
