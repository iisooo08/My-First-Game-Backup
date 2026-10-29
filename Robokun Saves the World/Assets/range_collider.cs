using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range_collider : MonoBehaviour
{
    public static bool punch_inrange = false;
    public Animator circleAnim;
    public GameObject enemy; 
    public GameObject robokun; 

    void Start()
    {
        circleAnim = gameObject.GetComponent<Animator>();
        enemy = GameObject.FindWithTag("enemy"); 
        robokun = GameObject.Find("robokun_front");
    }

    void Update() 
    {
        if(Vector2.Distance(robokun.transform.position, enemy.transform.position) <= 2.25f)
        {
            punch_inrange = true;
            circleAnim.SetBool("contact", true); 
        }
        else
        {
            punch_inrange = false;
            circleAnim.SetBool("contact", false);
        }
    }
}
