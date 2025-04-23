using Entities;

namespace Fighting
{
    public class Wave
    {
        public Enemy[] enemies;

        public Wave(params Enemy[] enemies)
        {
            this.enemies = enemies;
        }
    }
}