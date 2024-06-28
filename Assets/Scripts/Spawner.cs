using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawner;
    public int randomBlocks = 200;
    public float X = 50.0f;
    public float Z = 100.0f;
    public void Spawn()
    {
        transform.localScale = new Vector3(X, 1, Z);
        float maxX = transform.GetComponent<MeshRenderer>().bounds.size.x - 10.0f;
        float maxZ = transform.GetComponent<MeshRenderer>().bounds.size.z - 10.0f;

        for (int i = 0; i < randomBlocks; i++)
        {
            Vector3 random = new Vector3(Random.Range(-maxX / 2, maxX / 2), 2, Random.Range(-maxZ / 2, maxZ / 2));
            Instantiate(spawner, random, Quaternion.identity);
        }
    }
}
