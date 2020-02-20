using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    public GameObject start;
    public GameObject finish;
    public Vector2 startHeightLength;
    public Vector2 finishHeightLength;
    public Collider startSpawnBounds;
    public Collider finishSpawnBounds;
    public float requiredDistance;

    void Start()
    {
        GenerateGame();
    }

    private float PickRandomPosition(Collider space)
    {
        return Random.Range(transform.position.x - (space.bounds.size.x / 2), transform.position.x + (space.bounds.size.x / 2));
    }

    public void GenerateGame()
    {
        float distance = 0.0f;
        while (distance < requiredDistance)
        {
            GameObject newStart = Instantiate(start, new Vector3(PickRandomPosition(startSpawnBounds), startHeightLength.x, startHeightLength.y), Quaternion.identity);
            GameObject newFinish = Instantiate(finish, new Vector3(PickRandomPosition(finishSpawnBounds), finishHeightLength.x, finishHeightLength.y), Quaternion.identity);

            distance = Mathf.Abs(newStart.transform.position.x - newFinish.transform.position.x);
        }
    }
}
