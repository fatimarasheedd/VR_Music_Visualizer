using UnityEngine;
using UnityEngine.UI;

public class ImageColourChanger : MonoBehaviour
{
    public GameObject flexibleColorPicker;
    private Image currentImage;

    public void OnImageClick(Image image)
    {
        currentImage = image;
        Color imageColor = image.color;
        flexibleColorPicker.GetComponent<FlexibleColorPicker>().SetColor(imageColor);
    }

    public void OnColorChange(Color newColor)
    {
        if (currentImage != null)
        {
            currentImage.color = newColor;
        }
    }
}
