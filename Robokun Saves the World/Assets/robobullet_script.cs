using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robobullet_script : MonoBehaviour
{
    public float speed = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        //move left rapidly 
        StartCoroutine(move()); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(-3f, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
        //if collided, terminate itself & trigger enemy 
    }

    IEnumerator move() 
    {
        //move until time passes 
        yield return new WaitForSeconds(4f); 
        //if it has not been terminated terminate ! 
        Destroy(gameObject); 
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject != GameObject.Find("robokun_front")) 
        {
            Destroy(gameObject); 
        }
    }
}
