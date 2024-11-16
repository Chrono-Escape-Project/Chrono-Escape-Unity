using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light lightSource; // Assign your light here in the Inspector
    public float minIntensity = 0.5f; // Minimum light intensity
    public float maxIntensity = 2.0f; // Maximum light intensity
    public float flickerSpeed = 0.1f; // Speed of flickering
    public float smoothness = 10f; // How smoothly intensity transitions

    [Header("Color Flicker")]
    public bool enableColorFlicker = false; // Enable or disable color flickering
    public Color minColor = Color.red; // Minimum color
    public Color maxColor = Color.yellow; // Maximum color

    [Header("On/Off Flicker")]
    public bool enableOnOffFlicker = false; // Enable or disable on/off flickering
    public float onOffChance = 0.1f; // Chance (0-1) that light turns off

    [Header("Sound Effects")]
    public AudioSource flickerSound; // Assign a sound effect for flickering
    public float soundChance = 0.2f; // Chance (0-1) of playing sound during flicker

    private float targetIntensity; // Target intensity to interpolate towards
    private Color targetColor; // Target color to interpolate towards
    private float timeElapsed = 0f;

    void Start()
    {
        if (lightSource == null)
            lightSource = GetComponent<Light>();

        // Initialize the target values
        targetIntensity = Random.Range(minIntensity, maxIntensity);
        targetColor = Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.5f, 1f); // Random initial color
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= flickerSpeed)
        {
            // Set a new random intensity
            if (enableOnOffFlicker && Random.value < onOffChance)
            {
                // Occasionally turn off the light
                lightSource.enabled = !lightSource.enabled;
            }
            else
            {
                lightSource.enabled = true;
                targetIntensity = Random.Range(minIntensity, maxIntensity);
                if (enableColorFlicker)
                {
                    targetColor = new Color(
                        Random.Range(minColor.r, maxColor.r),
                        Random.Range(minColor.g, maxColor.g),
                        Random.Range(minColor.b, maxColor.b)
                    );
                }
            }

            // Optionally play a sound
            if (flickerSound && Random.value < soundChance)
            {
                flickerSound.Play();
            }

            timeElapsed = 0f;
        }

        // Smoothly transition intensity and color
        if (lightSource.enabled)
        {
            lightSource.intensity = Mathf.Lerp(lightSource.intensity, targetIntensity, Time.deltaTime * smoothness);
            if (enableColorFlicker)
            {
                lightSource.color = Color.Lerp(lightSource.color, targetColor, Time.deltaTime * smoothness);
            }
        }
    }
}
