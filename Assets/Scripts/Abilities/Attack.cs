using System.Collections.Generic;
using Entities;
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
                enabled = false;
            }
        }
    }
}