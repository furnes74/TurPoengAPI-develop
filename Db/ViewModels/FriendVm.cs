namespace Db.ViewModels
{
    public class FriendVm
    {
        public int FriendId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public byte[] Picture { get; set; }

        public IdrettslagVm[] Idrettslag { get; set; }
    }
}
