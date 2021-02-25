using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace InterviewTracker.Entities
{
    public class ApplicationUser
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string UserId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "First Name Cannot exceed 50 Characters")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "Last Name Cannot exceed 50 Characters")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"[a-z0-9][-a-z0-9._]+@([-a-z0-9]+[.])+[a-z]{2,5}$", ErrorMessage = "Invalid Email Format")]
        [Display(Name = "Emai Address")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Reporting To")]
        public string ReportingTo { get; set; }
        [Required]
        [Display(Name = "User Type")]
        public UserType? UserTypes { get; set; }
        [Required]
        [Display(Name = "User Status")]
        public Status? Stat { get; set; }
        [Required]
        [Display(Name = "Mobile")]
        public long MobileNumber { get; set; }
    }
}
