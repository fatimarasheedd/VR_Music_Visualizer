using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectClickHandler : MonoBehaviour
{
    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Handle the object click event here
        Debug.Log("Object Clicked: " + gameObject.name);
    }
}
