using System.Collections;
using System.Collections.Generic;
using Entities;
using Scenes;
using Scenes.EntityState2;
using UnityEngine;
using Weapons;

namespace Abilities
{
    public class Attack<TEntity> : MonoBehaviour where TEntity : Entity<TEntity>
    {
        public Vector3 targetPosition;
        public Entity target;
        public List<Vector3Int> pathToTarget;
        public Entity<TEntity> self;
        public Move move;
        private bool startAttack;
        
        [SerializeField] private Animator animator;
        
        [SerializeField]
        private EntityStateMachine stateMachine;
        void OnEnable()
        {
            startAttack = false;
            stateMachine.ChangeState(UsingAbilityState.Instance);
            if (pathToTarget.Count != 0)
            {
                move.isUsed = true;
                move.path = pathToTarget;
                move.enabled = true;
            }
        }

        void Update()
        {
            if (!move.enabled && !startAttack)
            {
                animator.Play(((Weapon)self.currentAbility).AnimationName);
                StartCoroutine(WaitForAnimationEnd());
                startAttack = true;
            }
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
            stateMachine.ChangeState(ActiveState.Instance);
            enabled = false;
        }
    }
}