using Entities;
using UnityEngine;

namespace Scenes
{
    public class UpdatePos : MonoBehaviour
    {
        public Entity Entity;

        void Start()
        {
            Entity = GetComponent<EntityWrapper>().Entity;
        }
        void Update()
        {
            Entity.Position = transform.position;
        }
    }
}