using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    public GameObject start;
    public GameObject finish;
    public Vector2 startHeightLength;
    public Vector2 finishHeightLength;
    public Transform startStartPosition;
    public Transform startEndPosition;
    public Transform finishStartPosition;
    public Transform finishEndPosition;
    public float requiredDistance;
    public string generatedTag;

    [HideInInspector]
    public GameObject generatedStart;
    [HideInInspector]
    public GameObject generatedFinish;

    void Start()
    {
        GenerateGame();
    }

    private float PickRandomPosition(Transform startPosition, Transform endPosition)
    {
        return Random.Range(startPosition.position.x, endPosition.position.x);
    }

    public void GenerateGame()
    {
        float distance = 0.0f;
        Vector3 generatedStartPosition = Vector3.zero;
        Vector3 generatedFinishPosition = Vector3.zero;
        while (distance < requiredDistance)
        {
            generatedStartPosition = new Vector3(PickRandomPosition(startStartPosition, startEndPosition), startHeightLength.x, startHeightLength.y);
            generatedFinishPosition = new Vector3(PickRandomPosition(finishStartPosition, finishEndPosition), finishHeightLength.x, finishHeightLength.y);

            distance = Mathf.Abs(generatedStartPosition.x - generatedFinishPosition.x);
        }
        generatedStart = Instantiate(start, generatedStartPosition, Quaternion.identity);
        generatedFinish = Instantiate(finish, generatedFinishPosition, Quaternion.identity);

        generatedStart.tag = generatedTag;
        generatedFinish.tag = generatedTag;
    }
}
