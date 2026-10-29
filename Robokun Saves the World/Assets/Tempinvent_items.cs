using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tempinvent_items : MonoBehaviour
{
    public List<string> itemcodes;
    public static int tempinventnum;

    public void AddToList(string item)
    {
        itemcodes.Add(item);
    }
    public bool CheckifinList(string item)
    {
        for(int x = 0; x < itemcodes.Count; x++)
        {
            if(item == itemcodes[x])
            {
                return true;
            }
        }
        return false;
    }
}