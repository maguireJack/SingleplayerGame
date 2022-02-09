using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBrain : MonoBehaviour
{
    public Camera camera;
    public List<GameObject> points;
    private GameObject pointToGoTo;
    private float shortestDistance = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!points[2].GetComponent<PointBrain>().player.GetComponent<MoveTo>().entered && !points[2].GetComponent<PointBrain>().player.GetComponent<MoveTo>().alley) {
            if (points[0].GetComponent<PointBrain>().hitInfo.distance > points[1].GetComponent<PointBrain>().hitInfo.distance)
            {
                camera.transform.position = points[1].transform.position;
            }
            else
            {
                camera.transform.position = points[0].transform.position;
            }
        } else if (points[2].GetComponent<PointBrain>().player.GetComponent<MoveTo>().entered)
        {
            camera.transform.position = points[2].transform.position;
        } else if (points[1].GetComponent<PointBrain>().player.GetComponent<MoveTo>().alley)
        {
            camera.transform.position = points[3].transform.position;
        }if (points[1].GetComponent<PointBrain>().player.GetComponent<MoveTo>().chopshop)
        {
            camera.transform.position = points[4].transform.position;
        }
    }
}
