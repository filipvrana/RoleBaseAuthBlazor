namespace RoleBaseAuthBlazor.Data
{
    public sealed class Practice
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int Length { get; set; }
        public string Location { get; set; }
        public ICollection<BlazorUser> BlazorUsers { get; set; }
    }
}
