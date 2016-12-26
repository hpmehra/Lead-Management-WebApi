using IC.LMS.Domain.EnumContract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC.LMS.Domain
{

    public class UserDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string fk_UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public Gender Gender { get; set; }
        public int? CountryId { get; set; }
        public DateTime? Dob { get; set; }
        
    }
    
  }