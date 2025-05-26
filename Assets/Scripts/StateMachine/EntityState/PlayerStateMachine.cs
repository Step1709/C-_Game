using Entities.MainPlayers;
using Scenes;
using TailMap;
using UI;
using UnityEngine;
using Screen = UI.Screen;

namespace Scenes.EntityState2
{
    public class PlayerStateMachine : EntityStateMachine
    {
        public MainPlayer player;
        
        public TileMovement TileGraph;
        
        public PlayerFightController fightController;
        
        public PlayerInterface Interface;
        
        void Start()
        {
            player = (MainPlayer)wrapper.Entity;
            Interface = Screen.Instance.PlayerInterface.GetComponent<PlayerInterface>();
        }
        public override void ChangeState(IEntityState newState)
        {
            ((IPlayerState)currentState)?.Exit(this);
            ((IPlayerState)newState)?.Enter(this);
            currentState = newState;
        }
    }
}