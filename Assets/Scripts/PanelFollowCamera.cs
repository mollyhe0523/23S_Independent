using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PanelFollowCamera : MonoBehaviour
{
    public Transform[] panels; // Array of panel GameObjects
    public Transform target; // Reference to the VR camera
    public float smoothTime = 0.3f; // Smoothing factor
    private Vector3 velocity = Vector3.zero; // Velocity for SmoothDamp
    private void LateUpdate()
    {
        // Calculate the target position for the panels
        Vector3 targetPosition = target.position;
        // Move each panel towards the target position using SmoothDamp
        foreach (Transform panel in panels)
        {
            panel.position = Vector3.SmoothDamp(panel.position, targetPosition, ref velocity, smoothTime);
        }
    }
}