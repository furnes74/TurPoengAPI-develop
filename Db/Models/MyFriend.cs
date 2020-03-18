
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db.Models
{
    public class MyFriend
    {
        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public Person Person { get; set; }

        [ForeignKey("Friend")]
        public int FriendId { get; set; }


        public Person Friend { get; set; }

        public bool Accepted { get; set; }
    }
}
