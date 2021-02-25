using InterviewTracker.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace InterviewTracker.BusinessLayer.ViewModels
{
    public class InterviewViewModel
    {
        [Required]
        [Display(Name = "Interview Name")]
        [MaxLength(50, ErrorMessage = "Interview Name Cannot exceed 50 Characters")]
        public string InterviewName { get; set; }
        [Required]
        [Display(Name = "Interviewer")]
        public string Interviewer { get; set; }
        [Required]
        [Display(Name = "Interview For")]
        public string InterviewUser { get; set; }
        [Required]
        [Display(Name = "User Skills")]
        public string UserSkills { get; set; }
        [Required]
        [Display(Name = "Interview Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InterviewDate { get; set; }
        [Required]
        [Display(Name = "Interview Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        public DateTime InterviewTime { get; set; }
        [Required]
        [Display(Name = "Interview Status")]
        public InterviewStatus? InterViewsStatus { get; set; }
        [Required]
        [Display(Name = "Techinical Status")]
        public TechnicalInterviewStatus? TInterViews { get; set; }
        public IEnumerable<Interview> Interviews { get; set; }
        public int InterviewPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Interviews.Count() / (double)InterviewPerPage));
        }
        public IEnumerable<Interview> PaginatedInterview()
        {
            int start = (CurrentPage - 1) * InterviewPerPage;
            return Interviews.OrderBy(b => b.InterviewId).Skip(start).Take(InterviewPerPage);
        }
    }
}
