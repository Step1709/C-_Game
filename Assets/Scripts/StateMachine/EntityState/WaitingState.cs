using Entities;
using TailMap;
using UnityEngine;

namespace Scenes.EntityState
{
    public class WaitingState : IEntityState
    {
        public static WaitingState Instance { get; } = new WaitingState();
        
        public void Enter(GameObject entity)
        {
            if (entity.GetComponent<EntityWrapper>().Entity is MainPlayer)
            {
                EnterPlayer(entity);
            }
            else
            {
                EnterEnemy(entity);
            }
        }

        public void Exit(GameObject entity)
        {
            if (entity.GetComponent<EntityWrapper>().Entity is MainPlayer)
            {
                ExitPlayer(entity);
            }
            else
            {
                ExitEnemy(entity);
            }
        }

        private void EnterPlayer(GameObject player)
        {
            var tileMoving = player.GetComponent<TailGraph>();
            tileMoving.enabled = false;
        }

        private void EnterEnemy(GameObject enemy)
        {
        }
        
        private void ExitPlayer(GameObject player)
        {
        }

        private void ExitEnemy(GameObject enemy)
        {
        }
    }
}