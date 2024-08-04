using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene management
using Microsoft.MixedReality.Toolkit.Input;

public class HeadOrientationTracker : MonoBehaviour
{
    // Reference to the main camera
    private Camera mainCamera;
    private Coroutine loggingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        // Get the main camera, which acts as the user's head in HoloLens
        mainCamera = Camera.main;
        // Start logging head orientation every 5 seconds
        loggingCoroutine = StartCoroutine(LogHeadOrientation());
        // Subscribe to the sceneLoaded event to handle scene changes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

     private void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event when the object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Stop the coroutine when the scene changes
        if (loggingCoroutine != null)
        {
            StopCoroutine(loggingCoroutine);
            loggingCoroutine = null;
        }
    }

    private IEnumerator LogHeadOrientation()
    {
        while (true)
        {
            // Get the head's orientation as a Quaternion
             // Quaternion in graphics programming is a compact representation of the rotation of an object in three dimensions
            Quaternion headOrientation = mainCamera.transform.rotation;

            // Convert the Quaternion to Euler angles for easier readability
            //Euler angles are successive planar rotation angles around x, y, and z axes, and their values depend on the choice and order of the rotation axes
            Vector3 headEulerAngles = headOrientation.eulerAngles;

            // Log the head orientation to the console
            Debug.Log($"Head Orientation - Quaternion: {headOrientation}, Euler Angles: {headEulerAngles}");

            // Wait for 5 seconds before logging again
            yield return new WaitForSeconds(5f);
        }
    }
}
