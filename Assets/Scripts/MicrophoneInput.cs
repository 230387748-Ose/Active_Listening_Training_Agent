using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MicrophoneInput : MonoBehaviour
{
 // The AudioClip used to store microphone input
    private AudioClip _microphoneClip;
    
    // Constants for audio recording
    private const int SampleRate = 44100; // Sample rate in Hz
    private const int ClipDuration = 1;   // Duration of the audio clip in seconds
    private const float VolumeThreshold = 0.1f; // Threshold for detecting a spike
    
    // The name of the microphone device
    private string _microphoneName;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure at least one microphone is available
        if (Microphone.devices.Length > 0)
        {
            // Get the default microphone's name
            _microphoneName = Microphone.devices[0];
            Debug.Log("Using Microphone: " + _microphoneName);
            
            // Start recording from the microphone
            StartMicrophone();
        }
        else
        {
            Debug.LogError("No microphone devices found.");
        }
    }

    // Starts the microphone recording
    void StartMicrophone()
    {
        // Start the microphone with the given parameters
        _microphoneClip = Microphone.Start(
            _microphoneName,    // Device name
            true,               // Loop the recording
            ClipDuration,       // Clip duration
            SampleRate          // Sample rate
        );
        
        // Wait until the microphone has started
        while (!(Microphone.GetPosition(_microphoneName) > 0)) { }
        Debug.Log("Microphone recording started.");
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current average volume level
        float currentVolume = GetAverageVolume();
        
        // Check if the volume exceeds the threshold
        if (currentVolume > VolumeThreshold)
        {
            Debug.Log("Volume spike detected: " + currentVolume);
            
            // Log the interruption with the current time
            LogInterruption(Time.time, currentVolume);
        }
    }

    // Calculate the average volume from the microphone data
    float GetAverageVolume()
    {
        // Array to hold audio sample data
        float[] data = new float[SampleRate * ClipDuration];
        
        // Get the current position in the audio clip
        int microphonePosition = Microphone.GetPosition(_microphoneName);
        
        // Ensure we have valid data
        if (microphonePosition > 0 && _microphoneClip != null)
        {
            // Copy the audio data into the array
            _microphoneClip.GetData(data, 0);
            
            // Calculate the RMS (root mean square) value of the audio data
            float sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sum += data[i] * data[i]; // Sum the squares of the audio samples
            }
            
            // Return the RMS value, which represents the average volume
            return Mathf.Sqrt(sum / data.Length);
        }

        return 0f; // Return 0 if no valid data
    }

    // Logs an interruption event with the specified time and volume
    void LogInterruption(float time, float volume)
    {
        // Log to the console
        Debug.Log($"Interruption at {time} seconds with volume {volume}");
        
        // Optional: Log to a file
        // string path = Path.Combine(Application.persistentDataPath, "interruption_log.txt");
        // string logEntry = $"Interruption at {time} seconds with volume {volume}\n";
        // File.AppendAllText(path, logEntry);
    }

    // Called when the application is quitting or the object is destroyed
    void OnDisable()
    {
        StopMicrophone();
    }

    // Custom method to stop the microphone
    void StopMicrophone()
    {
        // Check if the microphone is running
        if (Microphone.IsRecording(_microphoneName))
        {
            Debug.Log("Stopping microphone recording.");
            Microphone.End(_microphoneName);
        }
    }
}
