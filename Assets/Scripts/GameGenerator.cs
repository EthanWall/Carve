using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    public GameObject start;
    public GameObject finish;
    public GameObject coin;
    public Vector2 startHeightLength;
    public Vector2 finishHeightLength;
    //public Transform startStartPosition;
    //public Transform startEndPosition;
    //public Transform finishStartPosition;
    //public Transform finishEndPosition;
    public Collider startSpawnArea;
    public Collider finishSpawnArea;
    public Collider coinSpawnArea;
    public float requiredDistance;
    public float coinCount;
    public string generatedTag;

    [HideInInspector]
    public GameObject generatedStart;
    [HideInInspector]
    public GameObject generatedFinish;

    void Start()
    {
        GenerateGame();
    }

    /*private Vector3 PickRandomPosition(Collider space)
    {
        float x = Random.Range(space.transform.position.x - space.bounds.extents.x, space.transform.position.x + space.bounds.extents.x);
        float y = Random.Range(space.transform.position.y - space.bounds.extents.y, space.transform.position.y + space.bounds.extents.y);
        float z = Random.Range(space.transform.position.z - space.bounds.extents.z, space.transform.position.z + space.bounds.extents.z);
        return new Vector3(x, y, z);
    }

    private float PickRandomPosition(Transform startPosition, Transform endPosition)
    {
        return Random.Range(startPosition.position.x, endPosition.position.x);
    }*/

    public void GenerateGame()
    {
        // Start and Finish
        float distance = 0.0f;
        Vector3 generatedStartPosition = Vector3.zero;
        Vector3 generatedFinishPosition = Vector3.zero;
        while (distance < requiredDistance)
        {
            //generatedStartPosition = new Vector3(PickRandomPosition(startStartPosition, startEndPosition), startHeightLength.x, startHeightLength.y);
            //generatedFinishPosition = new Vector3(PickRandomPosition(finishStartPosition, finishEndPosition), finishHeightLength.x, finishHeightLength.y);
            generatedStartPosition = new Vector3(Utils.PickRandomPosition1D(startSpawnArea), startHeightLength.x, startHeightLength.y);
            generatedFinishPosition = new Vector3(Utils.PickRandomPosition1D(finishSpawnArea), finishHeightLength.x, finishHeightLength.y);

            distance = Mathf.Abs(generatedStartPosition.x - generatedFinishPosition.x);
        }
        generatedStart = Instantiate(start, generatedStartPosition, Quaternion.identity);
        generatedFinish = Instantiate(finish, generatedFinishPosition, Quaternion.identity);

        generatedStart.tag = generatedTag;
        generatedFinish.tag = generatedTag;

        // Coins
        for (int i = 0; i < coinCount; i++)
        {
            Vector2 coinSpawnPosition = Utils.PickRandomPosition2D(coinSpawnArea);
            Instantiate(coin, new Vector3(coinSpawnPosition.x, coinSpawnPosition.y, 0.0f), Quaternion.identity).tag = generatedTag;
        }
    }
}
