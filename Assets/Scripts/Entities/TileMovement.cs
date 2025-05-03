using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Paths;
using Scenes;
using Scenes.Scene;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TailMap
{
    public class TileMovement:MonoBehaviour
    {
        public Tilemap tilemap;
        public float moveSpeed;
        
        private List<Vector3> pathWorldPositions;
        private int currentTargetIndex = 0;
        private bool isMoving = false;
        private Vector3 offset = new Vector3(0, 0.4f, 0);

        void OnEnable()
        {
            isMoving = false;
        }
        void Start()
        {
            tilemap = GameModel.Instance.Floor;
            moveSpeed = GetComponent<EntityWrapper>().Entity.MoveSpeed;
        }
        public void Update()
        {
            if (gameObject == GameModel.Instance.ChosenPlayer)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mouseWorldPos.z = 0f;
                    var targetCell = tilemap.WorldToCell(mouseWorldPos);
                    var startCell = tilemap.WorldToCell(transform.position);
                    var path = PathFinder.AStar(startCell, targetCell);
                    if (path != null && path.Count > 0)
                    {
                        pathWorldPositions = new List<Vector3>();
                        foreach (var cell in path)
                        {
                            pathWorldPositions.Add(tilemap.GetCellCenterWorld(cell) + offset);
                        }

                        currentTargetIndex = 0;
                        isMoving = true;
                    }
                }
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
                    Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) isMoving = false;
                if (isMoving && pathWorldPositions != null && pathWorldPositions.Count > 0)
                {
                    var targetPosition = pathWorldPositions[currentTargetIndex];
                    transform.position =
                        Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

                    if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
                    {
                        currentTargetIndex++;
                        if (currentTargetIndex >= pathWorldPositions.Count)
                        {
                            isMoving = false;
                        }
                    }
                }
            }
            else isMoving = false;
        }
    }
}