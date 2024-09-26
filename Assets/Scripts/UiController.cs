using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiController : MonoBehaviour
{
    public Button myButton;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoundConfig sfx;
    [SerializeField] private Image image;
    [SerializeField] private Color currentColor;
    [SerializeField] private Color starColor;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
        audioSource.clip = sfx.SoundClip;
        myButton.onClick.AddListener(OnButtonClick);
    }
    IEnumerator FadeInWait()
    {
        currentColor = starColor;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            currentColor.a = alpha;
            image.color = currentColor;
            yield return new WaitForSeconds(0.05f);
        }
    }
    void OnButtonClick()
    {
        StartCoroutine(FadeInWait());
        audioSource.Play();
    }
}