using UnityEngine;

[RequireComponent (typeof(Collider))]
public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact();

    [Tooltip("Keyboard key to interact with the object (for debug purpose)")]
    public KeyCode key;

    public void Update()
    {
        if(Input.GetKeyDown (key)) Interact();
    }
}
