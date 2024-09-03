using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;

public class HeadMovementLogger : MonoBehaviour
{
    private Transform headTransform;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private float logInterval = 0.02f; // Set to 20 milliseconds (0.02 seconds)
    // private float logInterval = 5.0ff; // Set to 20 milliseconds (0.02 seconds)
    private float timeSinceLastLog = 0f;
    private bool isLoggingActive = true;

    private void Start()
    {
        // Get the head transform using the main camera
        if (Camera.main != null)
        {
            headTransform = Camera.main.transform;
            initialPosition = headTransform.position;
            initialRotation = headTransform.rotation;
        }
        else
        {
            Debug.LogError("Main camera not found.");
        }
    }

    private void Update()
    {
        if (isLoggingActive && headTransform != null)
        {
            // Log head movement every 20 milliseconds
            timeSinceLastLog += Time.deltaTime;
            if (timeSinceLastLog >= logInterval)
            {
                LogHeadMovement();
                timeSinceLastLog = 0f;
            }
        }
    }

    private void LogHeadMovement()
    {
        Vector3 currentPosition = headTransform.position;
        Quaternion currentRotation = headTransform.rotation;

        // Calculate movement from the initial position
        Vector3 positionDifference = currentPosition - initialPosition;
        Quaternion rotationDifference = currentRotation * Quaternion.Inverse(initialRotation);

        // Log head data via LogManager
        string[] header = { "Time", "Head Position", "Head Rotation", "Position Change", "Rotation Change" };
        string[] data = {
            Time.time.ToString(),
            currentPosition.ToString(),
            currentRotation.eulerAngles.ToString(),
            positionDifference.ToString(),
            rotationDifference.eulerAngles.ToString()
        };
        
         // Log to LogManager
        LogManager.instance.WriteCSV(header, new List<string[]> { data });

        // Log to console
        Debug.Log($"Time: {Time.time}, Head Position: {currentPosition}, Head Rotation: {currentRotation.eulerAngles}");
        Debug.Log($"Position Change: {positionDifference}, Rotation Change: {rotationDifference.eulerAngles}");
    }

    public void StopLogging()
    {
        isLoggingActive = false;
    }
}
