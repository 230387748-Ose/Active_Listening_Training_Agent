using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrazyMinnow.SALSA;

public class Animation1Controller : MonoBehaviour
{
    public Animator animator;  // Assign in the Unity Inspector
    public Salsa salsa;  // Reference to the SALSA LipSync component


    // Start is called before the first frame update
    void Start()
    {
         // Automatically find and assign the SALSA component
        salsa = GetComponentInChildren<Salsa>();

         // Ensure SALSA is properly assigned
        if (salsa != null)
        {
            // Play audio through the SALSA component's AudioSource
            salsa.audioSrc.Play();  // Use 'audioSrc' in SALSA v2.x

            // Start syncing animations with audio
            StartCoroutine(SyncAnimationsWithAudio());
        }
        else
        {
            Debug.LogError("SALSA component is not assigned!");
        }
    }

     IEnumerator SyncAnimationsWithAudio()
    {
        // Wait for specific times in the audio to trigger animations
        // yield return new WaitUntil(() => salsa.audioSrc.time >= 0f);
        // TriggerWaveAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 2f);
        TriggerTalkingAnimation();

        yield return new WaitUntil(() => salsa.audioSrc.time >= 285f);
        TriggerWaveAnimation();
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
}
