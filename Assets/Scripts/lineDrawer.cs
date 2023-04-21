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
    // Update is called once per frame
    void Update()
    {
        points = PlanetManager.traveledPlanets;
        if (points.Count< 2)
            return;
        else
        {
            lineRenderer.positionCount = points.Count;
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i] != null)
                    lineRenderer.SetPosition(i, points[i]);
            }
        }


    }
}
