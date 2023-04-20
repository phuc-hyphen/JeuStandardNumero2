using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class lineDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private List<Vector3> points;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;

    }
    // public void SetUpLine(List<Vector3> points)
    // {
    //     this.points = points;
    //     lineRenderer.positionCount = points.Count;
    // }
    // Update is called once per frame
    void Update()
    {
        this.points = TimeManager.planetsPos;
        if (points.Count < 2)
        {
            return;
        }
        if (lineRenderer.positionCount != points.Count)
        {
            lineRenderer.positionCount = points.Count;
        }
        else
        {
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i] != null)
                    lineRenderer.SetPosition(i, points[i]);
            }
        }


    }
}
