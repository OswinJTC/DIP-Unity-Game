using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite hoverSprite; // The image to show when hovering
    private Sprite originalSprite; // To store the original button image

    private Image buttonImage;
    private TextMeshProUGUI buttonText; // Reference to the text component

    public float brightnessMultiplier = 1.5f; // Factor by which to increase brightness
    private Color originalColor; // To store the original color of the button image

    public Vector2 hoverSize = new Vector2(200, 100); // The size of the button when hovering
    private Vector2 originalSize; // To store the original size of the button

    private RectTransform rectTransform; // Reference to the RectTransform component for size adjustment

    void Start()
    {
        // Get the Button's Image component
        buttonImage = GetComponent<Image>();
        if (buttonImage == null)
        {
            Debug.LogError("Button Image component is missing.");
        }
        else
        {
            originalSprite = buttonImage.sprite; // Save the original sprite
            originalColor = buttonImage.color;   // Save the original color
        }

        // Get the Button's TextMeshProUGUI component (the text)
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText == null)
        {
            Debug.LogError("TextMeshProUGUI component is missing.");
        }

        // Get the RectTransform component to adjust the size
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            originalSize = rectTransform.sizeDelta; // Save the original size of the button
        }
        else
        {
            Debug.LogError("RectTransform component is missing.");
        }
    }

    // Called when the mouse starts hovering over the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Change the button image to the hover image
        buttonImage.sprite = hoverSprite;

        // Change image type to Simple to avoid any issues with borders
        buttonImage.type = Image.Type.Simple;

        // Hide the text when hovering
        buttonText.enabled = false;

        // Brighten the image by multiplying the color
        Color brightColor = originalColor * brightnessMultiplier;
        brightColor.a = originalColor.a; // Keep the original alpha value (transparency)
        buttonImage.color = brightColor;

        // Change the size of the button/image when hovering
        rectTransform.sizeDelta = hoverSize;
    }

    // Called when the mouse stops hovering over the button
    public void OnPointerExit(PointerEventData eventData)
    {
        // Revert to the original image
        buttonImage.sprite = originalSprite;

        // Revert the image type (optional)
        buttonImage.type = Image.Type.Simple;

        // Show the text again when not hovering
        buttonText.enabled = true;

        // Revert to the original color
        buttonImage.color = originalColor;

        // Revert the size back to the original size
        rectTransform.sizeDelta = originalSize;
    }
}
