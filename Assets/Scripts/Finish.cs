using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameHandler gameHandler;

    void OnCollisionEnter(Collision other)
    {
        gameHandler.Restart();
    }
}
