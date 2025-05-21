using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class VRScrollHandler : MonoBehaviour
{
    [Header("Reference")]
    public ScrollRect scrollRect;
    public Transform leftController;
    public InputActionProperty primaryButtonAction;
    public PanneauInteract panneauInteract;

    [Header("Scroll settings")]
    public float scrollReact = 0.5f;

    private float lastY;


    private void OnEnable()
    {
        primaryButtonAction.action.Enable();
        primaryButtonAction.action.started += OnPrimaryButtonPressed;
        primaryButtonAction.action.canceled += OnPrimaryButtonReleased;
    }

    private void OnDisable()
    {
        primaryButtonAction.action.started -= OnPrimaryButtonPressed;
        primaryButtonAction.action.canceled -= OnPrimaryButtonReleased;
        primaryButtonAction.action.Disable();
    }

    private void OnPrimaryButtonPressed(InputAction.CallbackContext context)
    {
        panneauInteract.isGrabbing = true;
        lastY = leftController.position.y;
    }

    private void OnPrimaryButtonReleased(InputAction.CallbackContext context)
    {
        panneauInteract.isGrabbing = false;
    }

    private void Update()
    {
        if (panneauInteract.isGrabbing)
        {
            float currentY = leftController.position.y;
            float deltaY = currentY - lastY;

            scrollRect.verticalNormalizedPosition += deltaY * scrollReact;

            scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollRect.verticalNormalizedPosition);
            lastY = currentY;
        }
    }


}
