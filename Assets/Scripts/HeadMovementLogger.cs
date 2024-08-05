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
    private float logInterval = 5.0f; // Time in seconds to log head movement
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
            // Log head movement every 5 seconds
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

        // Log the data (you can also write this to a file or use other logging methods)
        Debug.Log($"Head Position: {currentPosition} | Head Rotation: {currentRotation.eulerAngles}");
        Debug.Log($"Position Change: {positionDifference} | Rotation Change: {rotationDifference.eulerAngles}");
    }

    public void StopLogging()
    {
        isLoggingActive = false;
    }
}
