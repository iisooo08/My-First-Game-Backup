using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hit : MonoBehaviour
{
    void OnTriggerEnter2D() 
    {
        GameObject.Find("battlemanager").GetComponent<battle_manager>().current_enemy_HP -= 10; 
    }

    public void kill() 
{
        Destroy(GameObject.Find("battlemanager").GetComponent<battle_manager>().enemyobj); 
}
}


