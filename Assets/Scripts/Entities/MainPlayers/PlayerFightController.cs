using Abilities;
using Scenes;
using Scenes.EntityState2;
using UnityEngine;

namespace Entities.MainPlayers
{
    public class PlayerFightController : MonoBehaviour
    {
        private MainPlayer player;
        [SerializeField]
        private PlayerStateMachine stateMachine;

        [SerializeField] private EntityWrapper wrapper;

        void Start()
        {
            player = (MainPlayer)wrapper.Entity;
        }

        void Update()
        {
            if (GameModel.Instance.OnPause) return;
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                player.ChangeAbility(player.Abilities[0]);
                player.AbilityIndex = 0;
                Debug.Log("убрали все");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                player.ChangeAbility(player.Abilities[1]);
                player.AbilityIndex = 1;
                Debug.Log("взяли оружие");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                player.ChangeAbility(player.Abilities[2]);
                player.AbilityIndex = 2;
                Debug.Log("взяли хилку");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                player.ChangeAbility(player.Abilities[3]);
                player.AbilityIndex = 3;
                Debug.Log("взяли рывок");
            }
            else if (Input.GetMouseButtonDown(0))
            {
                player.UseAbility(player.currentAbility);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.ChangeState(WaitingState.Instance);
            }
        }
    }
}