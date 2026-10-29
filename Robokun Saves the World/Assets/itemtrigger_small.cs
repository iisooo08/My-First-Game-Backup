using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemtrigger_small : MonoBehaviour
{
    public GameObject itemprefab;
    public string itemcode;
    public List<GameObject> spawnframes;
    private bool once = false;
    private bool touching = false;

    void Update()
    {
        if(once == false && Input.GetKeyDown("return") && touching == true)
        {
            once = true;
            GameObject.Find("automatic_items").GetComponent<itemgain_automatic>().AddItem(itemcode, itemprefab);
        }
    }
    
    void OnCollisionEnter2D()
    {
        touching = true;

    }
    void OnCollisionExit2D()
    {
        touching = false;
    }
}
