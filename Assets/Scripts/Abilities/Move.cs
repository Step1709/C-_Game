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
        private Animator animator;
        [SerializeField]
        private EntityStateMachine stateMachine;
        
        private Vector3 previousPosition;
        private bool facingRight = true;

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
            animator.SetBool("stop", false);
            previousPosition = transform.position;
        }

        void Update()
        {
            if (isMoving && pathWorldPositions != null && pathWorldPositions.Count > 0)
            {
                var targetPosition = pathWorldPositions[currentTargetIndex];
                transform.position =
                    Vector3.MoveTowards(transform.position, targetPosition, self.MoveSpeed * Time.deltaTime);
                var moveDirection = transform.position - previousPosition;
                if (moveDirection.x != 0)
                {
                    var shouldFaceRight = moveDirection.x > 0;
                    if (shouldFaceRight != facingRight)
                    {
                        FlipSprite();
                    }
                }
                previousPosition = transform.position;

                if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
                {
                    currentTargetIndex++;
                    self.CurrentTileCount--;
                    if (currentTargetIndex >= pathWorldPositions.Count)
                    {
                        isMoving = false;
                        animator.SetBool("stop", true);
                    }
                }
            }
            else
            {
                isMoving = false;
                animator.SetBool("stop", true);
            }

            if (isMoving == false)
            {
                enabled = false;
                if (!isUsed) stateMachine.ChangeState(ActiveState.Instance);
            }
        }

        private void FlipSprite()
        {
            facingRight = !facingRight;
            var scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}