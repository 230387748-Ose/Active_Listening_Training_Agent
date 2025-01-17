using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
 public Text TimerText;  // UI Text component to display the timer
    private float timeRemaining = 300f;  // Starting time in seconds

    void Start()
    {
        // Start the countdown coroutine
        StartCoroutine(StartCountdown());
    }

    // Coroutine for counting down the time
    private IEnumerator StartCountdown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);  // Wait for 1 second
            timeRemaining -= 1f;  // Decrement the timer by 1 second
            UpdateTimerText();  // Update the UI text
        }

        // When the countdown is finished, load the next scene
        LoadNextScene();
    }

    // Update the TimerText UI element
    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);  // Calculate minutes
        int seconds = Mathf.FloorToInt(timeRemaining % 60);  // Calculate seconds

        // Format the timer text as "MM:SS"
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Load the next scene when the timer ends
    private void LoadNextScene()
    {
        // Assuming the next scene is indexed after the current one
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Load the next scene
        SceneManager.LoadScene(nextSceneIndex);
    }
}
