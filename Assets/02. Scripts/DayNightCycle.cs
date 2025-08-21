using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Range(0f, 1f)]
    public float time;
    public float fullDayLength;
    public float startTime = 0.4f;
    private float timeRate;
    public Vector3 noon;

    [Header("Sun")]
    public Light sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity; // ³·¿¡¸¸ ÄÑÁü

    [Header("Moon")]
    public Light moon;
    public Gradient moonColor;
    public AnimationCurve moonIntensity; // ¹ã¿¡¸¸ ÄÑÁü

    [Header("Other Lighting")]
    public Gradient ambientColor; // ÀüÃ¼ ¾À Åæ
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionIntensityMultiplier;

    private void Start()
    {
        timeRate = 1f / fullDayLength;
        time = startTime;
    }

    private void Update()
    {
        time = (time + timeRate * Time.deltaTime) % 1f;

        // Sun°ú Moon ¾÷µ¥ÀÌÆ® (offsetÀ¸·Î ±¸ºÐ)
        UpdateLighting(sun, sunColor, sunIntensity);
        UpdateLighting(moon, moonColor, moonIntensity);


        // ³·/¹ã¿¡ ¸Â°Ô Sun Source ±³Ã¼
        if (time >= 0.25f && time <= 0.75f) // ³·
            RenderSettings.sun = sun;
        else // ¹ã
            RenderSettings.sun = moon;

        // ÀüÃ¼ È¯°æ±¤°ú ¹Ý»ç±¤
        RenderSettings.ambientLight = ambientColor.Evaluate(time);
        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity = reflectionIntensityMultiplier.Evaluate(time);
    }

    void UpdateLighting(Light lightSource, Gradient colorGradient, AnimationCurve intensityCurve)
    {
        // ¹à±â °è»ê
        float intensity = intensityCurve.Evaluate(time);

        // È¸Àü °è»ê
        lightSource.transform.eulerAngles = (time - (lightSource == sun ? 0.25f : 0.75f)) * noon * 4f;

        // »ö»ó ¹× ¹à±â Àû¿ë
        lightSource.color = colorGradient.Evaluate(time);
        lightSource.intensity = intensity;

        GameObject go = lightSource.gameObject;
        if (lightSource.intensity == 0 && go.activeInHierarchy)
            go.SetActive(false);
        else if (lightSource.intensity > 0 && !go.activeInHierarchy)
            go.SetActive(true);
    }
}
