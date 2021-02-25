using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InterviewTracker.Entities
{
    public enum UserType
    {
        /// <summary>
        /// This Enum define key value for User Type. 
        /// its bind on User Type DropDownList
        /// </summary>
        Trainee,
        [Display(Name = "Trainee Intern")]
        TraineeIntern,
        Manager,
        Developer,
        [Display(Name = "Fresher Associate")]
        FresherAssociate,
        TeamLead,
        [Display(Name = "Fresher Associate")]
        TeamSupervisor,
        [Display(Name = "Delivery Lead")]
        DeliveryLead,
        [Display(Name = "Production Lead")]
        ProductionLead,
        [Display(Name = "Not Assigned")]
        NotAssigned
    }
}
