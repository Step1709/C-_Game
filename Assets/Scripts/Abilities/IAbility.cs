using Entities;
using Scenes;

namespace Abilities
{
    public interface IAbility
    {
        void Choose(MainPlayer player);
        void Remove(MainPlayer player);
        void Use(MainPlayer player);
        
        void Choose(Enemy enemy);
        void Remove(Enemy enemy);
        void Use(Enemy enemy);
    }
}