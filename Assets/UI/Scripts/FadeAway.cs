using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeAway : MonoBehaviour
{
    public float fadeTime;  // Time it takes for the text to fade away
    private TextMeshProUGUI fadeAwayText;
    private float originalFadeTime; // Store the original fade time
    private float alphaValue;
    private float fadeAwayPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        fadeAwayText = GetComponent<TextMeshProUGUI>();
        originalFadeTime = fadeTime; // Store the original fade time value
        fadeAwayPerSecond = 1 / fadeTime;
        alphaValue = fadeAwayText.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        // If fading time is not over
        if (fadeTime > 0)
        {
            fadeTime -= Time.deltaTime;
            alphaValue -= fadeAwayPerSecond * Time.deltaTime;
            fadeAwayText.color = new Color(fadeAwayText.color.r, fadeAwayText.color.g, fadeAwayText.color.b, alphaValue);
        }
        else
        {
            // Reset alpha and fade time once fade is done
            fadeTime = originalFadeTime;
            alphaValue = 1.0f;  // Reset alpha to fully visible
        }
    }
}
