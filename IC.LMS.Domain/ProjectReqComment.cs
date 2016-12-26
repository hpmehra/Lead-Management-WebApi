using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.LMS.Domain
{
    public class ProjectReqComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public int ProjectReqId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public virtual ProjectRequirement ProjectRequirement { get; set; }

    }
}
