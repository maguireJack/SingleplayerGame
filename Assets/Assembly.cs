using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assembly : MonoBehaviour
{
    public Inventory inventory;
    public Material material;
    public List<GameObject> parts;
    public List<GameObject> activeParts;
    public List<bool> enableds;
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
                    //enableds[parts.IndexOf(part)] = true;
                    
                }
            }
        }
        //if(enableds.Count >= 5)
        //{
        //    //win
        //    Debug.Log("Win");
        //}
    }

}
