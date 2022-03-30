namespace RoleBaseAuthBlazor.Data
{
    public sealed class PracticeAttendancee
    {
        public string BlazorUserId { get; set; }
        public BlazorUser BlazorUser { get; set; }
        public int PracticeId { get; set; }
        public Practice Practice { get; set; }
    }
}
