using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRandomizer : MonoBehaviour
{
    private static bool isShuffled = false;
    private static int[] sceneOrder;

    void Awake()
    {
        // Ensure we only shuffle once per play session
        if (!isShuffled)
        {
            ShuffleScenes();
            isShuffled = true;
        }
    }

    // Shuffle the order of (topic1 -> session) and (topic2 -> session2)
    void ShuffleScenes()
    {
        sceneOrder = new int[4];

        // Assuming topic1 is scene index 2, session is 3, topic2 is 5, and session2 is 6 in the build settings
        int topic1Index = 2;
        int session1Index = 3;
        int topic2Index = 5;
        int session2Index = 6;

        // Create a list to hold pairs of topic and session scenes
        List<int[]> topicSessionPairs = new List<int[]>
        {
            new int[] { topic1Index, session1Index },  // topic1 and session
            new int[] { topic2Index, session2Index }   // topic2 and session2
        };

        // Shuffle the list
        for (int i = topicSessionPairs.Count - 1; i > 0; i--)
        {
            int rand = Random.Range(0, i + 1);
            int[] temp = topicSessionPairs[i];
            topicSessionPairs[i] = topicSessionPairs[rand];
            topicSessionPairs[rand] = temp;
        }

        // Assign the shuffled order to the sceneOrder array
        sceneOrder[0] = topicSessionPairs[0][0]; // First topic
        sceneOrder[1] = topicSessionPairs[0][1]; // First session
        sceneOrder[2] = topicSessionPairs[1][0]; // Second topic
        sceneOrder[3] = topicSessionPairs[1][1]; // Second session
    }

    // Get the next scene index based on the randomized order
    public int GetNextScene(int currentSceneIndex)
    {
        // The logic to determine the next scene based on the current scene index
        if (currentSceneIndex == 1) // After the introduction scene
        {
            return sceneOrder[0]; // Go to the first randomized topic
        }
        else if (currentSceneIndex == sceneOrder[0]) // After the first topic
        {
            return sceneOrder[1]; // Go to its session
        }
        else if (currentSceneIndex == sceneOrder[1]) // After the first session
        {
            return 4; // Go to the break scene
        }
        else if (currentSceneIndex == 4) // After the break scene
        {
            return sceneOrder[2]; // Go to the second randomized topic
        }
        else if (currentSceneIndex == sceneOrder[2]) // After the second topic
        {
            return sceneOrder[3]; // Go to its session
        }
        else if (currentSceneIndex == sceneOrder[3]) // After the second session (last one)
        {
            return 0; // Return to the menu (assuming menu is scene index 0)
        }

        return currentSceneIndex + 1; // Default behavior for other scenes
    }
}
