using System.Collections;
using Scenes.EntityState2;
using UnityEngine;

namespace Weapons
{
    public class UsingBoost : MonoBehaviour
    {
        [SerializeField] private EntityStateMachine stateMachine;
        void OnEnable()
        {
            UI.Screen.Instance.DamageShower.ShowDamage(stateMachine.wrapper.Entity, "рывок", Color.white);
            stateMachine.ChangeState(UsingAbilityState.Instance);
            StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            int timer = 1;
            
            while(timer > 0)
            {
                yield return new WaitForSeconds(1f);
                timer--;
            }

            stateMachine.wrapper.Entity.CurrentTileCount += 3;
            stateMachine.wrapper.Entity.MainActionPoint--;
            
            stateMachine.ChangeState(ActiveState.Instance);
            enabled = false;
        }
    }
}