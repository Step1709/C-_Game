using Scenes;
using UnityEngine;

namespace Paths
{
    public class PositionInfo : MonoBehaviour
    {
        private Vector3Int position;
        void Start()
        {
            position = GameModel.Instance.Floor.WorldToCell(transform.position);
            GameModel.Instance.EntitiesPositions.Add(position);
        }
        void FixedUpdate()
        {
            if (GameModel.Instance.Floor.WorldToCell(transform.position) != position)
            {
                GameModel.Instance.EntitiesPositions.Remove(position);
                position = GameModel.Instance.Floor.WorldToCell(transform.position);
                GameModel.Instance.EntitiesPositions.Add(position);
            }
        }
    }
}