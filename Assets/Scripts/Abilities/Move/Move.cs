using System;
using System.Collections.Generic;
using Entities;
using Scenes;
using Scenes.EntityState2;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Abilities
{
    public abstract class Move<TStateMachine> : MonoBehaviour 
        where TStateMachine : StateMachine<TStateMachine>
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
        private TStateMachine stateMachine;
        
        private Vector3 previousPosition;
        
        protected abstract IState<TStateMachine> UsingAbility { get; }
        protected abstract IState<TStateMachine> Active { get; }

        void Awake()
        {
            tileMap = GameModel.Instance.Floor;
        }

        void OnEnable()
        {
            if (!isUsed) stateMachine.ChangeState(UsingAbility);
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
                    var scale = transform.localScale;
                    if (shouldFaceRight)
                    {
                        scale.x = Math.Abs(scale.x);
                    }
                    else
                    {
                        scale.x = -Math.Abs(scale.x);
                    }
                    transform.localScale = scale;
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
                if (!isUsed) stateMachine.ChangeState(Active);
            }
        }
    }
}