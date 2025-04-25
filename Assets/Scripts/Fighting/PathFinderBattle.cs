using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Fighting
{
    public static class PathFinderBattle
    {
        public static List<Vector3Int> FindPath(GameObject activeEntity, GameObject targetEntity, System.Func<Vector3Int,
            IEnumerable<Vector3Int>> getNeighbors, System.Func<Vector3Int, Vector3Int, bool> CanMove)
        {
            var activeEntityPosition = activeEntity.transform.position;
            var targetEntityPosition = targetEntity.transform.position;
            var entity = activeEntity.GetComponent<EntityWrapper>().Entity;
            return new List<Vector3Int>();
        }
    }
}