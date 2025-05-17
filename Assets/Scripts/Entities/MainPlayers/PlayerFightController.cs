using Abilities;
using Scenes;
using Scenes.EntityState2;
using UnityEngine;

namespace Entities.MainPlayers
{
    public class PlayerFightController : MonoBehaviour
    {
        public MainPlayer player;

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
            if (Input.GetMouseButtonDown(1))
            {
                player.UseAbility(player.currentAbility);
            }
        }
    }
}