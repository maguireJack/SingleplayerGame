using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBrain : MonoBehaviour
{
    public RaycastHit hitInfo;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        

        if (Physics.Raycast(gameObject.transform.position, (player.transform.position - gameObject.transform.position), out hitInfo, 100f, 3))
        {

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(gameObject.transform.position, (player.transform.position - gameObject.transform.position));
    }
}
