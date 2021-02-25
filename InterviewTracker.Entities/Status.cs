using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InterviewTracker.Entities
{
    /// <summary>
    /// This Enum define key value pair for User Status. its bind on User Status DropDownList
    /// </summary>
    public enum Status
    {
        Locked = 1,
        Bench = 2,
        [Display(Name = "In Training")]
        InTraining = 3,
        Released = 4
    }
}
