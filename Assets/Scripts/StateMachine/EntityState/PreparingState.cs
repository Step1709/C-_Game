using TailMap;
using UnityEngine;

namespace Scenes.EntityState
{
    public class PreparingState : IEntityState
    {
        public static PreparingState Instance { get; } = new PreparingState();
        
        public void Enter(GameObject player)
        {
            var tileMoving = player.GetComponent<TailGraph>();
            tileMoving.enabled = true;
            var baseHandler  = player.GetComponent<PlayerBaseHandler>();
            baseHandler.enabled = true;
        }

        public void Exit(GameObject player)
        {
            var tileMoving = player.GetComponent<TailGraph>();
            tileMoving.enabled = false;
            var baseHandler  = player.GetComponent<PlayerBaseHandler>();
            baseHandler.enabled = false;
        }
    }
}