using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskProfile.ViewModels.Models
{
    public class DeleteCardModel
    {
        public Guid CardId { get; set; }
        public Guid UserId { get; set; }
    }
}
