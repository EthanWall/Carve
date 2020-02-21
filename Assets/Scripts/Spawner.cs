using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToBeSpawned;
    public string generatedTag;

    public void Spawn()
    {
        Instantiate(objectToBeSpawned, transform.position, Quaternion.identity).tag = generatedTag;
    }
}
