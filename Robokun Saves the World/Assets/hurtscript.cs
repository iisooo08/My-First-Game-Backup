using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtscript : MonoBehaviour
{

    void Update() 
    {
        if(GameObject.Find("robokun_front").GetComponent<battle_move>().collided == true) 
        {
            GameObject.Find("robokun_front").GetComponent<battle_move>().collided = false; 
            GameObject.Find("battlemanager").GetComponent<battle_manager>().hurtnum = 4; 
        }
    }
}
