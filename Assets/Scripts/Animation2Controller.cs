using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrazyMinnow.SALSA;  // Include the SALSA LipSync namespace

public class Animation2Controller : MonoBehaviour
{
    public Animator animator;  // Assign in the Unity Inspector
    // public AudioSource audioSource;  // Assign the AudioSource in the Inspector
    public Salsa salsa;  // Reference to the SALSA LipSync component


     void Start()
    {
         // Automatically find and assign the SALSA component
        salsa = GetComponentInChildren<Salsa>();

         // Ensure SALSA is properly assigned
        if (salsa != null)
        {
            // Play audio through the SALSA component's AudioSource
            salsa.audioSrc.Play();  // Use 'audioSrc' in SALSA v2.x

        // Example: Start playing audio when the scene starts
        // audioSource.Play();

            // Start syncing animations with audio
            StartCoroutine(SyncAnimationsWithAudio());


        // Schedule animations based on the audio timing
        // Invoke("TriggerWaveAnimation", 0f);  // Trigger wave after 2 seconds
        // Invoke("TriggerTalkingAnimation", 2f);  // Trigger talking after 5 seconds
        // Invoke("TriggerTalkingAnimation", 7f);
        // Invoke("TriggerSurprisedAnimation", 10f);
        // // Invoke("TriggerLaughAnimation", 15f);
        // Invoke("TriggerHeadShakeAnimation", 20f);
        // Invoke("TriggerLaughAnimation", 30f);
        // Invoke("TriggerLookAnimation", 55f);
        // Invoke("TriggerVictoryAnimation", 60f);
        // Invoke("TriggerLaughAnimation", 70f);
        // Invoke("TriggerHeadShakeAnimation", 80f);
        // Invoke("TriggerThankfulAnimation", 270f);
        }
        else
        {
            Debug.LogError("SALSA component is not assigned!");
        }

    }

     IEnumerator SyncAnimationsWithAudio()
    {
        // Wait for specific times in the audio to trigger animations
        yield return new WaitUntil(() => salsa.audioSrc.time >= 0f);
        TriggerWaveAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 2f);
        TriggerTalkingAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 7f);
        TriggerTalkingAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 10f);
        TriggerSurprisedAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 15f);
        TriggerLaughAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 20f);
        TriggerHeadShakeAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 30f);
        TriggerLaughAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 50f);
        TriggerLookAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 59f);
        TriggerVictoryAnimation();
        
        yield return new WaitUntil(() => salsa.audioSrc.time >= 66f);
        TriggerTalkingAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 80f);
        TriggerLaughAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 85f);
        TriggerThankfulAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 106f);
        TriggerLookAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 120f);
        TriggerTalkingAnimation();
        
        //tc0
        yield return new WaitUntil(() => salsa.audioSrc.time >= 126f);
        TriggerVictoryAnimation();

        //tc1
        yield return new WaitUntil(() => salsa.audioSrc.time >= 160f);
        TriggerTalkingAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 177f);
        TriggerHeadShakeAnimation();

        //tc2
        yield return new WaitUntil(() => salsa.audioSrc.time >= 185f);
        TriggerTalkingAnimation();

        //tc3
        yield return new WaitUntil(() => salsa.audioSrc.time >= 197f);
        TriggerTalkingAnimation();

        //tc4
        yield return new WaitUntil(() => salsa.audioSrc.time >= 208f);
        TriggerListenAnimation();

        //tc5
        yield return new WaitUntil(() => salsa.audioSrc.time >= 220f);
        TriggerHeadShakeAnimation();

        //tc6
        yield return new WaitUntil(() => salsa.audioSrc.time >= 237f);
        TriggerTalkingAnimation();

        //tc7
        yield return new WaitUntil(() => salsa.audioSrc.time >= 267f);
        TriggerTalkingAnimation();

        //tc5
        yield return new WaitUntil(() => salsa.audioSrc.time >= 270f);
        TriggerLookAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 275f);
        TriggerThankfulAnimation();
    }

    
     void TriggerWaveAnimation()
    {
        // salsa.AudioSource.PlayOneShot(waveClip);
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

    
     void TriggerListenAnimation()
    {
        animator.SetTrigger("ListeningTrigger");  // This triggers the talking animation
    }


     void TriggerThankfulAnimation()
    {
        animator.SetTrigger("ThankfulTrigger");  // This triggers the talking animation
    }
}
