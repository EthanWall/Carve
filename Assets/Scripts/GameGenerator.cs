using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    public GameObject start;
    public GameObject finish;
    public Vector2 startHeightLength;
    public Vector2 finishHeightLength;
    public float startSize;
    public float finishSize;
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

    private float PickRandomPosition(float width)
    {
        float divSize = width / 2;
        return Random.Range(transform.position.x - divSize, transform.position.x + divSize);
        //float width = space.bounds.extents.x / 2;
        //return Random.Range(transform.position.x - width, transform.position.x + width);
    }

    public void GenerateGame()
    {
        float distance = 0.0f;
        Vector3 generatedStartPosition = Vector3.zero;
        Vector3 generatedFinishPosition = Vector3.zero;
        while (distance < requiredDistance)
        {
            generatedStartPosition = new Vector3(PickRandomPosition(startSize), startHeightLength.x, startHeightLength.y);
            generatedFinishPosition = new Vector3(PickRandomPosition(finishSize), finishHeightLength.x, finishHeightLength.y);

            distance = Mathf.Abs(generatedStartPosition.x - generatedFinishPosition.x);
        }
        generatedStart = Instantiate(start, generatedStartPosition, Quaternion.identity);
        generatedFinish = Instantiate(finish, generatedFinishPosition, Quaternion.identity);

        generatedStart.tag = generatedTag;
        generatedFinish.tag = generatedTag;
    }
}
