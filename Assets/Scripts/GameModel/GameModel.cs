using Scenes.Scene;

namespace Scenes
{
    public class GameModel
    {
        public static GameModel Instance { get; } = new GameModel();

        public Ashen Ashen = Ashen.Instance;
        public Biv Biv = Biv.Instance;

        public MainPlayer[] MainPlayers;
        
        public MainPlayer ChosenPlayer;

        public SceneClass SampleScene;
        
        public GameModel()
        {
            MainPlayers = new MainPlayer[] { Ashen, Biv };
            ChosenPlayer = Ashen;
        }
    }
}