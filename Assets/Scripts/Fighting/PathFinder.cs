using System.Collections.Generic;
using UnityEngine;

namespace Fighting
{
    public class PathFinder
    {
        public static List<Vector3Int> FindPath(GameObject activeEntity, GameObject targetEntity,
            System.Func<Vector3Int,
                IEnumerable<Vector3Int>> getNeighbors, System.Func<Vector3Int, Vector3Int, bool> CanMove)
        {
            return null;
        }
    }
}