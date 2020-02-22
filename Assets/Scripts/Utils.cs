using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static Vector3 PickRandomPosition3D(Collider space)
    {
        float x = Random.Range(space.transform.position.x - space.bounds.extents.x, space.transform.position.x + space.bounds.extents.x);
        float y = Random.Range(space.transform.position.y - space.bounds.extents.y, space.transform.position.y + space.bounds.extents.y);
        float z = Random.Range(space.transform.position.z - space.bounds.extents.z, space.transform.position.z + space.bounds.extents.z);
        return new Vector3(x, y, z);
    }

    public static float PickRandomPosition1D(Collider space)
    {
        return Random.Range(space.transform.position.x - space.bounds.extents.x, space.transform.position.x + space.bounds.extents.x);
    }
}
