using UnityEngine;

namespace Scenes.EntityState
{
    public interface IEntityState
    {
        public void Enter(GameObject entity);
        public void Exit(GameObject entity);
    }
}