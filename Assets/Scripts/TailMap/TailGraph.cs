using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Scenes;
using Scenes.Scene;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TailMap
{
    public class TailGraph:MonoBehaviour
    {
        public Tilemap tilemap;
        public Tilemap wallsTilemap;
        public float moveSpeed;
        public SceneClass Scene;
        
        private MainPlayer mainPlayer;
        
        private List<Vector3> pathWorldPositions;
        private int currentTargetIndex = 0;
        private bool isMoving = false;
        private Vector3 offset = new Vector3(0, 0.4f, 0);

        public TailGraph(MainPlayer mainPlayer)
        {
            this.mainPlayer = mainPlayer;
            moveSpeed = mainPlayer.MoveSpeed;
            Scene = GameModel.Instance.SampleScene;
        }
        public void Update()
        {
            if (mainPlayer == GameModel.Instance.ChosenPlayer)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mouseWorldPos.z = 0f;
                    var targetCell = tilemap.WorldToCell(mouseWorldPos);
                    var startCell = tilemap.WorldToCell(transform.position);
                    var tuple = new ValueTuple<Vector3Int, Vector3Int>(startCell, targetCell);
                    List<Vector3Int> path;
                    if (Scene.PathsCash.ContainsKey(tuple)) path = Scene.PathsCash[tuple];
                    else
                    {
                        path = AStarPathfinder.FindPath(startCell, targetCell, GetNeighbors, CanMove);
                        Scene.PathsCash.Add(tuple, path);
                    }
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
        
        private bool IsWalkable(Vector3Int cellPosition)
        {
            return tilemap.HasTile(cellPosition) && !wallsTilemap.HasTile(cellPosition);
        }

        private bool NoWallNeigbour(Vector3Int cellPosition, Vector3Int neighbourPosition)
        {
            var d = neighbourPosition - cellPosition;
            if (d.x == 0 || d.y == 0) return true;
            var res = true;
            var neighbours = 
                GetStraightNeighbors(cellPosition).Intersect(GetStraightNeighbors(neighbourPosition));
            foreach (var neighbour in neighbours)
            {
                if (wallsTilemap.HasTile(neighbour))
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        private bool CanMove(Vector3Int Position, Vector3Int neighbourPosition)
        {
            return IsWalkable(neighbourPosition) && NoWallNeigbour(Position, neighbourPosition);
        }
        private IEnumerable<Vector3Int> GetNeighbors(Vector3Int cell)
        {
            foreach (var neighbour in GetStraightNeighbors(cell))
            {
                yield return neighbour;
            }
            yield return new Vector3Int(cell.x + 1, cell.y + 1, cell.z);
            yield return new Vector3Int(cell.x + 1, cell.y - 1, cell.z);
            yield return new Vector3Int(cell.x - 1, cell.y + 1, cell.z);
            yield return new Vector3Int(cell.x - 1, cell.y - 1, cell.z);
        }
        
        private IEnumerable<Vector3Int> GetStraightNeighbors(Vector3Int cell)
        {
            yield return new Vector3Int(cell.x + 1, cell.y, cell.z);
            yield return new Vector3Int(cell.x - 1, cell.y, cell.z);
            yield return new Vector3Int(cell.x, cell.y + 1, cell.z);
            yield return new Vector3Int(cell.x, cell.y - 1, cell.z);
        }
    }
}