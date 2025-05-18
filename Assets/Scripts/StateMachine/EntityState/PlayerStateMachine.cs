using Entities.MainPlayers;
using Scenes;
using TailMap;
using UnityEngine;

namespace Scenes.EntityState2
{
    public class PlayerStateMachine : EntityStateMachine
    {
        public MainPlayer player;
        
        public TileMovement TileGraph;
        
        public PlayerBaseHandler baseHandler;
        
        public PlayerFightController fightController;
        
        public PathController pathController;
        void Awake()
        {
            currentState = PreparingState.Instance;
        }

        void Start()
        {
            player = (MainPlayer)wrapper.Entity;
        }
        public override void ChangeState(IEntityState newState)
        {
            ((IPlayerState)currentState)?.Exit(this);
            ((IPlayerState)newState)?.Enter(this);
            currentState = newState;
        }
    }
}