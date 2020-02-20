using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        print("Finish!");
        Destroy(other.gameObject);
    }
}
