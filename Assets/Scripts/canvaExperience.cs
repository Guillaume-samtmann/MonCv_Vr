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

    [Header("Les course")]
    public GameObject course1;
    public GameObject course2;
    public GameObject course3;
    public GameObject course4;
    public GameObject course5;
    public GameObject btnGauche;
    public GameObject btnDroit;

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
            if(button.gameObject.name == "Droite")
            {
                button.onClick.Invoke();
                showImgCourse();
            }
            if (button.gameObject.name == "Gauche")
            {
                button.onClick.Invoke();
                showImgCourseGauche();
            }
            if (button.gameObject.name == "retourCourse")
            {
                button.onClick.Invoke();
                retourCourse();
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
    public void showImgCourse()
    {
        if (course1.activeInHierarchy)
        {
            course1.SetActive(false);
            course2.SetActive(true);
            btnGauche.SetActive(true);
        }
        else if (course2.activeInHierarchy)
        {
            course2.SetActive(false);
            course3.SetActive(true);
        }
        else if (course3.activeInHierarchy)
        {
            course3.SetActive(false);
            course4.SetActive(true);
        }
        else if (course4.activeInHierarchy)
        {
            course4.SetActive(false);
            course5.SetActive(true);
            btnDroit.SetActive(false);
        }
    }

    public void showImgCourseGauche()
    {
        if (course2.activeInHierarchy)
        {
            course2.SetActive(false);
            course1.SetActive(true);
            btnGauche.SetActive(false);
        }
        else if (course3.activeInHierarchy)
        {
            course3.SetActive(false);
            course2.SetActive(true);
        }
        else if (course4.activeInHierarchy)
        {
            course4.SetActive(false);
            course3.SetActive(true);
        }
        else if (course5.activeInHierarchy)
        {
            course5.SetActive(false);
            course4.SetActive(true);
            btnDroit.SetActive(true);
        }
    }

    public void retourCourse()
    {
        menuPassion.SetActive(true);
        LesCourse.SetActive(false);
    }
}
