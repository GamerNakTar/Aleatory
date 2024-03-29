using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBase : MonoBehaviour
{
    // Public variables for customization
    public Transform targetPosition; // Reference to the target position the camera should follow
    public float speed = 5.0f;       // Speed of camera movement (adjust for desired smoothness)

    private void Start()
    {
        // Optional: Set a default target position if not assigned in the inspector
        if (targetPosition == null)
        {
            Debug.LogWarning("CameraBase: No target position assigned. Please set one in the inspector.");
            // Consider setting a default position here if necessary
        }
    }

    private void Update()
    {
        // Smoothly move the camera towards the target position
        Vector3 vec3 = Vector3.Lerp(transform.position, targetPosition.position, speed * Time.deltaTime);
        vec3 = new Vector3(vec3.x, vec3.y, vec3.z-10);
        transform.position = vec3;
    }
}
