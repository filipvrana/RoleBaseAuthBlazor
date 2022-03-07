using RoleBaseAuthBlazor.Data;

namespace RoleBaseAuthBlazor.GameServices
{

    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _dbContext;
        public GameService(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public void DeleteGame(int id)
        {
            var game = _dbContext.Games.FirstOrDefault(x => x.Id == id);
            if (game != null)
            {
                _dbContext.Games.Remove(game);
                _dbContext.SaveChanges();
            }
        }

        public Game GetGameById(int id)
        {
            var game = _dbContext.Games.SingleOrDefault(x => x.Id == id);
            return game;
        }

        public List<Game> GetGames()
        {
            return _dbContext.Games.ToList();
        }

        public void SaveGame(Game game)
        {
            if (game.Id == 0) _dbContext.Games.Add(game);
            else _dbContext.Games.Update(game);
            _dbContext.SaveChanges();
        }
    }
}
