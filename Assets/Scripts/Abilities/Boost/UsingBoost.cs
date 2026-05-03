using System.Collections;
using Scenes.EntityState2;
using UnityEngine;

namespace Weapons
{
    public abstract class UsingBoost<TStateMachine> : MonoBehaviour where TStateMachine: StateMachine<TStateMachine>
    {
        [SerializeField] private TStateMachine stateMachine;
        protected abstract IState<TStateMachine> UsingAbility { get;}
        protected abstract IState<TStateMachine> Active { get;}
        
        void OnEnable()
        {
            UI.Screen.Instance.DamageShower.ShowDamage(stateMachine.wrapper.Entity, "рывок", Color.white, new Vector3(0,0.6f,0));
            stateMachine.ChangeState(UsingAbility);
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
            
            stateMachine.ChangeState(Active);
            enabled = false;
        }
    }
}