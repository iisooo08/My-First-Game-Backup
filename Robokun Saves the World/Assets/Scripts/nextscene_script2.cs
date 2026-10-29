using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class nextscene_script2 : MonoBehaviour
{
    public Animator canvasanim; 
    public static int spos; 
    public List<Transform> positions; 
    public List<int> prevscene_num; 
    public int listnum; 
    public Transform robokun; 

    void Start()
    {
        for(int x = 0; x < prevscene_num.Count; x++) 
        {
            if(spos == prevscene_num[x] + 1) 
            {
                robokun.transform.position = positions[x].transform.position; 
            }
        }
    }


    void Update()
    { 
        spos = SceneManager.GetActiveScene().buildIndex; 
        for(int x = 0; x < prevscene_num.Count; x++) 
        {
            if(gateway_script.collided == prevscene_num[x]) 
            {
                LoadNextLevel(); 
                listnum = x; 
            }
        } 
    }    
    // }

    public void LoadNextLevel() 
    {
        StartCoroutine(waitforanim()); 
    }

    IEnumerator waitforanim() 
    {
        gateway_script.collided = -2; 
        canvasanim.SetTrigger("move"); 
        yield return new WaitForSeconds(0.5f); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 + (prevscene_num[listnum] - SceneManager.GetActiveScene().buildIndex));
        listnum = 0;  
    }
}


