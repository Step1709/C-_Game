using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Scenes;

public class PathRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private GameObject arrowPrefab;
    private GameObject startMarkerPrefab;
    
    private List<GameObject> arrows = new List<GameObject>();
    private GameObject startMarker;
    private PathController pathController;

    private void Start()
    {
        pathController = GetComponent<PathController>();
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        arrowPrefab = Resources.Load<GameObject>("Arrow");
        startMarkerPrefab = Resources.Load<GameObject>("StartMarker");
    }

    public void RenderPath(List<Vector3Int> path, Vector3? targetPos, int tileCount)
    {
        ClearPath();
        
        if (path == null) return;
        var playerCell = GameModel.Instance.Floor.WorldToCell(pathController.transform.position);
        var playerPosition = GameModel.Instance.Floor.CellToWorld(playerCell);
        var startPos = path.Count > 0 ? 
            GameModel.Instance.Floor.CellToWorld(path[0]) : playerPosition;
        if (startMarkerPrefab != null)
        {
            startMarker = Instantiate(startMarkerPrefab, startPos, Quaternion.identity);
            var textMesh = startMarker.GetComponentInChildren<TextMesh>();
            if (textMesh != null)
            {
                textMesh.text = tileCount.ToString();
            }
        }
        if (path.Count > 0)
        {
            lineRenderer.positionCount = path.Count;
            for (var i = 0; i < path.Count; i++)
            {
                lineRenderer.SetPosition(i, GameModel.Instance.Floor.CellToWorld(path[i]));
            }
            if (arrowPrefab != null)
            {
                for (var i = 0; i < path.Count - 1; i++)
                {
                    var currentPos = GameModel.Instance.Floor.CellToWorld(path[i]);
                    var nextPos = GameModel.Instance.Floor.CellToWorld(path[i+1]);
                    var dir = nextPos - currentPos;
                    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    
                    var arrow = Instantiate(arrowPrefab, currentPos, Quaternion.Euler(0, 0, angle));
                    arrows.Add(arrow);
                }
            }
        }

        if (!targetPos.HasValue || path.Count <= 0 || arrowPrefab == null) return;
        {
            var lastPathPos = GameModel.Instance.Floor.CellToWorld(path[^1]);
            var dir = targetPos.Value - lastPathPos;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            
            var finalArrow = Instantiate(arrowPrefab, lastPathPos, Quaternion.Euler(0, 0, angle));
            arrows.Add(finalArrow);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, targetPos.Value);
        }
    }

    public void ClearPath()
    {
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 0;
        }
        
        foreach (var arrow in arrows.Where(arrow => arrow != null))
        {
            Destroy(arrow);
        }
        arrows.Clear();
        
        if (startMarker != null)
        {
            Destroy(startMarker);
        }
    }
}