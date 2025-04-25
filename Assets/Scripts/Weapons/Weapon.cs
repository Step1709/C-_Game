namespace Weapons
{
    public class Weapon
    {
        public int BaseDamage;
        public float Range;
        public float SplashRadius;

        public Weapon(int baseDamage, float range, float splashRadius)
        {
            BaseDamage = baseDamage;
            Range = range;
            SplashRadius = splashRadius;
        }
    }
}