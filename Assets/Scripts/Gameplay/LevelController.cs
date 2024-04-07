using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;

public class LevelController : MonoBehaviour
{
    public PlayerController player;

    public List<GameObject> blockTemplate;

    private List<GameObject> blockList = new List<GameObject>();

    private void Awake()
    {
        var ev = Schedule<CreateBlock>();
        ev.controller = this;
        ev.position = player.transform.position - new Vector3(0, 4F, 0);
    }

    public void AddBlock(Vector3 position)
    {
        var newBlock = blockList.Find(go => !go.activeSelf);
        if (!newBlock)
        {
            var prefab = blockTemplate[Random.Range(0, blockTemplate.Count)];
            newBlock =  Instantiate(prefab);
            newBlock.transform.parent = this.transform;

            var rigidBody = newBlock.AddComponent<Rigidbody2D>();
            rigidBody.isKinematic = true;

            blockList.Add(newBlock);
        }

        newBlock.transform.position = position;
        newBlock.SetActive(true);
    }

    public void RemoveBlock(GameObject beRemoved)
    {
        var oldBlock = blockList.Find(go => go == beRemoved);
        if (oldBlock)
        {
            oldBlock.SetActive(false);
        }
    }

    public void RemoveBlockLeftside(float positionX)
    {
        foreach(var block in blockList)
        {
            block.SetActive(block.transform.position.x >= positionX);
        }                
    }
}
