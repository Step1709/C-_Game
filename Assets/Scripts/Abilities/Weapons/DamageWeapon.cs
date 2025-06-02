using System.Collections.Generic;
using System.Linq;
using Abilities;
using Entities;
using Paths;
using Scenes;
using UnityEngine;

namespace Weapons
{
    public class DamageWeapon : Weapon
    {
        public DamageWeapon(int minDamage, int maxDamage, float range, float splashRadius, bool damageSelf, string animationName) 
            : base(minDamage, maxDamage, range, splashRadius, damageSelf, animationName)
        {
        }

        protected override void Damage(Entity user, Entity target)
        {
            var random = Random.Range(1, 21);
            if (random >= target.ArmorClass)
            {
                var damage = Random.Range(minDamage, maxDamage + 1);
                if (random == 20)
                {
                    damage *= 2;
                    UI.Screen.Instance.DamageShower.ShowDamage(target, "крит. удар", Color.red, new Vector3(0,1f,0));
                }
                target.Health -= damage;
                if (target.Health <= 0) target.Health = 0;
                UI.Screen.Instance.DamageShower.ShowDamage(target, damage.ToString(), Color.red, new Vector3(0,0.6f,0));
            }
            else
            {
                UI.Screen.Instance.DamageShower.ShowDamage(target, "0", Color.white, new Vector3(0,0.6f,0));
            }
        }

        public override bool Use(MainPlayer player)
        {
            if (player.MainActionPoint <= 0)
            {
                Debug.Log("Нет очков действия");
                return false;
            }
            var playerObj = player.GameObject;
            var attack = playerObj.GetComponent<Attack>();
            var pathController = playerObj.GetComponent<PathController>();
            if (pathController.path == null) return false;
            if (pathController.target is not null && pathController.target == player.GameObject)
            {
                Debug.Log("нельзя атаковать себя");
                return false;
            }
            pathController.enabled = false;
            playerObj.GetComponent<PathVisualizer>().enabled = false;
            attack.target = pathController.target?.GetComponent<EntityWrapper>().Entity;
            attack.pathToTarget = pathController.path;
            attack.targetPosition = (Vector3)pathController.targetPos;
            attack.enabled = true;
            return true;
        }

        public override bool Use(Enemy enemy)
        {
            if (enemy.MainActionPoint <= 0)
            {
                return false;
            }
            Entity target = null;
            List<Vector3Int> path = null;
            var minPathLenght = int.MaxValue;
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                var exceptColliders = Physics2D.OverlapCircleAll(player.GameObject.transform.position, 0.1f)
                    .ToHashSet();
                var currentpath = PathFinder.BFS(enemy, 
                    x=>Vector3.Distance(x, player.GameObject.transform.position) <= Range 
                       && !PathFinder.IsBlocked(x, player.GameObject.transform.position, enemy.GameObject, player.GameObject, exceptColliders),
                    x=>x.depth + Vector3.Distance(GameModel.Instance.Floor.GetCellCenterWorld(x.cellPosition), player.GameObject.transform.position));
                if (currentpath != null && currentpath.Count < minPathLenght)
                {
                    path = currentpath;
                    minPathLenght = currentpath.Count;
                    target = player;
                }
            }

            if (path == null) return false;
            
            var attack = enemy.GameObject.GetComponent<Attack>();
            attack.target = target;
            attack.pathToTarget = path;
            attack.targetPosition = target.GameObject.transform.position;
            enemy.ChangeAbility(this);
            attack.enabled = true;
            return true;
        }
    }
}