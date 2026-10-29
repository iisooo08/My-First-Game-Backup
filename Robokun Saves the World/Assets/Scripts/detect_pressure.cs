using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_pressure : MonoBehaviour
{
    private int num; 
    public Rigidbody2D rb; 
    public Animator anim; 
    public Animator controlleranim; 
    public Animator octopusanim; 
    public Animator octopusanim2; 
    private int once; 
    public GameObject temp_collider; 
    public GameObject cinemachinemanager; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("robokun_front").GetComponent<Rigidbody2D>(); 
        temp_collider.SetActive(false); 
        cinemachinemanager = GameObject.Find("cinemachinemanager"); 
    }

    // Update is called once per frame
    void Update()
    {
        if(num == 2 && once == 0) 
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; 
            StartCoroutine(LightAnim()); 
        }
    }

    void OnTriggerEnter2D(Collider2D trigger) 
    {
        if(trigger.gameObject.name == "robokun_front") 
        {
            num += 1; 
        }
    }

    IEnumerator LightAnim() 
    {
        once = 1; 
        anim.SetTrigger("show"); 
        yield return new WaitForSeconds(1f); 
        anim.SetTrigger("hide"); 
        yield return new WaitForSeconds(0.2f); 
        anim.SetTrigger("show"); 
        yield return new WaitForSeconds(0.2f); 
        anim.SetTrigger("hide"); 
        yield return new WaitForSeconds(0.2f); 
        anim.SetTrigger("show"); 
        controlleranim.SetTrigger("crash"); 
        octopusanim.SetTrigger("escape"); 
        yield return new WaitForSeconds(2f); 
        anim.SetTrigger("hide"); 
        temp_collider.SetActive(true); 
        yield return new WaitForSeconds(0.2f); 
        cinemachinemanager.GetComponent<Cinemachine_priorityswitch>().SwitchPriority(); 
        yield return new WaitForSeconds(5f); 
        octopusanim.SetTrigger("escape2"); 
        octopusanim2.SetTrigger("move"); 
        yield return new WaitForSeconds(2.5f); 
        enemy_numberstorage.enemy_num_temp = 1;
        enemy_numberstorage.return_scene = 7;
        print(enemy_numberstorage.enemy_num_temp);
        battle_trigger.start_int = 1; 
    }
}
