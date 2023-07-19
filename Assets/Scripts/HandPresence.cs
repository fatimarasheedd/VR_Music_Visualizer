using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public InputDevice targetDevice;

    public float startDelay = 3.0f; // The delay time in seconds

    // Start is called before the first frame update
    IEnumerator Start()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(startDelay);

        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            UnityEngine.Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue){
            UnityEngine.Debug.Log("Pressing primary button");
        }
    }
}
