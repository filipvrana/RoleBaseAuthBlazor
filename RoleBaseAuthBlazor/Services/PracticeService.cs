using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoleBaseAuthBlazor.Data;

namespace RoleBaseAuthBlazor.Services
{

    public class PracticeService : IPracticeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<BlazorUser> _userManager;

        public PracticeService(ApplicationDbContext context, UserManager<BlazorUser> userManager)
        {
            _dbContext = context;
            _userManager = userManager;
        }

        public void DeletePractice(int id)
        {
            var practice = _dbContext.Practices.FirstOrDefault(x => x.Id == id);
            if (practice != null)
            {
                _dbContext.Practices.Remove(practice);
                _dbContext.SaveChanges();
            }
        }

        public async Task AttendPractice(int id, string email)
        {
            var usr = await _userManager.FindByEmailAsync(email);
            var practice = await _dbContext.Practices.SingleOrDefaultAsync(x => x.Id == id);
            if (practice == null)
                return;

            if (practice.BlazorUsers == null)
            {
                practice.BlazorUsers = new List<BlazorUser>();
            }
            if (practice.BlazorUsers.Contains(usr))
            {
                practice.BlazorUsers.Remove(usr);
            }
            else
            {
                practice.BlazorUsers.Add(usr);
            }

            _dbContext.Practices.Update(practice);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Practice> GetPracticeById(int id)
        {
            var practice = await _dbContext.Practices.SingleOrDefaultAsync(x => x.Id == id);
            return practice;
        }

        public Task<List<Practice>> GetPractices()
        {
            return _dbContext.Practices.ToListAsync();
        }

        public void SavePractice(Practice practice)
        {
            if (practice.Id == 0) _dbContext.Practices.Add(practice);
            else _dbContext.Practices.Update(practice);
            _dbContext.SaveChanges();
        }
    }
}
