using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotDestroy : MonoBehaviour
{

    public AudioClip soundClip;

    private Animator anim;
    private AudioSource audioSource;

    void Start()
    {
        anim = GetComponent<Animator>();

        // Add an AudioSource component to the same GameObject if not already present
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Configure AudioSource settings
        audioSource.playOnAwake = false;
        audioSource.loop = false;
        audioSource.clip = soundClip;
    }

    public void Smash()
    {
        anim.SetBool("Smash", true);
        StartCoroutine(BreakCo());
    }

    IEnumerator BreakCo()
    {
        yield return new WaitForSeconds(0.3f);
        PlaySound();
        gameObject.SetActive(false);
    }

    private void PlaySound()
    {
        if (soundClip != null)
        {
            audioSource.PlayOneShot(soundClip);
        }
    }
}
