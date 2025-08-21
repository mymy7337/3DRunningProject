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
    public AnimationCurve sunIntensity; // 낮에만 켜짐

    [Header("Moon")]
    public Light moon;
    public Gradient moonColor;
    public AnimationCurve moonIntensity; // 밤에만 켜짐

    [Header("Other Lighting")]
    public Gradient ambientColor; // 전체 씬 톤
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

        // Sun과 Moon 업데이트 (offset으로 구분)
        UpdateLighting(sun, sunColor, sunIntensity);
        UpdateLighting(moon, moonColor, moonIntensity);


        // 낮/밤에 맞게 Sun Source 교체
        if (time >= 0.25f && time <= 0.75f) // 낮
            RenderSettings.sun = sun;
        else // 밤
            RenderSettings.sun = moon;

        // 전체 환경광과 반사광
        RenderSettings.ambientLight = ambientColor.Evaluate(time);
        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity = reflectionIntensityMultiplier.Evaluate(time);
    }

    void UpdateLighting(Light lightSource, Gradient colorGradient, AnimationCurve intensityCurve)
    {
        // 밝기 계산
        float intensity = intensityCurve.Evaluate(time);

        // 회전 계산
        lightSource.transform.eulerAngles = (time - (lightSource == sun ? 0.25f : 0.75f)) * noon * 4f;

        // 색상 및 밝기 적용
        lightSource.color = colorGradient.Evaluate(time);
        lightSource.intensity = intensity;

        GameObject go = lightSource.gameObject;
        if (lightSource.intensity == 0 && go.activeInHierarchy)
            go.SetActive(false);
        else if (lightSource.intensity > 0 && !go.activeInHierarchy)
            go.SetActive(true);
    }
}
