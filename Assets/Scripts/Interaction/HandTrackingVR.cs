using UnityEngine;
using UnityEngine.InputSystem;

public class HandTrackingVR : MonoBehaviour
{
    public InputActionProperty positionAction;
    public InputActionProperty rotationAction;
    public InputActionProperty primaryAction;

    public HandRayCast HandRay;
    
    void Start()
    {
        positionAction.action.Enable();
        rotationAction.action.Enable();
        primaryAction.action.Enable();

        positionAction.action.performed += UpdatePos;
        rotationAction.action.performed += UpdateRot;
        //primaryAction.action.started += StartRayCast;
        primaryAction.action.canceled += Interact;
    }

    private void OnDestroy()
    {
        positionAction.action.performed -= UpdatePos;
        rotationAction.action.performed -= UpdateRot;
        //primaryAction.action.started -= StartRayCast;
        primaryAction.action.canceled -= Interact;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        Interactable interactableObject = HandRay.ObjectInRay();
        if (interactableObject != null ) interactableObject.Interact();
        HandRay.gameObject.SetActive( false );
    }

    /*private void StartRayCast(InputAction.CallbackContext context)
    {
        HandRay.gameObject.SetActive(true);
    }*/

    private void UpdatePos(InputAction.CallbackContext context)
    {
        transform.localPosition = context.ReadValue<Vector3>();
    }

    private void UpdateRot(InputAction.CallbackContext context)
    {
        transform.localRotation = context.ReadValue<Quaternion>();
    }
}
