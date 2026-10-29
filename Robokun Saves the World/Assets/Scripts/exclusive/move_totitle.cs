using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_totitle : MonoBehaviour
{
    private int once; 
    public GameObject robokun; 
    public GameObject pos; 
    // Start is called before the first frame update
    void Start()
    {
        robokun = GameObject.Find("robokun_front"); 
        pos = GameObject.Find("pos1"); 

        if(once > 0) 
        {
            robokun.transform.position = pos.transform.position; 
        }
        else if(once == 0) 
        {
            once += 1; 
        }
    }
}
