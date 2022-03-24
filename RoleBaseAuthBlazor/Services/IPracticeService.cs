using RoleBaseAuthBlazor.Data;

namespace RoleBaseAuthBlazor.Services
{
    public interface IPracticeService
    {
        Task<List<Practice>> GetPractices();
        Task<Practice> GetPracticeById(int id);
        void SavePractice(Practice practice);
        void DeletePractice(int id);
        Task AttendPractice(int id, string email);
    }
}
