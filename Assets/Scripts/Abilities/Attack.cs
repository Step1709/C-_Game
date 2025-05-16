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
        public GameObject target;
        public List<Vector3Int> pathToTarget;
        public Entity self;
        public Move move;
        void OnEnable()
        {
            gameObject.GetComponent<EntityStateMachine>().ChangeState(AttackState.Instance);
            move.isUsed = true;
            move.path = pathToTarget;
            move.enabled = true;
        }

        void Update()
        {
            if (!move.enabled)
            {
                ((Weapon)self.currentAbility).Attack(self, target?.GetComponent<EntityWrapper>().Entity, targetPosition);
                self.MainActionPoint--;
                gameObject.GetComponent<EntityStateMachine>().ChangeState(ActiveState.Instance);
                enabled = false;
            }
        }
    }
}