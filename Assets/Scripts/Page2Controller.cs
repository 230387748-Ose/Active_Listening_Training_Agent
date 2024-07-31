using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Page2Controller : MonoBehaviour
{
   
   public void ButtonHandlerPlay()
    {
        SceneManager.LoadSceneAsync(4);
        // Your logic for the button play handler
        Debug.Log("Play button clicked!");
    }
}
