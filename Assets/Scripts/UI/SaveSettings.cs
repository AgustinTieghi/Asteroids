using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SaveSettings : MonoBehaviour
{
    [SerializeField] private Slider SFXslider;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private AudioMixer SFXMixer;   
    [SerializeField] private AudioMixer MusicMixer;
    private float SFXvolume;
    private float MusicVolume;
    public string SFXKey; 
    public string MusicKey;
    void Start()
    {
        if (PlayerPrefs.HasKey(SFXKey))
        {
            SFXslider.value = PlayerPrefs.GetFloat(SFXKey);
        }
        if (PlayerPrefs.HasKey(MusicKey))
        {
            MusicSlider.value = PlayerPrefs.GetFloat(MusicKey);
        }
    }

    public void SaveVol()
    {
        SFXvolume = SFXslider.value;
        PlayerPrefs.SetFloat(SFXKey, SFXvolume);
        MusicVolume = MusicSlider.value;
        PlayerPrefs.SetFloat(MusicKey, MusicVolume);
        PlayerPrefs.Save();
    }
}
