using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoundConfig sfx;
    [SerializeField] private Fade fade;
    public GameObject panel;
    public GameObject imagenGame;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    void Start()
    {
        panel.SetActive(false);
        imagenGame.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sfx.SoundClip;
    }

    public void ActivatePanel()
    {
        panel.SetActive(true);
        audioSource.Play();
        fade.CallComplexFadeIn();
        if (virtualCamera != null)
        {
            RotationCamera(-90f, 0f);
        }
    }
    public void ActivateImage()
    {
        imagenGame.SetActive(true);
        audioSource.Play();
        fade.CallComplexFadeIn();
        if (virtualCamera != null)
        {
            RotationCamera(-29.88f, -90f);
        }
    }
    public void DesactivateImage()
    {
        imagenGame.SetActive(false);
        audioSource.Play();
        fade.CallComplexFadeIn();
        if (virtualCamera != null)
        {
            RotationCamera(+29.88f, +90f);
        }
    }

    public void DesactivatePanel()
    {
        panel.SetActive(false);
        audioSource.Play();
        fade.CallComplexFadeIn();
        if (virtualCamera != null)
        {
            RotationCamera(90f, 0f);
        }
    }
    public void ExitApplication()
    {
        audioSource.Play();
        Application.Quit();  
    }
    void RotationCamera(float valueX, float valueY)
    {
        Vector3 currentRotation = virtualCamera.transform.rotation.eulerAngles;
        Quaternion newRotation = Quaternion.Euler(currentRotation.x + valueX, currentRotation.y + valueY, currentRotation.z);
        virtualCamera.transform.rotation = newRotation;
    }
}