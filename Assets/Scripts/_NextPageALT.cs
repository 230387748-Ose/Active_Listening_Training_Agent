using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _NextPageALT : MonoBehaviour
{
   private SceneRandomizer sceneRandomizer;

    void Start()
    {
        // Get reference to the SceneRandomizer attached to the SceneManager GameObject
        sceneRandomizer = FindObjectOfType<SceneRandomizer>();
    }

    public void ButtonHandlerPlay()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Use SceneRandomizer to get the next scene
        int nextSceneIndex = sceneRandomizer.GetNextScene(currentSceneIndex);

        // Load the next scene (which could be the menu after the last session)
        SceneManager.LoadSceneAsync(nextSceneIndex);

        Debug.Log("Play button clicked! Loading next scene...");
    }
}
