namespace Scenes
{
    public class GameModel
    {
        public static GameModel Instance { get; } = new GameModel();

        public Ashen Ashen = Ashen.Instance;
        public Biv Biv = Biv.Instance;

        public MainPlayer[] MainPlayers;
        
        public MainPlayer ChosenPlayer;
        
        public GameModel()
        {
            MainPlayers = new MainPlayer[] { Ashen, Biv };
            ChosenPlayer = Ashen;
        }
    }
}