using UnityEngine;

public class HandRayCast : MonoBehaviour
{
    [SerializeField, Tooltip("Line to show the ray")]
    private RayLine Line;

    [SerializeField, Tooltip("Max ray distance")]
    private float MaxDisance = 5;

    // Update is called once per frame
    void Update()
    {
        Line.SetLinePoints(new Vector3[] { transform.position, transform.position + transform.up * MaxDisance });
        Line.MakeValid(ObjectInRay() != null);
    }


    public Interactable ObjectInRay()
    {
        Ray ray = new Ray(origin: transform.position, direction: transform.up);
        RaycastHit hit;
        if(Physics.Raycast(ray: ray, hitInfo: out hit, maxDistance: MaxDisance, layerMask: LayerMask.GetMask("Interactable")))
        {
            return hit.collider.gameObject.GetComponent<Interactable>();
        }
        return null;
    }
}
