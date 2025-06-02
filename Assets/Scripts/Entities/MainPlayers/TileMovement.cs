using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Paths;
using Scenes;
using Scenes.Scene;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

namespace TailMap
{
    public class TileMovement : MonoBehaviour
    {
        private Tilemap tilemap;
        private float moveSpeed;
        
        private List<Vector3> pathWorldPositions;
        private int currentTargetIndex = 0;
        private bool isMoving = false;
        private Vector3 offset = new Vector3(0, 0.4f, 0);
        
        [SerializeField] private Animator animator;
        private SpriteRenderer spriteRenderer;
        private Vector3 previousPosition;
        private bool facingRight = true;

        void Start()
        {
            tilemap = GameModel.Instance.Floor;
            moveSpeed = GetComponent<EntityWrapper>().Entity.MoveSpeed;
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        void OnEnable()
        {
            isMoving = false;
        }

        public void Update()
        {
            if (GameModel.Instance.OnPause) return;
            
            if (gameObject == GameModel.Instance.ChosenPlayer.GameObject)
            {
                HandleMouseInput();
                HandleMovement();
            }
            else
            {
                isMoving = false;
            }
        }

        private void HandleMouseInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;
                
                var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPos.z = 0f;
                var targetCell = tilemap.WorldToCell(mouseWorldPos);
                var startCell = tilemap.WorldToCell(transform.position);
                
                var path = PathFinder.AStar(startCell, targetCell);
                if (path != null && path.Count > 0)
                {
                    pathWorldPositions = path.Select(cell => tilemap.GetCellCenterWorld(cell) + offset).ToList();
                    currentTargetIndex = 0;
                    isMoving = true;
                    previousPosition = transform.position;
                    animator.SetBool("stop", false);
                }
            }
        }

        private void HandleMovement()
        {
            if (!isMoving || pathWorldPositions == null || pathWorldPositions.Count == 0)
            {
                isMoving = false;
                animator.SetBool("stop", true);
                return;
            }

            var targetPosition = pathWorldPositions[currentTargetIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            var moveDirection = transform.position - previousPosition;
            if (Mathf.Abs(moveDirection.x) > 0.01f) 
            {
                var shouldFaceRight = moveDirection.x > 0;
                if (shouldFaceRight != facingRight)
                {
                    FlipSprite(shouldFaceRight);
                }
            }
            previousPosition = transform.position;
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                currentTargetIndex++;
                if (currentTargetIndex >= pathWorldPositions.Count)
                {
                    isMoving = false;
                    animator.SetBool("stop", true);
                }
            }
        }

        private void FlipSprite(bool faceRight)
        {
            facingRight = faceRight;
            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = !faceRight;
            }
        }
    }
}