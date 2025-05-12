using System.Collections.Generic;
using System.Linq;
using Paths;
using Scenes;
using Scenes.EntityState2;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Entities.MainPlayers
{
    public class PlayerAction : MonoBehaviour
    {
        [SerializeField]
        private PlayerStateMachine stateMachine;
        [SerializeField]
        private PathController pathController;
        
        private List<Vector3> pathWorldPositions;
        private GameObject target;
        private bool isMoving;
        private Vector3 offset = new Vector3(0, 0.4f, 0);
        private Tilemap tileMap;
        private int currentTargetIndex;
        public MainPlayer self;

        void Awake()
        {
            tileMap = GameModel.Instance.Floor;
        }
        void OnEnable()
        {
            target = pathController.target;
            pathWorldPositions = new List<Vector3>();
            foreach (var cell in pathController.path)
            {
                pathWorldPositions.Add(tileMap.GetCellCenterWorld(cell) + offset);
            }

            currentTargetIndex = 0;
            isMoving = true;
            self.CurrentTileCount-=pathWorldPositions.Count;
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
                stateMachine.ChangeState(ActiveState.Instance);
            }
        }
    }
}