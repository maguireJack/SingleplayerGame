using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assembly : MonoBehaviour
{
    public Inventory inventory;
    public Material material;
    public List<GameObject> parts;
    private bool matching;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject item in inventory.inventory)
        {
            foreach(GameObject part in parts)
            {
                if (item.tag == part.tag)
                {
                    part.GetComponent<Outline>().enabled = false;
                    part.GetComponent<Renderer>().material = material;
                }
            }
        }
    }
}
