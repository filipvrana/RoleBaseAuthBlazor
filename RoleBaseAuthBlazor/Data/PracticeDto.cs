namespace RoleBaseAuthBlazor.Data
{
    public class PracticeDto
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int Length { get; set; }
        public string Location { get; set; }
        public bool Attend { get; set; }
        public ICollection<BlazorUser> BlazorUsers { get; set; }
    }
}
