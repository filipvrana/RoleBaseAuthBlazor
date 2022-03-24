using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoleBaseAuthBlazor.Data;

namespace RoleBaseAuthBlazor.MoneyServices
{

    public class MoneyService : IMoneyService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<BlazorUser> _userManager;

        public MoneyService(ApplicationDbContext context, UserManager<BlazorUser> userManager)
        {
            _dbContext = context;
            _userManager = userManager;
        }

        public void DeleteMoney(int id)
        {
            var money = _dbContext.Money.FirstOrDefault(x => x.Id == id);
            if (money != null)
            {
                _dbContext.Money.Remove(money);
                _dbContext.SaveChanges();
            }
        }

        public async Task AttendMoney(int id, string email)
        {
            var usr = await _userManager.FindByEmailAsync(email);
            var money = await _dbContext.Money.SingleOrDefaultAsync(x => x.Id == id);
            if (money == null)
                return;

            if (money.BlazorUsers == null)
            {
                money.BlazorUsers = new List<BlazorUser>();
            }
            if (money.BlazorUsers.Contains(usr))
            {
                money.BlazorUsers.Remove(usr);
            }
            else
            {
                money.BlazorUsers.Add(usr);
            }

            _dbContext.Money.Update(money);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Moneyy> GetMoneyById(int id)
        {
            var money = await _dbContext.Money.SingleOrDefaultAsync(x => x.Id == id);
            return money;
        }

        public Task<List<Moneyy>> GetMoney()
        {
            return _dbContext.Money.ToListAsync();
        }

        public void SaveMoney(Moneyy money)
        {
            if (money.Id == 0) _dbContext.Money.Add(money);
            else _dbContext.Money.Update(money);
            _dbContext.SaveChanges();
        }
    }
}
