using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    [SerializeField]
    private GameObject bottle;

    private bool pickable;
    private bool picked;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickable)
        {
            Drop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pickable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pickable = false;
        }
    }

    void Drop()
    {
        if (!picked)
        {
            bottle.SetActive(true);
            picked = true;
        }
       
    }
}
