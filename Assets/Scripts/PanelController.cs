using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [Header("Atributos Sonidos")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoundConfig sfx;
    //[SerializeField] private Fade fade;
    public GameObject panel;
    public GameObject imagenGame;
    private Quaternion targetRotation;
    [SerializeField] private GameObject image;
    [SerializeField] private float rotationSpeed = 1f;
    [Header("Atributos de la Camara")]
    [SerializeField] private float targetFOV = 120f;
    [SerializeField] private float targetDutch = 180f;
    [SerializeField] private float effectDuration = 2f;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    void Start()
    {
        panel.SetActive(false);
        imagenGame.SetActive(false);
        image.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sfx.SoundClip;

        if (virtualCamera != null)
        {
            targetRotation = virtualCamera.transform.rotation;
        }
    }

    private void Update()
    {
        if (virtualCamera != null)
        {
            virtualCamera.transform.rotation = Quaternion.Slerp(
                virtualCamera.transform.rotation,
                targetRotation,
                Time.deltaTime * rotationSpeed
            );
        }
    }

    public void ActivatePanel()
    {
        panel.SetActive(true);
        audioSource.Play();
        RotationCamera(-90f, 0f, 0f);
    }

    public void ActivateImage()
    {
        imagenGame.SetActive(true);
        audioSource.Play();
        RotationCamera(-40f, -90f, 0f);
    }

    public void DesactivateImage()
    {
        imagenGame.SetActive(false);
        audioSource.Play();
        RotationCamera(0f, 0f, 0f);
    }

    public void DesactivatePanel()
    {
        panel.SetActive(false);
        audioSource.Play();
        RotationCamera(0f, 0f, 0f);
    }

    public void ExitApplication()
    {
        image.SetActive(true);
        audioSource.Play();
        StartCoroutine(ExitWithEffect());
    }

    private void RotationCamera(float valueX, float valueY, float valueZ)
    {
        if (virtualCamera != null)
        {
            targetRotation = Quaternion.Euler(valueX, valueY, valueZ);
        }
    }
    private IEnumerator ExitWithEffect()
    {
        float elapsedTime = 0f;
        float initialFOV = virtualCamera.m_Lens.FieldOfView;
        float initialDutch = virtualCamera.m_Lens.Dutch;

        while (elapsedTime < effectDuration)
        {
            elapsedTime += Time.deltaTime;

            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(initialFOV, targetFOV, elapsedTime / effectDuration);
            virtualCamera.m_Lens.Dutch = Mathf.Lerp(initialDutch, targetDutch, elapsedTime / effectDuration);

            yield return null;
        }

        Application.Quit();
    }
}