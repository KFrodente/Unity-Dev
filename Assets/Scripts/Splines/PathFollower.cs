using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;
using UnityEngine.UIElements;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private SplineContainer splineContainter;
    [Range(0, 40)] public float speed = 1;


    [Range(0, 1)] public float tdistance = 0; //distance along spline

    //length in world coordinates
    public float length { get { return splineContainter.CalculateLength(); } }
    //distance in world coordinates
    public float distance 
    {
        get { return tdistance * length;}
        set { tdistance = value / length; }
    }

    private void Update()
    {
        distance += speed * Time.deltaTime;
        UpdateTransform(math.frac(tdistance));
    }

    void UpdateTransform(float t)
    {
        Vector3 position = splineContainter.EvaluatePosition(t);
        Vector3 up = splineContainter.EvaluateUpVector(t);
        Vector3 forward = Vector3.Normalize(splineContainter.EvaluateTangent(t));
        Vector3 right = Vector3.Cross(up, forward);

        transform.position = position;
        transform.rotation = Quaternion.LookRotation(forward, up);
    }
}
