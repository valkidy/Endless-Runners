using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay
{    
    public class PlayerRespawn : Simulation.Event<PlayerRespawn>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        public LevelController controller;

        public override void Execute()
        {
            var player = model.player;
            player.collider2d.enabled = true;
            //player.controlEnabled = false;
            //if (player.audioSource && player.respawnAudio)
            //    player.audioSource.PlayOneShot(player.respawnAudio);
            //player.health.Increment();
            player.Teleport(model.spawnPoint.transform.position);
            player.jumpState = PlayerController.JumpState.Grounded;

            controller.AddBlock(player.transform.position - new Vector3(0, 4F, 0));
            // model.virtualCamera.m_Follow = player.transform;
            // model.virtualCamera.m_LookAt = player.transform;
            // Simulation.Schedule<EnablePlayerInput>(2f);
        }
    }

}