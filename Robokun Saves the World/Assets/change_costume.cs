using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_costume : MonoBehaviour
{
    public GameObject originalobject;
    // Start is called before the first frame update
    void Start()
    {
        originalobject.SetActive(false);
    }
}
