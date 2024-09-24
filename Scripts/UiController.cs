using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiController : MonoBehaviour
{
    public Button myButton; 
    public AudioClip soundClip; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip; 
        myButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
            audioSource.Play();   
    }
}