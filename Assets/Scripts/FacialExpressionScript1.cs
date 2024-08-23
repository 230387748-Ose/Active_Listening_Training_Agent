using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacialExpressionScript1 : MonoBehaviour
{
   public FaceController faceController;
    
    private void Start()
    {
        StartCoroutine(PlayFacialExpressions());
    }

    private IEnumerator PlayFacialExpressions()
    {
        // Start - Excitement
        faceController.setCategoricalEmotion("Happiness", 0.8f, 2.0f, 10.0f, 2.0f);
        yield return new WaitForSeconds(14.0f); // Duration until 00:14
        
        // Reflective - Neutral
        faceController.setCategoricalEmotion("Neutral", 0.5f, 2.0f, 10.0f, 2.0f);
        yield return new WaitForSeconds(6.0f); // Duration until 00:20
        
        // Amused - Mild Happiness
        faceController.setCategoricalEmotion("Happiness", 0.6f, 2.0f, 5.0f, 2.0f);
        yield return new WaitForSeconds(7.0f); // Duration until 00:27
        
        // Thoughtful - Neutral
        faceController.setCategoricalEmotion("Neutral", 0.5f, 2.0f, 8.0f, 2.0f);
        yield return new WaitForSeconds(16.0f); // Duration until 00:43
        
        // Excited - Strong Happiness
        faceController.setCategoricalEmotion("Happiness", 0.9f, 2.0f, 10.0f, 2.0f);
        yield return new WaitForSeconds(19.0f); // Duration until 01:02
        
        // Concern - Mild Sadness
        faceController.setCategoricalEmotion("Sadness", 0.7f, 2.0f, 8.0f, 2.0f);
        yield return new WaitForSeconds(11.0f); // Duration until 01:13
        
        // Neutral - Reflective
        faceController.setCategoricalEmotion("Neutral", 0.5f, 2.0f, 10.0f, 2.0f);
        yield return new WaitForSeconds(9.0f); // Duration until 01:22

        // Thoughtful - Mild Sadness
        faceController.setCategoricalEmotion("Sadness", 0.6f, 2.0f, 8.0f, 2.0f);
        yield return new WaitForSeconds(10.0f); // Duration until 01:32
        
        // Encouraging - Mild Happiness
        faceController.setCategoricalEmotion("Happiness", 0.7f, 2.0f, 12.0f, 2.0f);
        yield return new WaitForSeconds(17.0f); // Duration until 01:49
        
        // Hopeful - Mild Happiness
        faceController.setCategoricalEmotion("Happiness", 0.7f, 2.0f, 14.0f, 2.0f);
        yield return new WaitForSeconds(20.0f); // Duration until 02:09
        
        // Optimistic - Strong Happiness
        faceController.setCategoricalEmotion("Happiness", 0.8f, 2.0f, 10.0f, 2.0f);
        yield return new WaitForSeconds(10.0f); // Duration until 02:19
        
        // Neutral - Reflective
        faceController.setCategoricalEmotion("Neutral", 0.5f, 2.0f, 8.0f, 2.0f);
        yield return new WaitForSeconds(11.0f); // Duration until 02:30
        
        // Mild Concern - Sadness
        faceController.setCategoricalEmotion("Sadness", 0.5f, 2.0f, 8.0f, 2.0f);
        yield return new WaitForSeconds(10.0f); // Duration until 02:40
        
        // Curious - Mild Surprise
        faceController.setCategoricalEmotion("Surprise", 0.6f, 2.0f, 8.0f, 2.0f);
        yield return new WaitForSeconds(10.0f); // Duration until 02:50
        
        // Neutral - Thoughtful
        faceController.setCategoricalEmotion("Neutral", 0.5f, 2.0f, 10.0f, 2.0f);
        yield return new WaitForSeconds(30.0f); // Duration until 03:20
        
        // Optimistic - Mild Happiness
        faceController.setCategoricalEmotion("Happiness", 0.7f, 2.0f, 14.0f, 2.0f);
        yield return new WaitForSeconds(30.0f); // Duration until 03:50
        
        // Concern - Sadness
        faceController.setCategoricalEmotion("Sadness", 0.6f, 2.0f, 10.0f, 2.0f);
        yield return new WaitForSeconds(10.0f); // Duration until 04:00
        
        // Mild Happiness - Hopeful
        faceController.setCategoricalEmotion("Happiness", 0.7f, 2.0f, 14.0f, 2.0f);
        yield return new WaitForSeconds(30.0f); // Duration until 04:30
        
        // Neutral - Reflective
        faceController.setCategoricalEmotion("Neutral", 0.5f, 2.0f, 8.0f, 2.0f);
        yield return new WaitForSeconds(15.0f); // Duration until 04:45
        
        // End - Strong Happiness
        faceController.setCategoricalEmotion("Happiness", 0.8f, 2.0f, 15.0f, 2.0f);
    }

}
