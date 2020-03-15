using System;
using System.ComponentModel.DataAnnotations;

namespace Db.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }

        [MaxLength(11)]
        public string phoneNumber { get; set; }
        public bool isVisibleToOthers { get; set; }
        public byte[] Picture { get; set; }

        /*
        public DateTime Birth { get; set; }
        public bool showAsActiveUser { get; set; }*/

        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(4)]
        public string ZipCode { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(255)]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
       
        public IdrettslagMember[] Idrettslag { get; set; }

        public Pictures[] Pictures { get; set; }
    }
}
