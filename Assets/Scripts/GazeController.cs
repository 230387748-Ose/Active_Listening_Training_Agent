using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeController : MonoBehaviour
{
    public Transform cameraTransform;  // Reference to the HoloLens 2 camera
    private Animator animator;         // Reference to the Animator component
    private Vector3 gazeTargetPosition; // Position to look at

    private EyeTracking eyeTracking;   // Reference to the EyeTracking script

    public float lookAtUserWeight = 1.0f;
    public float lookAtGazeWeight = 0.5f;

    void Start()
    {
        // Get the Animator component attached to the character
        animator = GetComponent<Animator>();

        // Find and assign the camera transform (HoloLens 2 user's head position)
        cameraTransform = Camera.main.transform;

        // Set the initial gaze target position to the camera's position
        gazeTargetPosition = cameraTransform.position;

        // Get the EyeTracking script reference
        eyeTracking = FindObjectOfType<EyeTracking>();
    }

    void Update()
    {
        // Update the gaze target position to the current camera position
        gazeTargetPosition = cameraTransform.position;
    }

    void OnAnimatorIK(int layerIndex)
    {
        // Determine if the character should look at the user or follow the gaze
        if (eyeTracking != null && eyeTracking.GazeStatus == "Looking at character's head")
        {
            // If the user is looking at the character's head, apply high weight to look back at the user
            animator.SetLookAtWeight(lookAtUserWeight, 0.5f, 0.7f, 1.0f, 0f);
            animator.SetLookAtPosition(gazeTargetPosition);
        }
        else if (eyeTracking != null && (eyeTracking.GazeStatus == "Looking at character's body" || eyeTracking.GazeStatus == "Not looking at character"))
        {
            // If the user is looking at the body or elsewhere, the character can follow the user's gaze with lower weight
            animator.SetLookAtWeight(lookAtGazeWeight, 0.5f, 0.7f, 1.0f, 0f);
            animator.SetLookAtPosition(gazeTargetPosition);
        }
        else
        {
            // Default behavior when nothing else is happening (like idle)
            animator.SetLookAtWeight(0f);
        }
    }
}
