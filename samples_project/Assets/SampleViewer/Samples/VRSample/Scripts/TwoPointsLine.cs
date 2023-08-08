using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TwoPointsLine : MonoBehaviour
{
    [SerializeField] private Transform firstPoint;
    [SerializeField] private Transform lastPoint;
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }


    void Update()
    {
        line.positionCount = 2;
        line.SetPosition(0, firstPoint.position);
        line.SetPosition(1, lastPoint.position);
    }
}
