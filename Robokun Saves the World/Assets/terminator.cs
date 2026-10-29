using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terminator : MonoBehaviour
{
    public float time; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(termination()); 
    }

    IEnumerator termination() 
    {
        yield return new WaitForSeconds(time); 
        Destroy(gameObject); 
    }
}
