using RoleBaseAuthBlazor.Data;

namespace RoleBaseAuthBlazor.Services
{
    public interface IPracticeService
    {
        Task<List<PracticeDto>> GetPractices(string email);
        Task<PracticeDto> GetPracticeById(int id);
        Task SavePractice(PracticeDto practice);
        void DeletePractice(int id);
        Task AttendPractice(int id, string email);
    }
}
