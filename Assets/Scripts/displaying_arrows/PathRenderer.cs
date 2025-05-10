using System.Collections.Generic;
using UnityEngine;

public class PathRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public void RenderPath(List<Vector3Int> path)
    {
        if (lineRenderer == null)
        {
            Debug.LogWarning('н');
            return;
        }
        lineRenderer.positionCount = path.Count;
        for (var i = 0; i < path.Count; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(path[i].x, path[i].y, 0));
        }
    }
    public void ClearPath()
    {
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 0;
        }
    }
}