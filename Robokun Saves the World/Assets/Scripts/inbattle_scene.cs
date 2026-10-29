using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inbattle_scene : MonoBehaviour
{
    public Animator canvasanim; 
    // Start is called before the first frame update
    void Start()
    {
        canvasanim.SetTrigger("fade"); 
    }
}
