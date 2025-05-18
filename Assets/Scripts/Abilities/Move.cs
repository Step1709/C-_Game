using System.Collections.Generic;
using Entities;
using Scenes;
using Scenes.EntityState2;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Abilities
{
    public class Move : MonoBehaviour
    {
        public List<Vector3Int> path;
        public Entity self;
        public bool isUsed;
        private List<Vector3> pathWorldPositions;
        private bool isMoving;
        private Vector3 offset = new Vector3(0, 0.4f, 0);
        private Tilemap tileMap;
        private int currentTargetIndex;
        
        [SerializeField]
        private EntityStateMachine stateMachine;

        void Awake()
        {
            tileMap = GameModel.Instance.Floor;
        }
        void OnEnable()
        {
            if (!isUsed) stateMachine.ChangeState(UsingAbilityState.Instance);
            pathWorldPositions = new List<Vector3>();
            foreach (var cell in path)
            {
                pathWorldPositions.Add(tileMap.GetCellCenterWorld(cell) + offset);
            }
            currentTargetIndex = 0;
            isMoving = true;
        }

        void Update()
        {
            if (isMoving && pathWorldPositions != null && pathWorldPositions.Count > 0)
            {
                var targetPosition = pathWorldPositions[currentTargetIndex];
                transform.position =
                    Vector3.MoveTowards(transform.position, targetPosition, self.MoveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
                {
                    currentTargetIndex++;
                    self.CurrentTileCount--;
                    if (currentTargetIndex >= pathWorldPositions.Count)
                    {
                        isMoving = false;
                    }
                }
            }
            else isMoving = false;

            if (isMoving == false)
            {
                enabled = false;
                if (!isUsed) stateMachine.ChangeState(ActiveState.Instance);
            }
        }
    }
}