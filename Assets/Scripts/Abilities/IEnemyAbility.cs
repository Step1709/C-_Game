using Entities;

namespace Abilities
{
    public interface IEnemyAbility : IAbility
    {
        void Choose(Enemy enemy);
        void Remove(Enemy enemy);
        bool Use(Enemy enemy);
    }
}