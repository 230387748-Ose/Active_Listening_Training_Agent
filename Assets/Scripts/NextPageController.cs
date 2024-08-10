using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextPageController : MonoBehaviour
{
    public void ButtonHandlerPlay()
    {
        // Get the index of the current active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene based on the build settings hierarchy
        SceneManager.LoadSceneAsync(currentSceneIndex + 1);

        // Your logic for the button play handler
        Debug.Log("Play button clicked! Loading next scene...");
    }
}
