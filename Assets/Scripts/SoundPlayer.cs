using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public string soundClipPath;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        AudioClip soundClip = Resources.Load<AudioClip>(soundClipPath);
        if (soundClip != null)
        {
            audioSource.clip = soundClip;
        }
        else
        {
            Debug.LogError("Failed to load sound clip: " + soundClipPath);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
        }
    }
}
