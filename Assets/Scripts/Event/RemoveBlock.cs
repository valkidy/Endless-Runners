using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;

namespace Platformer.Gameplay
{    
    public class RemoveBlock : Simulation.Event<RemoveBlock>
    {
        public LevelController controller;
        public Collider2D collider;

        public override void Execute()
        {
            controller.RemoveBlock(collider.gameObject);
        }
    }

    public class RemoveBlockLeftside : Simulation.Event<RemoveBlockLeftside>
    {
        public LevelController controller;        
        public float positionX;

        public override void Execute()
        {
            controller.RemoveBlockLeftside(positionX);
        }
    }
}