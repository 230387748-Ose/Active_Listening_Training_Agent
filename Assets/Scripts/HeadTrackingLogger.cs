using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For detecting scene changes
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;

public class HeadTrackingLogger : MonoBehaviour
{
 // Reference to the main camera (user's head position)
    private Transform cameraTransform;

    // Update interval for logging
    private float logInterval = 5.0f;
    private float timeSinceLastLog = 0.0f;

    // Thresholds for determining look directions
    private const float lookUpThreshold = 30.0f;
    private const float lookDownThreshold = -30.0f;
    private const float lookLeftThreshold = 30.0f;
    private const float lookRightThreshold = -30.0f;

    private bool isLogging = true;

    void Start()
    {
        // Get the main camera transform
        cameraTransform = CameraCache.Main.transform;

        // Subscribe to the scene change event
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    void Update()
    {
        if (!isLogging) return;

        // Calculate the direction vector from the character to the user's head
        Vector3 directionToUser = cameraTransform.position - transform.position;

        // Calculate the user's head orientation relative to the character
        // Quaternion in graphics programming is a compact representation of the rotation of an object in three dimensions
        Quaternion userHeadRotation = Quaternion.LookRotation(directionToUser);

        // Log the orientation every logInterval seconds
        timeSinceLastLog += Time.deltaTime;
        if (timeSinceLastLog >= logInterval)
        {
            LogHeadOrientation(userHeadRotation);
            timeSinceLastLog = 0.0f;
        }
    }

    private void LogHeadOrientation(Quaternion userHeadRotation)
    {
        // Convert the quaternion to euler angles
        //Euler angles are successive planar rotation angles around x, y, and z axes, and their values depend on the choice and order of the rotation axes
        Vector3 eulerAngles = userHeadRotation.eulerAngles;

        // Determine the head direction
        string direction = GetLookDirection(eulerAngles);

        // Log the user's head orientation and direction
        Debug.Log($"User Head Orientation - Yaw: {eulerAngles.y:F2}, Pitch: {eulerAngles.x:F2}, Roll: {eulerAngles.z:F2} - Direction: {direction}");
    }

    private string GetLookDirection(Vector3 eulerAngles)
    {
        // Adjusting angles to handle Unity's 0 to 360 conversion
        float yaw = NormalizeAngle(eulerAngles.y);
        float pitch = NormalizeAngle(eulerAngles.x);

        if (pitch > lookUpThreshold)
            return "Up";
        else if (pitch < lookDownThreshold)
            return "Down";
        else if (yaw > lookLeftThreshold)
            return "Left";
        else if (yaw < lookRightThreshold)
            return "Right";
        else
            return "Forward";
    }

    private float NormalizeAngle(float angle)
    {
        if (angle > 180.0f)
            angle -= 360.0f;
        return angle;
    }

    private void OnSceneChanged(Scene current, Scene next)
    {
        // Stop logging when the scene changes
        isLogging = false;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the scene change event
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }
}