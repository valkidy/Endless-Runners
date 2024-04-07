using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;

public class LevelGenerator : MonoBehaviour
{
    Camera cam;
    LevelController controller;

    public Vector3 prevPos, nextPos;

    void Awake()
    {
        cam = Camera.main;
        controller = GetComponentInParent<LevelController>();

        prevPos = cam.transform.position;
        nextPos += prevPos + new Vector3(11F, 0, 0);
    }

    void FixedUpdate()
    {        
        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 0);

        prevPos = transform.position;

        if (prevPos.x >= nextPos.x)
        {
            nextPos = prevPos += new Vector3(11F, 0, 0);

            var ev = Schedule<CreateBlock>();
            ev.controller = controller;
            ev.position = new Vector3(transform.position.x + 4F, transform.position.y, 0);

            var rev = Schedule<RemoveBlockLeftside>();
            rev.controller = controller;
            rev.positionX = transform.position.x - 26F;
        }

        if (transform.position.y <= -10F)
        {
            var ev = Schedule<PlayerRespawn>();
            ev.controller =  controller; 
        }
    }   
}
