namespace RoleBaseAuthBlazor.Data
{
    public class PracticeAttendance
    {
        public string BlazorUserId { get; set; }
        public BlazorUser BlazorUser { get; set; }
        public int PracticeId { get; set; }
        public Practice Practice { get; set; }
    }
}
