using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class canvaExperience : MonoBehaviour
{
    public HandRayCast handRayCast;
    public InputActionProperty triggerAction;

    [Header("UI Panels")]
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    [Header("UI Panels profil/apropos")]
    public GameObject panelProfil;
    public GameObject panelApropos;

    [Header("UI Panels passion")]
    public GameObject menuPassion;
    public GameObject LesCourse;


    private void OnEnable()
    {
        triggerAction.action.performed += OnInteract;
        triggerAction.action.Enable();
    }

    private void OnDisable()
    {
        triggerAction.action.performed -= OnInteract;
        triggerAction.action.Disable();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        Component target = handRayCast.ObjectInRay();
        if (target is Button button)
        {
            if (button.gameObject.name == "ButtonPanel1")
            {
                button.onClick.Invoke();
                ShowNextPanel();
            }
            if (button.gameObject.name == "Btnhaut1")
            {
                button.onClick.Invoke();
                ShowPreviousPanel();
            }
            if (button.gameObject.name == "ButtonPreviousPanel")
            {
                button.onClick.Invoke();
                showLastPanel();
            }
            if (button.gameObject.name == "btnPanel2")
            {
                button.onClick.Invoke();
                showPanel2();
            }
            if(button.gameObject.name == "ShowApropos")
            {
                button.onClick.Invoke();
                showApropos();
            }
            if (button.gameObject.name == "showProfil")
            {
                button.onClick.Invoke();
                showProfil();
            }
            if(button.gameObject.name == "ButtonCourse")
            {
                button.onClick.Invoke();
                showAllCourse();
            }
        }
    }

    public void ShowNextPanel()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
    public void ShowPreviousPanel()
    {
        panel2.SetActive(false);
        panel1.SetActive(true);
    }

    public void showLastPanel()
    {
        panel2.SetActive(false);
        panel3.SetActive(true);
    }

    public void showPanel2()
    {
        panel3.SetActive(false);
        panel2.SetActive(true);
    }

    public void showApropos()
    {
        panelProfil.SetActive(false);
        panelApropos.SetActive(true);
    }

    public void showProfil()
    {
        panelProfil.SetActive(true);
        panelApropos.SetActive(false);
    }

    public void showAllCourse()
    {
        menuPassion.SetActive(false);
        LesCourse.SetActive(true);
    }
}
