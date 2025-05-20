using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HandRayCastParabolic : MonoBehaviour
{
    [SerializeField, Tooltip("Line to show the ray")]
    private RayLine Line;

    [SerializeField, Tooltip("Max ray distance (horizontally)")]
    private float MaxDistance = 5;

    [SerializeField, Tooltip("Distance step (horizontally)")]
    private float SpaceInterval = .05f;

    private List<Vector3> CurveControlPoints = new List<Vector3>();

    private RaycastHit? collision;

    public void Update()
    {
        collision = null;
        float coveredDistance = 0;

        CurveControlPoints.Clear();
        CurveControlPoints.Add(transform.position);

        while (coveredDistance < MaxDistance && collision == null)
        {
            Vector3 startPos = transform.position + transform.forward * coveredDistance;
            startPos.y = HeightAt(coveredDistance);

            Vector3 endPos = transform.position + transform.forward * (coveredDistance + SpaceInterval);
            endPos.y = HeightAt(coveredDistance + SpaceInterval);

            collision = ObjectInSection(startPos, endPos);

            if (collision != null)
            {
                CurveControlPoints.Add(collision.Value.point);
            }
            else
            {
                CurveControlPoints.Add(endPos);
            }

            coveredDistance += SpaceInterval;
        }

        Line.SetLinePoints(CurveControlPoints);
        Line.MakeValid(collision != null);
    }

    public RaycastHit? ObjectInSection(Vector3 start, Vector3 end)
    {
        RaycastHit hit;
        Vector3 direction = end - start;
        float distance = direction.magnitude;

        int walkLayer = LayerMask.GetMask("Walk");

        if (Physics.Raycast(start, direction.normalized, out hit, distance, walkLayer))
        {

             return hit;
        }
        return null;
    }

    public Vector3 CollidingPosition()
    {
        return collision.Value.point;
    }

    private float HeightAt(float x)
    {
        float initialSpeed = Mathf.Sqrt(MaxDistance * -Physics.gravity.y);

        float a = Mathf.Acos(Vector3.Dot(Vector3.Normalize(new Vector3(transform.forward.x, 0, transform.forward.z)), transform.forward));
        if (transform.forward.y != 0) a *= (transform.forward.y / Mathf.Abs(transform.forward.y));

        float height = -0.5f * ((-Physics.gravity.y * Mathf.Pow(x, 2)) / (Mathf.Pow(Mathf.Cos(a) * initialSpeed, 2)))
            + (Mathf.Tan(a) * x) + transform.position.y;

        if (float.IsNaN(height))
            return -1000f;
        else
            return height;
    }
}
