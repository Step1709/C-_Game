using System.Collections.Generic;
using Entities;
using Scenes.EntityState2;
using UnityEngine;
using Weapons;

namespace Abilities
{
    public class Attack : MonoBehaviour
    {
        public Vector3 targetPosition;
        public Entity target;
        public List<Vector3Int> pathToTarget;
        public Entity self;
        public Move move;
        
        [SerializeField]
        private EntityStateMachine stateMachine;
        void OnEnable()
        {
            stateMachine.ChangeState(AttackState.Instance);
            if (targetPosition != gameObject.transform.position && target?.GameObject != gameObject)
            {
                move.isUsed = true;
                move.path = pathToTarget;
                move.enabled = true;
            }
        }

        void Update()
        {
            if (!move.enabled)
            {
                ((Weapon)self.currentAbility).Attack(self, target, targetPosition);
                self.MainActionPoint--;
                stateMachine.ChangeState(ActiveState.Instance);
                enabled = false;
            }
        }
    }
}