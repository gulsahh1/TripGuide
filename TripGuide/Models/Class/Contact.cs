using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripGuide.Models.Class
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
    }
}
