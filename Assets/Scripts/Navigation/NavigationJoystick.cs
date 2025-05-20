using UnityEngine;
using UnityEngine.InputSystem;

public class NavigationJoystick : MonoBehaviour
{
    [SerializeField, Tooltip("Player to move")]
    private GameObject Player;

    [SerializeField, Tooltip("Movement speed")]
    private float MoveSpeed = 1f;
    private float RotationSpeed = 1f;

    public InputActionProperty moveRightThumbstick;
    public InputActionProperty rotationLeftThumbstick;

    private void OnEnable()
    {
        moveRightThumbstick.action.Enable();
        rotationLeftThumbstick.action.Enable();
        moveRightThumbstick.action.performed += MoveWithRightThumbstick;
        rotationLeftThumbstick.action.performed += RotationLeftThumbstick;
    }

    private void OnDisable()
    {
        moveRightThumbstick.action.performed -= MoveWithRightThumbstick;
        rotationLeftThumbstick.action.performed -= RotationLeftThumbstick;
        moveRightThumbstick.action.Disable();
        rotationLeftThumbstick.action.Disable();
    }

    private void MoveWithRightThumbstick(InputAction.CallbackContext context)
    {
        // Lire la valeur du vecteur du thumbstick droit (Vector2)
        Vector2 thumbstickValue = context.ReadValue<Vector2>();

        // Si la valeur est significative (non nulle), déplacer le joueur
        if (thumbstickValue != Vector2.zero)
        {
            Vector3 direction = new Vector3(thumbstickValue.x, 0, thumbstickValue.y) * MoveSpeed * Time.deltaTime;
            Player.transform.position += direction;
        }
    }

    private void RotationLeftThumbstick(InputAction.CallbackContext context)
    {
        Vector2 thumbstickValue = context.ReadValue<Vector2>();

        if(thumbstickValue.x != 0)
        {
            float yRotation = thumbstickValue.x * RotationSpeed * Time.deltaTime * 100f;
            Player.transform.Rotate(0, yRotation, 0);
        }
    }
}
