using UnityEngine;
using UnityEngine.InputSystem;

public class PanneauInteract : MonoBehaviour
{
    private bool canCloseTab;
    public bool isGrabbing = false;
    public GameObject tab1;
    public InputActionProperty primaryAction;

    private void Start()
    {
        primaryAction.action.Enable();

        primaryAction.action.performed += CloseTab;
    }

    private void OnDestroy()
    {
        primaryAction.action.performed -= CloseTab;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("panneau1"))
        {
            canCloseTab = true;
            isGrabbing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("panneau1"))
        {
            isGrabbing = false;
        }
    }

    private void CloseTab(InputAction.CallbackContext context)
    {
        //tab1.SetActive(false);
    }
}
