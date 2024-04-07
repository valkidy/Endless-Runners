using Platformer.Core;
using Platformer.Mechanics;
using UnityEngine;

namespace Platformer.Gameplay
{    
    public class CreateBlock : Simulation.Event<CreateBlock>
    {
        public LevelController controller;
        public Vector3 position;

        public override void Execute()
        {
            controller.AddBlock(position);
        }
    }
}