using UnityEngine;
using UnityEngine.UI;

public class pinchProgress : MonoBehaviour
{
    [SerializeField] private Image myImage;
    
    public int totalFrames = 120; // Total frames for the loading bar animation
    public float radius = 1f; // Radius of the loading bar circle
    public LineRenderer lineRenderer; // Reference to the Line Renderer component

    public Vector3 panelPos = new Vector3(0.5f, 0.7f, 0.4f);
    private void Start()
    {
        lineRenderer.positionCount = 2; // Set the number of positions for the Line Renderer to 2
    }

    private void Update()
    {
        float progress = (float)Time.frameCount / totalFrames; // Calculate the progress based on the current frame count

        // Calculate the angle for the loading bar position
        float angle = Mathf.Lerp(0f, 360f, progress);

        // Calculate the position on the circle using the angle and radius
        Vector3 position = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad), 0f) * radius;

        // Set the position of the Line Renderer
        // lineRenderer.SetPosition(0, panelPos);
        // lineRenderer.SetPosition(1, position + panelPos);
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, position);
    }
}