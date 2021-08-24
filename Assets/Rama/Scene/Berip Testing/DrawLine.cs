using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currentLine;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> fingerPosition;

    private void Update()
    {
        Physics2D.SyncTransforms();
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(tempFingerPos, fingerPosition[fingerPosition.Count - 1]) > .1f)
            {
                Updateline(tempFingerPos);
            }
        }
    }

    private void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        fingerPosition.Clear();
        fingerPosition.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPosition.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, fingerPosition[0]);
        lineRenderer.SetPosition(1, fingerPosition[1]);
        edgeCollider.points = fingerPosition.ToArray();
    }

    private void Updateline(Vector2 newFingerPosition)
    {
        fingerPosition.Add(newFingerPosition);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1, newFingerPosition);
        edgeCollider.points = fingerPosition.ToArray();
    }
}
