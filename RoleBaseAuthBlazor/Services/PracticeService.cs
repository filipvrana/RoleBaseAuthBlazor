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
            var practice = await _dbContext.Practices.Include(a => a.BlazorUsers)
                .SingleOrDefaultAsync(x => x.Id == id);

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

        public async Task<PracticeDto> GetPracticeById(int id)
        {
            var prac = await _dbContext.Practices.Include(a => a.BlazorUsers)
                .SingleOrDefaultAsync(x => x.Id == id);

            var ss = new PracticeDto
            {
                BlazorUsers = prac.BlazorUsers,
                Date = prac.Date,
                Id = prac.Id,
                Length = prac.Length,
                Location = prac.Location
            };

            return ss;
        }

        public async Task<List<PracticeDto>> GetPractices(string email)
        {
            //var practices = await _dbContext.Practices.ToListAsync();
            var practices = await _dbContext.Practices.Include(a => a.BlazorUsers).ToListAsync();
            var practicesDto = new List<PracticeDto>();
            foreach (var prac in practices)
            {
                var ss = new PracticeDto
                {
                    BlazorUsers = prac.BlazorUsers,
                    Attend = prac.BlazorUsers == null ? false : prac.BlazorUsers.Any(x => x.UserName == email),
                    Date = prac.Date,
                    Id = prac.Id,
                    Length = prac.Length,
                    Location = prac.Location
                };

                practicesDto.Add(ss);
            }
            return practicesDto;
        }

        public async Task SavePractice(PracticeDto practiceDto)
        {
            var practice = new Practice
            {
                Date = practiceDto.Date,
                BlazorUsers = practiceDto.BlazorUsers,
                Length = practiceDto.Length,
                Location = practiceDto.Location,
                Id = practiceDto.Id
            };
            if (practice.Id == 0)
                _dbContext.Practices.Add(practice);
            else _dbContext.Practices.Update(practice);
            await _dbContext.SaveChangesAsync();
        }
    }
}
