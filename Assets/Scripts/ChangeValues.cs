using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeValues : MonoBehaviour
{
    public GameObject player;
    public GameObject plane;

    public float planeDimensionX = 50.0f;
    public float planeDimensionZ = 100.0f;
    public float ForceToUp = 600.0f;
    public float maxSpeed = 1000.0f;
    public float time = 100.0f;
    public int randomBlocks = 200;

    private void Start()
    {
        plane.GetComponent<Spawner>().X = planeDimensionX;
        plane.GetComponent<Spawner>().Z = planeDimensionZ;
        plane.GetComponent<Spawner>().randomBlocks = randomBlocks;
        plane.GetComponent<Spawner>().Spawn();
    }
    public void Change()
    {
        player.GetComponent<StationaryMove>().maxSpeed = maxSpeed;
        player.GetComponent<CollideHooman>().Force = ForceToUp;
        player.GetComponent<CollideHooman>().time = time;
    }
}
