namespace RoleBaseAuthBlazor.Data
{
    public sealed class Moneyy
    {
        public int Id { get; set; }
        public string BlazorUserId { get; set; }
        public BlazorUser BlazorUser { get; set; }
        public static DateTime? Date { get; set; }
        public static int Amount { get; set; }
        public ICollection<BlazorUser> BlazorUsers { get; set; }
    }
}
