using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeAwayImage: MonoBehaviour
{

    public float fadeTime;  // Time it takes for the text to fade away
    private Image fadeAway;
    private float originalFadeTime; // Store the original fade time
    private float alphaValue;
    private float fadeAwayPerSecond;


    // Start is called before the first frame update
    void Start()
    {
        fadeAway = GetComponent<Image>();
        originalFadeTime = fadeTime; // Store the original fade time value
        fadeAwayPerSecond = 1 / fadeTime;
        alphaValue = fadeAway.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        // If fading time is not over
        if (fadeTime > 0)
        {
            fadeTime -= Time.deltaTime;
            alphaValue -= fadeAwayPerSecond * Time.deltaTime;
            fadeAway.color = new Color(fadeAway.color.r, fadeAway.color.g, fadeAway.color.b, alphaValue);
        }
        else
        {
            // Reset alpha and fade time once fade is done
            fadeTime = originalFadeTime;
            alphaValue = 1.0f;  // Reset alpha to fully visible
        }
    }
}

