using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name; 
    public List<string> sentences = new List<string>(); 
    public GameObject pfp; 
    public int pfp_int; 
    public int nametag_int; 
    public bool fromlever; 
    public string privname; 
}
