using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attk_selfdestruct : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    public float movespeed = 5f;
    public float randomStart = 4f;
    public float randomEnd = 10f;
    private Animator anim;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        movement.y = -1;
        movement.x = 0;
        StartCoroutine(randomTime());
    }

    IEnumerator randomTime()
    {
        yield return new WaitForSeconds(Random.Range(randomStart, randomEnd));
        anim.SetTrigger("explode");
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime); 
    }

    void OnCollisionEnter2D(Collision2D other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        Destroy(gameObject);
    }
}
}
