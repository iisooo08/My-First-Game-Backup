using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robobullet : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(0f, 1f) *  3 * Time.deltaTime;
        transform.Translate(movement);
    }
}
