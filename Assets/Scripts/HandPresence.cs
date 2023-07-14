using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);
        UnityEngine.Debug.Log("we made it here up here");

        foreach (var item in devices){
            UnityEngine.Debug.Log(item.name + item.characteristics);
            UnityEngine.Debug.Log("we made it here");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
