using Entities;
using Scenes.Scene;
using TailMap;
using UnityEngine;

namespace Scenes.EntityState
{
    public class ActiveState : IEntityState
    {
        public static ActiveState Instance { get; } = new ActiveState();
        
        public void Enter(GameObject entity)
        {
            CameraClass.Instance.ChosenEntity = entity;
            entity.GetComponent<FinishMove>().enabled = true;
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
            entity.GetComponent<FinishMove>().enabled = false;
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
            tileMoving.enabled = true;
        }

        private void EnterEnemy(GameObject enemy)
        {
        }
        
        private void ExitPlayer(GameObject player)
        {
            var tileMoving = player.GetComponent<TailGraph>();
            tileMoving.enabled = false;
        }

        private void ExitEnemy(GameObject enemy)
        {
        }
    }
}