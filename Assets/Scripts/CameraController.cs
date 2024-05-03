using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Public variables for customization
    public Transform targetPosition; // Reference to the target position the camera should follow
    public float speed = 5.0f;       // Speed of camera movement (adjust for desired smoothness)
    [SerializeField] private GameObject player;
    private NewBehaviourScript controllerScript;
    private Vector3 rotateAngle;
    private float rotateDirection = 1;

    private void Start()
    {
        // Optional: Set a default target position if not assigned in the inspector
        if (targetPosition == null)
        {
            Debug.LogWarning("CameraBase: No target position assigned. Please set one in the inspector.");
            // Consider setting a default position here if necessary
        }
        controllerScript = player.GetComponent<NewBehaviourScript>();
    }

    private void Update()
    {
        // Smoothly move the camera towards the target position
        Vector3 vec3 = Vector3.Lerp(transform.position, targetPosition.position, speed * Time.deltaTime);
        vec3 = new Vector3(vec3.x, vec3.y, vec3.z-10);
        transform.position = vec3;

        //If player is in Fever(hangover) time, camera will stumble
        rotateAngle = transform.eulerAngles;
        if(controllerScript.isDrunk)
        {
            Debug.Log(rotateAngle);
            if(rotateAngle.z < 30)
            {
                transform.Rotate(new Vector3(0, 0, rotateDirection), (30.0f - (rotateAngle.z * 1.3f)) * Time.deltaTime);
            }
            else if(rotateAngle.z > 330)
            {
                transform.Rotate(new Vector3(0, 0, rotateDirection), (30.0f - ((360 - rotateAngle.z) * 1.3f)) * Time.deltaTime);
            }
            if(rotateAngle.z > 20 && rotateAngle.z < 180)
            {
                rotateDirection = -1;
            }
            else if(rotateAngle.z < 340 && rotateAngle.z > 180)
            {
                rotateDirection = 1;
            }
        }
        else
        {
            if(rotateAngle.z < 1 || rotateAngle.z > 359)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if(rotateAngle.z < 30)
            {
                transform.Rotate(new Vector3(0, 0, -1), (20.0f - 20/rotateAngle.z) * Time.deltaTime);
            }
            else if(rotateAngle.z > 330)
            {
                transform.Rotate(new Vector3(0, 0, 1), (20.0f - 20/(360 - rotateAngle.z)) * Time.deltaTime);
            }
        }
    }
}
