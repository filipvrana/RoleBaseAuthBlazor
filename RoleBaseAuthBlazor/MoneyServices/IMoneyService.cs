using RoleBaseAuthBlazor.Data;

namespace RoleBaseAuthBlazor.MoneyServices
{
    public interface IMoneyService
    {
        Task<List<Moneyy>> GetMoney();
        Task<Moneyy> GetMoneyById(int id);
        void SaveMoney(Moneyy money);
        void DeleteMoney(int id);
        Task AttendMoney(int id, string email);
    }
}
