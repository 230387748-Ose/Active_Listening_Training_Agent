using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeController : MonoBehaviour
{
    public Transform cameraTransform;  // Reference to the HoloLens 2 camera
    private Animator animator;         // Reference to the Animator component
    private Vector3 gazeTargetPosition; // Position to look at

    void Start() {
        // Get the Animator component attached to the character
        animator = GetComponent<Animator>();

        // Find and assign the camera transform (HoloLens 2 user's head position)
        cameraTransform = Camera.main.transform;

        // Set the initial gaze target position to the camera's position
        gazeTargetPosition = cameraTransform.position;
    }

    void Update() {
        // Update the gaze target position to the current camera position
        gazeTargetPosition = cameraTransform.position;
    }

     void OnAnimatorIK(int layerIndex) {
        // Set the LookAt weights for the body, head, and eyes
        animator.SetLookAtWeight(1.0f, 0.5f, 0.7f, 1.0f, 0f);

        // Set the LookAt position to smoothly follow the camera
        animator.SetLookAtPosition(gazeTargetPosition);
    }
}
