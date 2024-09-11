using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _GameTimerALT : MonoBehaviour
{
    public Text TimerText;
    private float timeRemaining = 300f;
    private SceneRandomizer sceneRandomizer;

    void Start()
    {
        // Get reference to the SceneRandomizer
        sceneRandomizer = FindObjectOfType<SceneRandomizer>();

        // Start the countdown coroutine
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            timeRemaining -= 1f;
            UpdateTimerText();
        }

        // Load the next scene when the countdown is finished
        LoadNextScene();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = sceneRandomizer.GetNextScene(currentSceneIndex);

        // Load the next scene (which could be the menu if it's the last session)
        SceneManager.LoadScene(nextSceneIndex);
    }
}
