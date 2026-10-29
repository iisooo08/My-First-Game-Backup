using UnityEngine;
using Cinemachine; 

public class Cinemachine_priorityswitch : MonoBehaviour
{
    public CinemachineVirtualCamera vcam1; 
    public CinemachineVirtualCamera vcam2; 
    private bool cam1 = true; 
    // Start is called before the first frame update

    public void SwitchPriority() 
    {
        Debug.Log("switchprioeritsnfj"); 
        if(cam1 == true) 
        {
            vcam1.Priority = 0; 
            vcam2.Priority = 1; 
            cam1 = false; 
        }
        else 
        {
            vcam1.Priority = 1; 
            vcam2.Priority = 0; 
            cam1 = true; 
        }
    }
}
