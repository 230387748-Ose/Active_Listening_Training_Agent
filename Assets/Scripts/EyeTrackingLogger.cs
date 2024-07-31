using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;


public class EyeTrackingLogger : MonoBehaviour
{
        public GameObject characterUpperBody; // The GameObject representing the character's upper body
    public float recordInterval = 5.0f; // Time interval in seconds for recording data

    private IMixedRealityEyeGazeProvider eyeGazeProvider;
    private bool isGazingAtCharacter;
    private Coroutine recordCoroutine;

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
                // Check if the raycast hits the character's upper body
                if (hitInfo.collider.gameObject == characterUpperBody)
                {
                    isGazingAtCharacter = true;
                }
                else
                {
                    isGazingAtCharacter = false;
                }
            }
            else
            {
                isGazingAtCharacter = false;
            }
        }
        else
        {
            isGazingAtCharacter = false;
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
        string gazeStatus = isGazingAtCharacter ? "Gazing at character's face" : "Not gazing at character";
        Debug.Log($"Time: {Time.time}, Gaze Status: {gazeStatus}");
    }

    void OnDisable()
    {
        if (recordCoroutine != null)
        {
            StopCoroutine(recordCoroutine);
        }
    }

}
