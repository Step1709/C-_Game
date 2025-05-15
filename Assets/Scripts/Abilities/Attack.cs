using System.Collections.Generic;
using Entities;
using Scenes.EntityState2;
using UnityEngine;

namespace Abilities
{
    public class Attack : MonoBehaviour
    {
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
                if (target is null)
                {
                    Debug.Log("атакуем ничего");
                }
                else self.Attack(target.GetComponent<EntityWrapper>().Entity);
                gameObject.GetComponent<EntityStateMachine>().ChangeState(ActiveState.Instance);
                enabled = false;
            }
        }
    }
}