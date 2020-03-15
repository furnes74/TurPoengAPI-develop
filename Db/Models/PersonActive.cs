using System;

namespace Db.Models
{
    public class PersonActive
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public DateTime LastActiveTime { get; set; }
    }
}
