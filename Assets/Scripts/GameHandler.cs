using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public string generatedTag;
    public string temporaryTag;
    public GameGenerator gameGenerator;
    public VoxelGenerator voxelGenerator;

    private Spawner spawner;

    void Start()
    {
        spawner = gameGenerator.generatedStart.GetComponent<Spawner>();
    }

    public void Play()
    {
        // Begin simulation
        spawner.Spawn();
    }

    public void Restart()
    {
        // End simulation
        // Destroy generated objects
        GameObject[] generatedObjects = GameObject.FindGameObjectsWithTag(generatedTag).Concat(GameObject.FindGameObjectsWithTag(temporaryTag)).ToArray();
        foreach (GameObject obj in generatedObjects)
        {
            Destroy(obj);
        }

        // Regenerate objects
        voxelGenerator.GenerateVoxels();
        gameGenerator.GenerateGame();
        spawner = gameGenerator.generatedStart.GetComponent<Spawner>();
    }

    public void Stop()
    {
        // End simulation
        // Destroy generated objects
        GameObject[] generatedObjects = GameObject.FindGameObjectsWithTag(temporaryTag);
        foreach (GameObject obj in generatedObjects)
        {
            Destroy(obj);
        }

        // Regenerate objects
        voxelGenerator.GenerateVoxels();
    }
}
