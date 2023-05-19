using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepAudio : MonoBehaviour
{
    public AudioClip[] footstepClips;
    public float minWalkSpeed = 0.1f;

    private AudioSource audioSource;
    private bool isWalking;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
        bool isCurrentlyWalking = GetComponent<Rigidbody2D>().velocity.magnitude > minWalkSpeed;

        
        if (!isWalking && isCurrentlyWalking)
        {
            PlayFootstepSound();
        }

        isWalking = isCurrentlyWalking;
    }

    private void PlayFootstepSound()
    {
       
        if (footstepClips.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepClips.Length);
            AudioClip footstepClip = footstepClips[randomIndex];

            
            audioSource.PlayOneShot(footstepClip);
        }
    }
}
