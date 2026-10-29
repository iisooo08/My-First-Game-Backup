using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(termination()); 
    }

    void Update() 
    {
        if(GameObject.Find("robokun_front").GetComponent<battle_move>().collided == true) 
        {
            GameObject.Find("robokun_front").GetComponent<battle_move>().collided = false; 
            GameObject.Find("battlemanager").GetComponent<battle_manager>().hurtnum = 8; 
        }
    }

    IEnumerator termination() 
    {
        yield return new WaitForSeconds(2f); 
        Destroy(gameObject); 
    }

}
