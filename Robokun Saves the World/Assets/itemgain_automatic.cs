using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemgain_automatic : MonoBehaviour
{
    public List<GameObject> spawnframes;

    public void AddItem(string itemcode, GameObject itemprefab)
    {
        Instantiate(itemprefab, spawnframes[Tempinvent_items.tempinventnum].transform.position, Quaternion.identity, spawnframes[Tempinvent_items.tempinventnum].transform);
        Tempinvent_items.tempinventnum += 1;
        GameObject.Find("Tempinvent_items").GetComponent<Tempinvent_items>().AddToList(itemcode);
    }
}
