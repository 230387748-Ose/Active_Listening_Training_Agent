using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrazyMinnow.SALSA; // Ensure this is the correct namespace for SALSA

public class AudioDelay : MonoBehaviour
{
    public AudioSource audioSource;  // Assign the AudioSource in the Inspector
    public float delay = 4.0f;  // Time in seconds to delay the audio

    void Start()
    {
        // Play the audio with a delay
        audioSource.PlayDelayed(delay);
    }
}
