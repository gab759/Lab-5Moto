using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject panel; 
    public Button activateButton; 
    public Button deactivateButton;
    public Button exitButton;
    void Start()
    {
        panel.SetActive(false);
        activateButton.onClick.AddListener(ActivatePanel);
        deactivateButton.onClick.AddListener(DeactivatePanel);
        exitButton.onClick.AddListener(ExitApplication);
    }

    public void ActivatePanel()
    {
        panel.SetActive(true); 
    }

    public void DeactivatePanel()
    {
        panel.SetActive(false); 
    }
    public void ExitApplication()
    {
        Application.Quit(); 
    }
}