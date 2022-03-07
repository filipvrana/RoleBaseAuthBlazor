using RoleBaseAuthBlazor.Data;

namespace RoleBaseAuthBlazor.Services
{

    public class PracticeService : IPracticeService
    {
        private readonly ApplicationDbContext _dbContext;
        public PracticeService(ApplicationDbContext context)
        {
            _dbContext = context;
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

        public Practice GetPracticeById(int id)
        {
            var practice = _dbContext.Practices.SingleOrDefault(x => x.Id == id);
            return practice;
        }

        public List<Practice> GetPractices()
        {
            return _dbContext.Practices.ToList();
        }

        public void SavePractice(Practice practice)
        {
            if (practice.Id == 0) _dbContext.Practices.Add(practice);
            else _dbContext.Practices.Update(practice);
            _dbContext.SaveChanges();
        }
    }
}
