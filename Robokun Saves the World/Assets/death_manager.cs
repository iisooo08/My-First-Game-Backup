using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class death_manager : MonoBehaviour
{
    public TextMeshProUGUI COD; 
    public static string CODtext;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 19)
        {
            COD.text = CODtext;
        }
    }
}
