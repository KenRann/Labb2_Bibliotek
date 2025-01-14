namespace Labb2_Bibliotek.Classes
{
    public class Member
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime RegisteredMembership {  get; set; }

        public ICollection<BookCheckout> BookCheckouts { get; set; } = new List<BookCheckout>();
    }
}
