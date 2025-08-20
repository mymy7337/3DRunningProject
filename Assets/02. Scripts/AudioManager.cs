using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip[] bgmClips;
    public AudioClip[] sfxClips;

    [Header("Default Volumes")]
    [Range(0f, 1f)] public float defaultBGMVolume = 0.4f;
    [Range(0f, 1f)] public float defaultSFXVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {
        // 루프 설정
        bgmSource.loop = true;

        // 저장된 볼륨 불러오기
        float bgmVol = PlayerPrefs.GetFloat("BGMVolume", defaultBGMVolume);
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", defaultSFXVolume);

        SetBGMVolume(bgmVol);
        SetSFXVolume(sfxVol);

        // 첫 번째 BGM 자동 실행
        if (bgmClips.Length > 0)
            PlayBGM(0);
    }

    public void PlayBGM(int index)
    {
        if (index < 0 || index >= bgmClips.Length) return;

        // 같은 곡 중복 재생 방지
        if (bgmSource.clip == bgmClips[index] && bgmSource.isPlaying) return;

        bgmSource.clip = bgmClips[index];
        bgmSource.Play();
    }

    public void PlaySFX(int index)
    {
        if (index < 0 || index >= sfxClips.Length) return;
        sfxSource.PlayOneShot(sfxClips[index]);
    }

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = Mathf.Clamp01(volume);
        PlayerPrefs.SetFloat("BGMVolume", bgmSource.volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = Mathf.Clamp01(volume);
        PlayerPrefs.SetFloat("SFXVolume", sfxSource.volume);
    }

    public float GetBGMVolume() => bgmSource.volume;
    public float GetSFXVolume() => sfxSource.volume;
}
