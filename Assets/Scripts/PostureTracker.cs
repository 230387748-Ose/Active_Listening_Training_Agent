using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;

public class PostureTracker : MonoBehaviour
{
 public float checkInterval = 5f; // Time between checks in seconds
    private float nextCheckTime = 0f;

    private IMixedRealityEyeGazeProvider eyeGazeProvider;
    private Transform userHeadTransform;

    // Additional parameters for depth-based posture tracking
    public float standingDistanceThreshold = 0.5f; // Threshold for distance indicating standing
    public float sittingDistanceThreshold = 1.2f; // Threshold for distance indicating sitting
    public float leaningAngleThreshold = 30f; // Angle threshold for leaning

    void Start()
    {
        eyeGazeProvider = CoreServices.InputSystem?.EyeGazeProvider;
        if (eyeGazeProvider == null)
        {
            Debug.LogError("EyeGazeProvider not found.");
            return;
        }

        // Track the user's head transform
        userHeadTransform = Camera.main.transform;
    }

    void Update()
    {
        if (Time.time >= nextCheckTime)
        {
            nextCheckTime = Time.time + checkInterval;
            TrackPosture();
        }
    }

    private void TrackPosture()
    {
        if (eyeGazeProvider == null || !eyeGazeProvider.IsEyeTrackingEnabledAndValid)
        {
            Debug.LogWarning("Eye tracking is not enabled or not valid.");
            return;
        }

        Vector3 gazeDirection = eyeGazeProvider.GazeDirection;
        Vector3 headForward = userHeadTransform.forward;
        Vector3 headPosition = userHeadTransform.position;

        // Calculate the distance from the camera (or a reference point) to the user's head
        float distanceToHead = Vector3.Distance(Camera.main.transform.position, headPosition);
        
        // Calculate the angle between gaze direction and head forward direction
        float angle = Vector3.Angle(gazeDirection, headForward);

        // Determine posture based on both angle and depth
        if (distanceToHead < standingDistanceThreshold)
        {
            Debug.Log("Standing");
        }
        else if (distanceToHead < sittingDistanceThreshold)
        {
            if (angle < leaningAngleThreshold)
            {
                Debug.Log("Sitting");
            }
            else
            {
                Debug.Log("Leaning");
            }
        }
        else
        {
            Debug.Log("Slouching");
        }
    }
}
