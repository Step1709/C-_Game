using Scenes.EntityState2;
using UnityEngine;

namespace Entities
{
    public class CheckDeath : MonoBehaviour
    {
        private EntityStateMachine stateMachine;
        private Entity entity;
        void Start()
        {
            stateMachine = GetComponent<EntityStateMachine>();
            entity = GetComponent<EntityWrapper>().Entity;
        }

        void Update()
        {
            if (entity.Health<=0)
                stateMachine.ChangeState(DeathState.Instance);
        }
    }
}