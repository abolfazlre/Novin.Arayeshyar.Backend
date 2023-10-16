using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Arayeshyar.Backend.Core.Entities
{
    public class Dermatologist
    {
        public string MobileNumber { get; set; }
        public string MedicalDegree { get; set; }
        public string? Password { get; set; }
        public string? Fullname { get; set; }
        public DateTime? BirthDate { get; set; }
        public Dermatologist(string mobileNumber, string medicalDegree)
        {
            MobileNumber = mobileNumber;
            MedicalDegree = medicalDegree;
        }
    }
}
