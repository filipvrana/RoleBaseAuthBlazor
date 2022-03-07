namespace RoleBaseAuthBlazor.Data
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Score { get; set; }
        public string Result { get; set; }

        public string Rival { get; set; }
    }
}
