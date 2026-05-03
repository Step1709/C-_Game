using Scenes.EntityState2;
using UnityEngine;

namespace Entities
{
    public abstract class CheckDeath<TStateMachine> : MonoBehaviour where TStateMachine: StateMachine<TStateMachine>
    {
        private TStateMachine stateMachine;
        private Entity entity;
        
        protected abstract IState<TStateMachine> deathState { get; }
        void Start()
        {
            stateMachine = GetComponent<TStateMachine>();
            entity = GetComponent<EntityWrapper>().Entity;
        }

        void Update()
        {
            if (entity.Health<=0)
                stateMachine.ChangeState(deathState);
        }
    }
}