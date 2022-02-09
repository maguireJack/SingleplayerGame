using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject TopDoor;
    [SerializeField]
    private GameObject BottomDoor;

    public Transform enterPoint;
    public Transform exitPoint;

    public bool moveDoor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(moveDoor)
        {
            if (TopDoor.transform.position.y <= 3.5) {
                TopDoor.transform.position = TopDoor.transform.position + new Vector3(0, 0.01f, 0);
                BottomDoor.transform.position = BottomDoor.transform.position + new Vector3(0, -0.01f, 0);
            }
        }
        else
        {
            if (TopDoor.transform.position.y >= 1.7)
            {
                TopDoor.transform.position = TopDoor.transform.position + new Vector3(0, -0.01f, 0);
                BottomDoor.transform.position = BottomDoor.transform.position + new Vector3(0, +0.01f, 0);
            }
        }
    }
}
