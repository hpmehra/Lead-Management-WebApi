using IC.LMS.Domain.EnumContract;
using System;

namespace IC.LMS.Domain.Dto
{
    public class CompanyInfoDto
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int? CompanyTinNo { get; set; }    
        public string CompanyWebsite { get; set; }
        public string SourceName { get; set; }    
        public int? SuccessScore { get; set; }
        public Status? Status { get; set; }
        public int CompanyContactId { get; set; }
        public string CompanyAddress { get; set; }      
        public string CompanyContactNo { get; set; }      
        public int FaxNo { get; set; }
        public string PostalCode { get; set; }
        public string CompanyEmailId { get; set; }
        public int CountryId { get; set; }
        public int PersonId { get; set; }      
        public string PrimaryPersonName { get; set; }
        public string SecondaryPersonName { get; set; }
        public string PrimaryPersonSkypeId { get; set; }     
        public string SecondaryPersonSkypeId { get; set; }
        public string PrimaryPersonEmailId { get; set; }
        public string SecondaryPersonEmailId { get; set; }
        public string PrimaryPersonContactNo { get; set; }
        public string SecondaryPersonContactNo { get; set; }
        public int TimeZone { get; set; }
        public string LinkedInUrl { get; set; }
        public Priority? Priority { get; set; }      
        public string ContactChannel { get; set; }
        public Stage? Stage { get; set; }
        public string DeadReason { get; set; }
        public string Creator { get; set; }
        public DateTime CreateOn { get; set; }
        public int? EnggOwner { get; set; }
        public int? SalesOwner { get; set; }
        public string Tags { get; set; }
        public string Unavaible { get; set; }
        public Gender Gender { get; set; }
    }
}
