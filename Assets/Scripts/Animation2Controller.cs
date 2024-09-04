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
        }
        else
        {
            Debug.LogError("SALSA component is not assigned!");
        }
          // Start in idle animation
        animator.SetBool("isIdle", true);
    }

     IEnumerator SyncAnimationsWithAudio()
    {
        // Wait for specific times in the audio to trigger animations
        yield return new WaitUntil(() => salsa.audioSrc.time >= 0f);
        TriggerWaveAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 4f);
        TriggerTalking2Animation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 7f);
        TriggerTalkingAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 12f);
        TriggerSurprisedAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 20f);
        TriggerHeadShakeAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 24f);
        TriggerLaughAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 50f);
        TriggerLookAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 63f);
        TriggerVictoryAnimation();
        
        yield return new WaitUntil(() => salsa.audioSrc.time >= 66f);
        TriggerTalking2Animation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 78f);
        TriggerLaughAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 90f);
        TriggerThankfulAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 108f);
        TriggerNLookingAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 121f);
        TriggerTalking2Animation();
        
        //tc0
        yield return new WaitUntil(() => salsa.audioSrc.time >= 126f);
        TriggerVictoryAnimation();

        // talking for puncho 
        yield return new WaitUntil(() => salsa.audioSrc.time >= 145f);
        TriggerTalkingAnimation();

        //tc1
        yield return new WaitUntil(() => salsa.audioSrc.time >= 160f);
        TriggerTalking2Animation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 177f);
        TriggerHeadShakeAnimation();

        //tc2
        yield return new WaitUntil(() => salsa.audioSrc.time >= 186f);
        TriggerTalking2Animation();

        // reacting 
        yield return new WaitUntil(() => salsa.audioSrc.time >= 193f);
        TriggerReactAnimation();

        //tc3
        // yield return new WaitUntil(() => salsa.audioSrc.time >= 198f);
        // TriggerTalking2Animation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 198f);
        TriggerLNodingAnimation();
        

        //tc4
        yield return new WaitUntil(() => salsa.audioSrc.time >= 208f);
        TriggerListenAnimation();

        //tc5
        yield return new WaitUntil(() => salsa.audioSrc.time >= 221f);
        TriggerNodingAnimation();

        // shrug
        yield return new WaitUntil(() => salsa.audioSrc.time >= 228f);
        TriggerVictoryAnimation();

        //tc6
        yield return new WaitUntil(() => salsa.audioSrc.time >= 237f);
        TriggerTalkingAnimation();

        //tc7
        yield return new WaitUntil(() => salsa.audioSrc.time >= 267f);
        TriggerTalking2Animation();

        //tc5
        yield return new WaitUntil(() => salsa.audioSrc.time >= 270f);
        TriggerLookAnimation();

        //tc5
        yield return new WaitUntil(() => salsa.audioSrc.time >= 275f);
        TriggerLNodingAnimation();

        // yield return new WaitUntil(() => salsa.audioSrc.time >= 281f);
        // TriggerThankfulAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 281f);
        TriggerWaveAnimation();
    }

    
 void ResetAllBooleans()
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isWaving", false);
        animator.SetBool("isTalking", false);
        animator.SetBool("isShrugging", false);
        animator.SetBool("isSurprised", false);
        animator.SetBool("isHeadShaking", false);
        animator.SetBool("isLaughing", false);
        animator.SetBool("isReacting", false);
        animator.SetBool("isThankful", false);
        animator.SetBool("isLooking", false);
        animator.SetBool("isListening", false);
        animator.SetBool("isTalking2", false);
        animator.SetBool("isNLooking", false);
        animator.SetBool("isNoding", false);
        animator.SetBool("isLNoding", false);
    }

    void TriggerWaveAnimation()
    {
        ResetAllBooleans();
        animator.SetBool("isWaving", true);
        Invoke("SetIdleState", 2f);
    }

    void TriggerTalkingAnimation()
    {
        ResetAllBooleans();
        animator.SetBool("isTalking", true);
        Invoke("SetIdleState", 2f);
    }

    void TriggerVictoryAnimation()
    {
        ResetAllBooleans();
        animator.SetBool("isShrugging", true);
        Invoke("SetIdleState", 2f);
    }

    void TriggerSurprisedAnimation()
    {
        ResetAllBooleans();
        animator.SetBool("isSurprised", true);
        Invoke("SetIdleState", 4f);
    }

    void TriggerHeadShakeAnimation()
    {
        ResetAllBooleans();
        animator.SetBool("isHeadShaking", true);
        Invoke("SetIdleState", 2f);
    }

    void TriggerLaughAnimation()
    {
        ResetAllBooleans();
        animator.SetBool("isLaughing", true);
        Invoke("SetIdleState", 6f);
    }

    void TriggerReactAnimation()
    {
        ResetAllBooleans();
        animator.SetBool("isReacting", true);
        Invoke("SetIdleState", 3f);
    }

    void TriggerLookAnimation()
    {
        ResetAllBooleans();
        animator.SetBool("isLooking", true);
        Invoke("SetIdleState", 4f);
    }

    void TriggerListenAnimation()
    {
        ResetAllBooleans();
        animator.SetBool("isListening", true);
        Invoke("SetIdleState", 4f);
    }

    void TriggerThankfulAnimation()
    {
        ResetAllBooleans();
        animator.SetBool("isThankful", true);
        Invoke("SetIdleState", 3f);
    }

    // Talk2Trigger
    void TriggerTalking2Animation()
    {
        ResetAllBooleans();
        animator.SetBool("isTalking2", true);
        Invoke("SetIdleState", 2f);
    }

    // NlookTrigger
    void TriggerNLookingAnimation()
    {
        ResetAllBooleans();
        animator.SetBool("isNLooking", true);
        Invoke("SetIdleState", 3f);
    }
    // NodTrigger
    void TriggerNodingAnimation()
    {
        ResetAllBooleans();
        animator.SetBool("isNoding", true);
        Invoke("SetIdleState", 2f);
    }
    // LNodTrigger
    void TriggerLNodingAnimation()
    {
        ResetAllBooleans();
        animator.SetBool("isLNoding", true);
        Invoke("SetIdleState", 3f);
    }


    void SetIdleState()
    {
        ResetAllBooleans();
        animator.SetBool("isIdle", true);
    }
    
}
