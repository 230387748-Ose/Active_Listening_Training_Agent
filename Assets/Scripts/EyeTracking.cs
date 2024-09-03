using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;

public class EyeTracking : MonoBehaviour
{
    public GameObject headObject;  // GameObject with CapsuleCollider for the head
    public GameObject bodyObject;  // GameObject with MeshCollider for the body
    public float recordInterval = 0.02f; // Time interval in seconds for recording data (20 milliseconds)

    private IMixedRealityEyeGazeProvider eyeGazeProvider;
    private string gazeStatus = "Not looking at character"; // Default gaze status
    private Coroutine recordCoroutine;

    // Public property to access the gazeStatus variable
    public string GazeStatus 
    {
        get { return gazeStatus; }
    }

    void Start()
    {
        // Get the EyeGazeProvider from the MRTK input system
        eyeGazeProvider = CoreServices.InputSystem?.EyeGazeProvider;

        if (eyeGazeProvider == null)
        {
            Debug.LogError("Eye Gaze Provider not found!");
            return;
        }

        // Start the recording coroutine
        recordCoroutine = StartCoroutine(RecordGazeData());
    }

    void Update()
    {
        if (eyeGazeProvider.IsEyeTrackingEnabledAndValid)
        {
            Vector3 gazeOrigin = eyeGazeProvider.GazeOrigin;
            Vector3 gazeDirection = eyeGazeProvider.GazeDirection;

            // Raycast from the user's eye gaze direction
            RaycastHit hitInfo;
            if (Physics.Raycast(gazeOrigin, gazeDirection, out hitInfo))
            {
                // Check if the raycast hits the character's head (CapsuleCollider)
                if (hitInfo.collider.gameObject == headObject)
                {
                    gazeStatus = "Looking at character's head";
                }
                // Check if the raycast hits the character's body (MeshCollider)
                else if (hitInfo.collider.gameObject == bodyObject)
                {
                    gazeStatus = "Looking at character's body";
                }
                else
                {
                    gazeStatus = "Not looking at character";
                }
            }
            else
            {
                gazeStatus = "Not looking at character";
            }
        }
        else
        {
            gazeStatus = "Not looking at character";
        }
    }

    IEnumerator RecordGazeData()
    {
        while (true)
        {
            // Log gaze data
            LogGazeData();

            // Wait for the specified interval
            yield return new WaitForSeconds(recordInterval);
        }
    }

    void LogGazeData()
    {
        string[] header = { "Time", "Gaze Status" };
        string[] data = { Time.time.ToString("F4"), gazeStatus };
        
        // Log to LogManager
        LogManager.instance.WriteCSV(header, new List<string[]> { data });

        // Log to console
        Debug.Log($"Time: {Time.time:F4}, Gaze Status: {gazeStatus}");
    }

    void OnDisable()
    {
        if (recordCoroutine != null)
        {
            StopCoroutine(recordCoroutine);
        }
    }
}
