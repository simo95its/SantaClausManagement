using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SantaClausManagement.Util
{
    public enum Status
    {
        [Display(Name = "In Progress")]
        InProgress = 0,
        [Display(Name = "Ready To Be Sent")]
        ReadyToBeSent = 1, //(if all thetoys requested are available)
        [Display(Name = "Done")]
        Done = 2
    }
}
