using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public class LogManager : MonoBehaviour
{
public static LogManager instance = null; // Static instance of LogManager which allows it to be accessed by any other script.
    private string filePath;
    [SerializeField] private bool m_ShowDebugLogManager;
    private bool isLoggingEnabled = false;  // Flag to control logging

    // Awake is always called before any Start functions
    void Awake()
    {
        if (m_ShowDebugLogManager)
        {
            print("LogManager::Awake");
        }
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return; // Exit to prevent further initialization
        }

        DontDestroyOnLoad(gameObject);

        string strDir = Application.persistentDataPath;
        filePath = Path.Combine(strDir, System.DateTime.Now.ToString("yyyyMMdd-HHmmss") + "_data.txt");

        // Enable or disable logging based on the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        if (ShouldLogForScene(currentScene.name))
        {
            StartLogging();
        }
        else
        {
            StopLogging();
        }
    }

    // Subscribe to sceneLoaded event
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Unsubscribe from sceneLoaded event
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Handle scene loading
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (ShouldLogForScene(scene.name))
        {
            StartLogging();
        }
        else
        {
            StopLogging();
        }
    }

    // Determine if logging should occur for the given scene
    private bool ShouldLogForScene(string sceneName)
    {
        // Add your scene names here
        return sceneName == "Session" || sceneName == "Session2";
    }

    // Start logging
    public void StartLogging()
    {
        isLoggingEnabled = true;
        if (m_ShowDebugLogManager)
        {
            Debug.Log("LogManager::StartLogging - Logging enabled.");
        }
    }

    // Stop logging
    public void StopLogging()
    {
        isLoggingEnabled = false;
        if (m_ShowDebugLogManager)
        {
            Debug.Log("LogManager::StopLogging - Logging disabled.");
        }
    }

    // Write a timestamped log entry
    public void WriteTimeStampedEntry(string strMessage)
    {
        if (!isLoggingEnabled) return;

        if (m_ShowDebugLogManager)
        {
            print("LogManager::WriteTimeStampedEntry");
        }
        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            sw.WriteLine(Time.realtimeSinceStartup + ";" + strMessage);
        }
    }

    // Write a simple log entry
    public void WriteEntry(string strMessage)
    {
        if (!isLoggingEnabled) return;

        if (m_ShowDebugLogManager)
        {
            print("LogManager::WriteEntry");
        }
        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            sw.WriteLine(strMessage);
        }
    }

    // Write multiple entries from a list
    public void WriteEntry(List<string> data)
    {
        if (!isLoggingEnabled) return;

        if (m_ShowDebugLogManager)
        {
            print("LogManager::WriteEntry");
        }
        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            data.ForEach(delegate (string s)
            {
                sw.WriteLine(s);
            });
        }
    }

    // Write CSV formatted data
    public void WriteCSV(string[] header, IList<string[]> data)
    {
        if (!isLoggingEnabled) return;

        if (m_ShowDebugLogManager)
        {
            print("LogManager::WriteCSV");
        }

        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            sw.WriteLine(string.Join(",", header));
            for (int i = 0; i < data.Count; i++)
            {
                sw.WriteLine(string.Join(",", data[i]));
            }
        }
    }
}
