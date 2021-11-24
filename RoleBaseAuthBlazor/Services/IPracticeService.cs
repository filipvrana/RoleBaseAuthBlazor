using RoleBaseAuthBlazor.Data;

namespace RoleBaseAuthBlazor.Services
{
    public interface IPracticeService
    {
        List<Practice> GetPractices();
        Practice GetPracticeById(int id);
        void SavePractice(Practice practice);
        void DeletePractice(int id);
    }
}
