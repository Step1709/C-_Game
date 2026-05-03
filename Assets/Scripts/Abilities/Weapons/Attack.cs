using System.Collections;
using System.Collections.Generic;
using Entities;
using Scenes;
using Scenes.EntityState2;
using UnityEngine;
using Weapons;

namespace Abilities
{
    public abstract class Attack<TEntity, TStateMachine> : MonoBehaviour where TEntity : Entity<TEntity>
    where TStateMachine: StateMachine<TStateMachine>
    {
        public Vector3 targetPosition;
        public Entity target;
        public List<Vector3Int> pathToTarget;
        public TEntity self;
        public Move<TStateMachine> move;
        private bool startAttack;
        
        [SerializeField] private Animator animator;
        
        [SerializeField]
        private TStateMachine stateMachine;
        
        protected abstract IState<TStateMachine> UsingAbility { get;}
        protected abstract IState<TStateMachine> Active { get;}
        void OnEnable()
        {
            startAttack = false;
            stateMachine.ChangeState(UsingAbility);
            if (pathToTarget.Count != 0)
            {
                move.isUsed = true;
                move.path = pathToTarget;
                move.enabled = true;
            }
        }

        void Update()
        {
            if (move.enabled || startAttack) return;
            animator.Play(((Weapon)self.currentAbility).AnimationName);
            StartCoroutine(WaitForAnimationEnd());
            startAttack = true;
        }
        
        IEnumerator WaitForAnimationEnd()
        {
            while (!animator.GetCurrentAnimatorStateInfo(0).IsName(((Weapon)self.currentAbility).AnimationName))
            {
                yield return null;
            }
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            while (stateInfo.normalizedTime < 1.0f)
            {
                yield return null;
                stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            }

            Debug.Log("анимация кончилась");
            ((Weapon)self.currentAbility).Attack(self, target, targetPosition);
            self.MainActionPoint--;
            stateMachine.ChangeState(Active);
            enabled = false;
        }
    }
}