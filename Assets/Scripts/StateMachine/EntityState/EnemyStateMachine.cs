using Entities;

namespace Scenes.EntityState2
{
    public class EnemyStateMachine : StateMachine<EnemyStateMachine>
    {
        public Enemy enemy;

        public EnemyAI EnemyAI;

        void Start()
        {
            enemy = (Enemy)wrapper.Entity;
        }
        public override void ToActiveState() => ChangeState(ActiveState.Instance);
        public override bool IsFinishedTurn => 
            currentState == WaitingState.Instance || currentState == DeathState.Instance;
    }
}