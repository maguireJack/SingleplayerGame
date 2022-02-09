using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public Inventory inventory;
    public bool status;
    private bool pickable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickable && gameObject.activeInHierarchy)
        {
            Pickup();
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

    void Pickup()
    {
        inventory.inventory.Add(gameObject);
        gameObject.SetActive(false);
    }
}
