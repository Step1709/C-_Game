using Entities;
using Scenes;

namespace Abilities
{
    public interface IAbility<in TEntity> where TEntity : Entity
    {
        void Choose(TEntity player);
        void Remove(TEntity player);
        bool Use(TEntity player);
    }
}