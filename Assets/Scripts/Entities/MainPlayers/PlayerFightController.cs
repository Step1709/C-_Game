using Abilities;
using Scenes;
using Scenes.EntityState2;
using UnityEngine;

namespace Entities.MainPlayers
{
    public class PlayerFightController : MonoBehaviour
    {
        public MainPlayer player;
        [SerializeField]
        private PlayerStateMachine stateMachine;

        [SerializeField] private EntityWrapper wrapper;

        void Start()
        {
            player = (MainPlayer)wrapper.Entity;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                player.ChangeAbility(NoAbility.Instance);
                Debug.Log("убрали все");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                player.ChangeAbility(player.CurrentWeapon);
                Debug.Log("взяли оружие");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                player.ChangeAbility(player.CurrentHealWeapon);
                Debug.Log("взяли хилку");
            }
            else if (Input.GetMouseButtonDown(1))
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