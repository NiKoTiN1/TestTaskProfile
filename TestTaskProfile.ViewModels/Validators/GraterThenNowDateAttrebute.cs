using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskProfile.ViewModels.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class GraterThenNowDateAttrebute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            if (!(value is DateTime))
            {
                throw new ArgumentException("The value must be a DateTime.", nameof(value));
            }

            var date = (DateTime)value;
            return date > DateTime.Now;
        }
    }
}
