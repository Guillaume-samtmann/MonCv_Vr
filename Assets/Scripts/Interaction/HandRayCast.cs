using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HandRayCast : MonoBehaviour
{
    [SerializeField, Tooltip("Line to show the ray")]
    private RayLine Line;

    [SerializeField, Tooltip("Max ray distance")]
    private float MaxDisance = 5;

    public InputActionProperty triggerAction;

    [Header("UI Panels")]
    public GameObject panel1;
    public GameObject panel2;


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

    // Update is called once per frame
    void Update()
    {
        Line.SetLinePoints(new Vector3[] { transform.position, transform.position + transform.up * MaxDisance });
        Line.MakeValid(ObjectInRay() != null);
    }


    public Component ObjectInRay()
    {
        Ray ray = new Ray(origin: transform.position, direction: transform.up);
        RaycastHit hit;
        if(Physics.Raycast(ray: ray, hitInfo: out hit, maxDistance: MaxDisance, layerMask: LayerMask.GetMask("Interactable", "UIInteractable")))
        {
            return hit.collider.GetComponent<Interactable>() ?? (Component)hit.collider.GetComponent<Button>();

        }
        return null;
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        Component target = ObjectInRay();
        if (target is Button button)
        {
            if(button.gameObject.name == "ButtonPanel1")
            {
                button.onClick.Invoke();
                ShowNextPanel();
            }
            if (button.gameObject.name == "Btnhaut1")
            {
                button.onClick.Invoke();
                ShowPreviousPanel();
            }
        }
    }

    public void ShowNextPanel()
    {
        if (panel1 != null)
            panel1.SetActive(false);
        if (panel2 != null)
            panel2.SetActive(true);
    }
    public void ShowPreviousPanel()
    {
        if (panel2 != null)
            panel2.SetActive(false);
        if (panel1 != null)
            panel1.SetActive(true);
    }
}
