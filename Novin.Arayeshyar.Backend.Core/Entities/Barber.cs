using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Arayeshyar.Backend.Core.Entities
{
    public class Barber
    {
        public string MobileNumber { get; set; }
        public string? Password { get; set; }
        public string? Fullname { get; set; }
        public string? Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public Barber(string mobileNumber)
        {
            MobileNumber = mobileNumber;
        }
    }
}
