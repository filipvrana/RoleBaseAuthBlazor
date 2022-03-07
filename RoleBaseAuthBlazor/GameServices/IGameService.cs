using RoleBaseAuthBlazor.Data;

namespace RoleBaseAuthBlazor.GameServices
{
    public interface IGameService
    {
        List<Game> GetGames();
        Game GetGameById(int id);
        void SaveGame(Game game);
        void DeleteGame(int id);
    }
}
