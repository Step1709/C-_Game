namespace Scenes.EntityState2
{
    public class EnemyStateMachine : EntityStateMachine
    {
        public override void ChangeState(IEntityState newState)
        {
            currentState.Exit(this);
            newState.Enter(this);
            currentState = newState;
        }
    }
}