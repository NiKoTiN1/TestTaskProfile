using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskProfile.ViewModels.Models
{
    public class GetCardModel : AddCardModel
    {
        public Guid Id { get; set; }
    }
}
