using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script is used in the starting scene when a user is deciding how to map colour to emotion
// it uses the colour selected by the colourpicker - referenced as fcp, and applied it to the 
// material colour of the plane object in the colour mapping grid
public class ApplyColour : MonoBehaviour
{
    public FlexibleColorPicker fcp;
    public Material material;

    private void Update()
    {
        material.color = fcp.color;
    }
}

