using Scenes;
using Scenes.EntityState2;
using UnityEngine;

namespace Entities.MainPlayers
{
    public class PlayerFightController : MonoBehaviour
    {
        [SerializeField]
        private PathController pathController;
        [SerializeField]
        private PlayerStateMachine stateMachine;

        public MainPlayer player;

        void Update()
        {
            if (Input.GetMouseButtonDown(1) && pathController.path != null)
            {
                if (player.MainActionPoint <=0 && pathController.target!=null)
                    Debug.Log("нет очков основного действия");
                else
                    stateMachine.ChangeState(PlayerActionState.Instance);
            }
        }
    }
}