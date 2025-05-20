using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RayLine : MonoBehaviour
{
    [SerializeField, Tooltip("Material when ray is invalid")]
    private Material InvalidMaterial;

    [SerializeField, Tooltip("Material when ray in valid")]
    private Material ValidMaterial;

    public void MakeValid(bool valid)
    {
        GetComponent<LineRenderer>().material = valid ? ValidMaterial : InvalidMaterial;
    }

    public void SetLinePoints(List<Vector3> positions)
    {
        GetComponent<LineRenderer>().positionCount = positions.Count;
        GetComponent<LineRenderer>().SetPositions(positions.ToArray());
    }

    public void SetLinePoints(Vector3[] positions) 
    {
        GetComponent<LineRenderer>().positionCount = positions.Length;
        GetComponent<LineRenderer>().SetPositions(positions);
    }
}
