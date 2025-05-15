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
        private List<Vector3> pathWorldPositions;
        private GameObject target;
        private bool isMoving;
        private Vector3 offset = new Vector3(0, 0.4f, 0);
        private Tilemap tileMap;
        private int currentTargetIndex;
        public Enemy self;
        public EnemyStateMachine stateMachine;

        void Awake()
        {
            tileMap = GameModel.Instance.Floor;
        }
        void OnEnable()
        {
            pathWorldPositions = null;
            target = null;
            currentTargetIndex = 0;
            List<Vector3Int> path = null;
            var minPathLenght = int.MaxValue;
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                var currentpath = PathFinder.BFS(self, self.CurrentWeapon, player.transform.position);
                if (currentpath != null && currentpath.Count < minPathLenght)
                {
                    path = currentpath;
                    minPathLenght = currentpath.Count;
                    target = player;
                }
            }

            if (path == null)
            {
                var selfCellPos = GameModel.Instance.Floor.WorldToCell(transform.position);
                foreach (var player in GameModel.Instance.MainPlayers)
                {
                    var playerCellPos = GameModel.Instance.Floor.WorldToCell(player.transform.position);
                    var currentpath = PathFinder.AStar(selfCellPos, playerCellPos).Take(self.CurrentTileCount).ToList();
                    if (currentpath.Count < minPathLenght)
                    {
                        path = currentpath;
                        minPathLenght = currentpath.Count;
                    }
                }
            }
            
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
                    if (currentTargetIndex >= pathWorldPositions.Count)
                    {
                        isMoving = false;
                    }
                }
            }
            else isMoving = false;

            if (isMoving == false)
            {
                if (target != null)
                {
                    self.Attack(target.GetComponent<EntityWrapper>().Entity);
                }
                stateMachine.ChangeState(WaitingState.Instance);
            }
        }
    }
}