using UnityEngine;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour
{
    [Header("Sliders")]
    public Slider bgmSlider;
    public Slider sfxSlider;

    public GameObject soundSettingsPanel;

    private void Start()
    {
        // 슬라이더 초기값 -> AudioManager의 현재 볼륨
        if (bgmSlider != null)
            bgmSlider.value = AudioManager.Instance.GetBGMVolume();

        if (sfxSlider != null)
            sfxSlider.value = AudioManager.Instance.GetSFXVolume();

        // 값 변경 시 -> AudioManager에 전달
        if (bgmSlider != null)
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);

        if (sfxSlider != null)
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void SetBGMVolume(float value)
    {
        AudioManager.Instance.SetBGMVolume(value);
    }

    private void SetSFXVolume(float value)
    {
        AudioManager.Instance.SetSFXVolume(value);
    }

    public void ToggleSoundSettingsPanel()
    {
        soundSettingsPanel.SetActive(!soundSettingsPanel.activeSelf);
    }
}
