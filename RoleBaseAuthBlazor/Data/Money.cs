namespace RoleBaseAuthBlazor.Data
{
    public sealed class Moneyy
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int Amount { get; set; }
        public ICollection<BlazorUser> BlazorUsers { get; set; }
    }
}
