using Entities;

namespace Scenes.EntityState2
{
    public interface IState<in TStateMachine> where TStateMachine : EntityStateMachine
    {
        void Enter(TStateMachine stateMachine);
        void Exit(TStateMachine stateMachine);
    }
}