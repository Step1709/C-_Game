using Entities;

namespace Scenes.EntityState2
{
    public class EnemyStateMachine : EntityStateMachine
    {
        public Enemy enemy;
        
        public EnemyAI EnemyAI;
        void Awake()
        {
            currentState = WaitingState.Instance;
        }

        void Start()
        {
            enemy = (Enemy)wrapper.Entity;
        }
        public override void ChangeState(IEntityState newState)
        {
            ((IEnemyState)currentState)?.Exit(this);
            ((IEnemyState)newState)?.Enter(this);
            currentState = newState;
        }
    }
}