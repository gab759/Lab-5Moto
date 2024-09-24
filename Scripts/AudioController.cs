using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixer _compAudioMixer;
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSfx;

    public void SetVolumenMaster()
    {
        float volumen = sliderMaster.value;
        _compAudioMixer.SetFloat("Master", Mathf.Log10(volumen) * 20);
    }
    public void SetVolumenMusic()
    {
        float volumen = sliderMusic.value;
        _compAudioMixer.SetFloat("Music", Mathf.Log10(volumen) * 20);
    }
    public void SetVolumenSfx()
    {
        float volumen = sliderSfx.value;
        _compAudioMixer.SetFloat("SFX", Mathf.Log10(volumen) * 20);
    }
}