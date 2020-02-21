using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelGenerator : MonoBehaviour
{
    public Vector3 scale;
    public float voxelsPerUnit;
    public string generatedTag;

    // DO NOT feed prefab directly into "voxel" variable
    public GameObject voxel;

    void Start()
    {
        voxel.transform.localScale /= voxelsPerUnit;
        GenerateVoxels();
    }

    public void GenerateVoxels()
    {
        GameObject parent = new GameObject("Voxel Container");
        parent.tag = generatedTag;

        for (float x = 0; x < scale.x; x += 1 / voxelsPerUnit)
        {
            for (float y = 0; y < scale.y; y += 1 / voxelsPerUnit)
            {
                for (float z = 0; z < scale.z; z += 1 / voxelsPerUnit)
                {
                    Instantiate(voxel, new Vector3(x, y, z), Quaternion.identity, parent.transform);
                }
            }
        }
    }
}
