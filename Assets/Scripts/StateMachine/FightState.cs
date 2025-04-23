using Fighting;

namespace Scenes
{
    public class FightState : IState
    {
        public static FightState Instance { get; } = new FightState();
        
        public FightManager fightManager = GameModel.Instance.GameModelObject.GetComponent<FightManager>();
        public void Enter()
        {
            fightManager.enabled = true;
        }

        public void Exit()
        {
            fightManager.enabled = false;
        }
    }
}