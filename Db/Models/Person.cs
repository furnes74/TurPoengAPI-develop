using System;
using System.Collections.Generic;
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
        public string PhoneNumber { get; set; }
        
        public bool IsVisibleToOthers { get; set; }

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
       
        public List<IdrettslagMember> IdrettslagMember { get; set; }

        public List<Pictures> Pictures { get; set; }

        public List<MyFriend> MyFriends { get; set; }

        public List<Post> SuggestedPosts { get; set; }
    }

}
