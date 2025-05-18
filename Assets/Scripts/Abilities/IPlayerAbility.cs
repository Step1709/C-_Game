using Scenes;

namespace Abilities
{
    public interface IPlayerAbility : IAbility
    {
        void Choose(MainPlayer player);
        void Remove(MainPlayer player);
        bool Use(MainPlayer player);
    }
}