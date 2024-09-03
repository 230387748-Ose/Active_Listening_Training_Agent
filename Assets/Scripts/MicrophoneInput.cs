using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour
{
    public float detectionThreshold = 0.1f;  // Adjust this threshold based on your needs
    public float updateInterval = 0.1f;      // How often to check for spikes

    private AudioSource audioSource;
    private float[] audioSamples;
    private float lastDetectionTime;
    private string _microphoneName;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing from this GameObject.");
            return;
        }

        audioSource.loop = true; // Keep audio source active
        audioSource.mute = true; // Mute the audio source to avoid affecting character's audio

        // Get the default microphone name
        _microphoneName = Microphone.devices[0];
        audioSamples = new float[256];
        
        // Start recording audio data
        StartMicrophone();
    }

    // Starts the microphone recording
    void StartMicrophone()
    {
        if (Microphone.IsRecording(_microphoneName))
        {
            Microphone.End(_microphoneName);
        }

        audioSource.clip = Microphone.Start(_microphoneName, true, 1, 44100);
        audioSource.loop = true;
        lastDetectionTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Microphone.IsRecording(_microphoneName) && Time.time - lastDetectionTime >= updateInterval)
        {
            DetectVolumeSpike();
            lastDetectionTime = Time.time;
        }
    }

    void DetectVolumeSpike()
    {
        int micPosition = Microphone.GetPosition(_microphoneName) - audioSamples.Length + 1;
        if (micPosition < 0) return;

        audioSource.clip.GetData(audioSamples, micPosition);

        foreach (float sample in audioSamples)
        {
            if (Mathf.Abs(sample) > detectionThreshold)
            {
                LogInterruption();  // <--- Changed: Calls LogInterruption method
                break;
            }
        }
    }

    // Logs an interruption event with the specified time and volume
    void LogInterruption()
    {
        Debug.Log($"Volume spike detected at: {System.DateTime.Now}");

        // Ensure LogManager is present and enabled
        if (LogManager.instance != null && LogManager.instance.isActiveAndEnabled)  // <--- Changed: Check if LogManager exists and is enabled
        {
            string[] headers = { "Timestamp", "Event", "Details" };  // <--- Changed: Prepare headers
            string[] data = { System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), "VolumeSpike", "Volume spike detected" };  // <--- Changed: Prepare data

            LogManager.instance.WriteCSV(headers, new List<string[]> { data });  // <--- Changed: Log data using LogManager
        }
    }

    // Called when the application is quitting or the object is destroyed
    void OnDisable()
    {
        StopMicrophone();
    }

    // Custom method to stop the microphone
    void StopMicrophone()
    {
        if (Microphone.IsRecording(_microphoneName))
        {
            Debug.Log("Stopping microphone recording.");
            Microphone.End(_microphoneName);
        }
    }
}
