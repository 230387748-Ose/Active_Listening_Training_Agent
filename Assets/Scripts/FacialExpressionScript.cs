using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacialExpressionScript : MonoBehaviour
{
    public FaceController faceController;

    private void Start()
    {
        StartCoroutine(PlayFacialExpressions());
    }

    private IEnumerator PlayFacialExpressions()
    {
        // Initial excitement and happiness
        faceController.setCategoricalEmotion("Happiness", 0.8f, 1.0f, 2.0f, 1.0f);
        yield return new WaitForSeconds(4f);

        // Nostalgia and thrill
        faceController.setCategoricalEmotion("Happiness", 0.6f, 1.0f, 3.0f, 1.0f);
        yield return new WaitForSeconds(10f);

        // Anticipation and excitement
        faceController.setCategoricalEmotion("Neutral", 0.7f, 1.0f, 3.0f, 1.0f);
        yield return new WaitForSeconds(5f);

        // Amazement and awe
        faceController.setCategoricalEmotion("Neutral", 0.9f, 1.0f, 3.0f, 1.0f);
        yield return new WaitForSeconds(6f);

        // Joy and delight
        faceController.setCategoricalEmotion("Happiness", 1.0f, 1.0f, 4.0f, 1.0f);
        yield return new WaitForSeconds(8f);

        // Satisfaction and amusement
        faceController.setCategoricalEmotion("Happiness", 0.8f, 1.0f, 3.0f, 1.0f);
        yield return new WaitForSeconds(8f);

        // Excitement and fear (dragon battle)
        faceController.setCategoricalEmotion("Neutral", 0.9f, 1.0f, 5.0f, 2.0f);
        yield return new WaitForSeconds(12f);

        // Thrill and amazement (Jurassic Park)
        faceController.setCategoricalEmotion("Neutral", 0.9f, 1.0f, 5.0f, 2.0f);
        yield return new WaitForSeconds(12f);

        // Humor and joy (Springfield)
        faceController.setCategoricalEmotion("Happiness", 1.0f, 1.0f, 5.0f, 2.0f);
        yield return new WaitForSeconds(10f);

        // Excitement and awe (Transformers)
        faceController.setCategoricalEmotion("Neutral", 0.8f, 1.0f, 4.0f, 2.0f);
        yield return new WaitForSeconds(8f);

        // Magic and awe (Nighttime Lights at Hogwarts)
        faceController.setCategoricalEmotion("Neutral", 0.9f, 1.0f, 5.0f, 2.0f);
        yield return new WaitForSeconds(10f);

        // Contentment and joy (End of the day)
        faceController.setCategoricalEmotion("Happiness", 1.0f, 1.0f, 6.0f, 3.0f);
        yield return new WaitForSeconds(10f);
    }
}
