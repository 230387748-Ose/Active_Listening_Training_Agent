using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // New public method
    public void ButtonHandlerPlay()
    {
        SceneManager.LoadSceneAsync(1);
        // Your logic for the button play handler
        Debug.Log("Play button clicked!");
    }
}
