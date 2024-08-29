using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation2Controller : MonoBehaviour
{
    public Animator animator;  // Assign in the Unity Inspector
    // public AudioSource audioSource;  // Assign the AudioSource in the Inspector

    void Start()
    {
        // Example: Start playing audio when the scene starts
        // audioSource.Play();

        // Schedule animations based on the audio timing
        Invoke("TriggerWaveAnimation", 0f);  // Trigger wave after 2 seconds
        Invoke("TriggerTalkingAnimation", 4f);  // Trigger talking after 5 seconds
        Invoke("TriggerVictoryAnimation", 10f);
        Invoke("TriggerSurprisedAnimation", 15f);
        Invoke("TriggerHeadShakeAnimation", 20f);
        Invoke("TriggerLaughAnimation", 30f);
        Invoke("TriggerReactAnimation", 40f);
        Invoke("TriggerLookAnimation", 50f);
        Invoke("TriggerVictoryAnimation", 60f);
        Invoke("TriggerLaughAnimation", 70f);
        Invoke("TriggerHeadShakeAnimation", 80f);
        Invoke("TriggerThankfulAnimation", 90f);
    }

    
     void TriggerWaveAnimation()
    {
        animator.SetTrigger("WaveTrigger");  // This triggers the talking animation
    }

    void TriggerTalkingAnimation()
    {
        animator.SetTrigger("TalkTrigger");  // This triggers the talking animation
    }

     void TriggerVictoryAnimation()
    {
        animator.SetTrigger("VictoryTrigger");  // This triggers the talking animation
    }

     void TriggerSurprisedAnimation()
    {
        animator.SetTrigger("SurprisedTrigger");  // This triggers the talking animation
    }

     void TriggerHeadShakeAnimation()
    {
        animator.SetTrigger("HeadShakeTrigger");  // This triggers the talking animation
    }

     void TriggerLaughAnimation()
    {
        animator.SetTrigger("LaughTrigger");  // This triggers the talking animation
    }

     void TriggerReactAnimation()
    {
        animator.SetTrigger("ReactTrigger");  // This triggers the talking animation
    }

     void TriggerLookAnimation()
    {
        animator.SetTrigger("LookTrigger");  // This triggers the talking animation
    }

     void TriggerThankfulAnimation()
    {
        animator.SetTrigger("ThankfulTrigger");  // This triggers the talking animation
    }
}
