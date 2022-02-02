using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBrain : MonoBehaviour
{
    private Transform camera;
    public List<GameObject> points;
    private GameObject pointToGoTo;
    private float shortestDistance = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        camera = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
       foreach (GameObject point in points)
       {
            float distance = point.GetComponent<PointBrain>().hitInfo.distance;
            if (shortestDistance >= distance)
            {
                Debug.Log(distance);
                Debug.Log(shortestDistance);
                shortestDistance = distance;
                pointToGoTo = point;   
            }
            gameObject.transform.position = pointToGoTo.transform.position;
            gameObject.transform.rotation = pointToGoTo.transform.rotation;
        }
        
    }
}
