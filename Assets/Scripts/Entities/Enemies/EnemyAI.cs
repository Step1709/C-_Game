using System.Collections.Generic;
using System.Linq;
using Paths;
using Scenes;
using Scenes.EntityState2;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Entities
{
    public class EnemyAI : MonoBehaviour
    {
        public Enemy self;
        public EnemyStateMachine stateMachine;

        void Update()
        {
            var isBreak = false;
            foreach (var ability in self.Abilities)
            {
                if (ability.Use(self))
                {
                    isBreak = true;
                    break;
                }
            }
            if (!isBreak)
            {
                stateMachine.ChangeState(WaitingState.Instance);
            }
        }
    }
}