using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider vfxSlider;

    void Start()
    {
        Debug.Log(PlayerPrefs.GetFloat("masterVolume"));
        Debug.Log(PlayerPrefs.GetFloat("musicVolume"));
        Debug.Log(PlayerPrefs.GetFloat("vfxVolume"));
        if (PlayerPrefs.HasKey("masterVolume") || PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("vfxVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetGeneralVolume();
            SetMusicVolume();
            SetVfxVolume();
        }
    }

    void LoadVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        SetGeneralVolume();
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();
        vfxSlider.value =  PlayerPrefs.GetFloat("vfxVolume");
        SetVfxVolume();
        Debug.Log("INIT SOUND LEVELS");
    }

    public void SetGeneralVolume()
    {
        float volume =  masterSlider.value;
        myMixer.SetFloat("Master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetVfxVolume()
    {
        float volume = vfxSlider.value;
        myMixer.SetFloat("VFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("vfxVolume", volume);
    }
}