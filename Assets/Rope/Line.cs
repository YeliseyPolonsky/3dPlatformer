using System;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int PointsCount;
    
    public void Draw(Vector3 a, Vector3 b,float length)
    {
        lineRenderer.enabled = true;
        
        lineRenderer.positionCount = PointsCount;
        lineRenderer.SetPosition(0, a);
        lineRenderer.SetPosition(1, b);

        float offset = Mathf.Lerp(length / 2f, 0, Vector3.Distance(a, b)/ length);
        
        Vector3 aDown = a + Vector3.down * offset;
        Vector3 bDown = b + Vector3.down * offset;
        
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 newPoint = Bezier.GetPoint(b, bDown, aDown, a, i / (float)(PointsCount-1));
            lineRenderer.SetPosition(i, newPoint);
        }
    }

    public void Hide()
    {
        lineRenderer.enabled = false;
    }
}