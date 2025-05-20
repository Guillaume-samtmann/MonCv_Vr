using UnityEngine;
using UnityEngine.InputSystem;

public class NavigationTeleport : MonoBehaviour
{
    [SerializeField, Tooltip("Player to move")]
    private GameObject Player;

    [SerializeField, Tooltip("Movement speed")]
    private float MoveSpeed = 1f;

    [SerializeField, Tooltip("Show ray and find target destination")]
    private HandRayCastParabolic HandRayCastParolic;

    public InputActionProperty teleportAnimAction;

    private void OnEnable()
    {
        teleportAnimAction.action.started += StartTeleportAim;
        teleportAnimAction.action.canceled += Teleport;
        teleportAnimAction.action.Enable();
    }

    private void OnDisable()
    {
        teleportAnimAction.action.started -= StartTeleportAim;
        teleportAnimAction.action.canceled -= Teleport;
        teleportAnimAction.action.Disable();
    }

    private void StartTeleportAim(InputAction.CallbackContext context)
    {
        HandRayCastParolic.gameObject.SetActive(true);
    }

    private void Teleport(InputAction.CallbackContext context)
    {
        if (HandRayCastParolic.gameObject.activeSelf)
        {
            Vector3 destination = HandRayCastParolic.CollidingPosition();
            Player.transform.position = new Vector3(destination.x, Player.transform.position.y, destination.z);
            HandRayCastParolic.gameObject.SetActive(false);
        }
    }
}
