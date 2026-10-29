using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class nextscene_battle : MonoBehaviour
{
    private bool once = false; 
    public GameObject image;
    public Animator battletext;

    // Update is called once per frame
    void Update()
    {
        if(battle_trigger.start_int == 1 && once == false) 
        {
            once = true; 
            StartCoroutine(WaitForAnim()); 
        }
    }

    IEnumerator WaitForAnim() 
    {
        battle_trigger.start_int = 0; 
        battletext.SetTrigger("move");
        yield return new WaitForSeconds(4f);
        image.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(enemy_numberstorage.return_scene); 
    }
}
