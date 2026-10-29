using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ink_robokun_color : MonoBehaviour
{
    public GameObject robokun;
    private string itemcode = "ink";
    public GameObject ink_prefab;

    // Start is called before the first frame update
    void Start()
    {
        robokun.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        GameObject.Find("automatic_items").GetComponent<itemgain_automatic>().AddItem(itemcode, ink_prefab);
    }
}
