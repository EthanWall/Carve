using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    public float distanceFromCamera;
    public string destroyableTag;
    public float scaleInterval;
    public float minScale;
    public float maxScale;

    private List<GameObject> touchingPoints = new List<GameObject>();

    new private Rigidbody rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move the bursh
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera));
        rigidbody.position = mousePos;

        // Change brush size
        float desiredRadius = transform.localScale.x;
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            desiredRadius -= scaleInterval;
        }
        else if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            desiredRadius += scaleInterval;
        }
        desiredRadius = Mathf.Clamp(desiredRadius, minScale, maxScale);
        transform.localScale = new Vector3(desiredRadius, desiredRadius, desiredRadius);

        // Cut a hole in the object
        if (Input.GetMouseButton(0))
        {
            foreach (GameObject obj in touchingPoints)
            {
                if (obj != null && obj.tag == destroyableTag)
                {
                    Destroy(obj);
                }
            }
        }
    }

    void LateUpdate()
    {
        // Cleanup destroyed objects
        touchingPoints.RemoveAll(obj => obj == null);
    }

    void OnTriggerEnter(Collider other)
    {
        touchingPoints.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        touchingPoints.Remove(other.gameObject);
    }
}
