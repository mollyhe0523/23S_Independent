using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRendererController : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        if (lineRenderer == null)
        {
            Debug.LogError("No LineRenderer component found on this GameObject.");
            return;
        }
    }

    void Update()
    {
        UpdateLineRendererPositions();

    }

    void UpdateLineRendererPositions()
    {
        Vector3 text1Center = GetRectTransformCenter(text1.GetComponent<RectTransform>());
        Vector3 text2Center = GetRectTransformCenter(text2.GetComponent<RectTransform>());

        lineRenderer.SetPosition(0, text1Center);
        lineRenderer.SetPosition(1, text2Center);
    }

    Vector3 GetRectTransformCenter(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        Vector3 center = (corners[0] + corners[2]) / 2;
        return center;
    }
}