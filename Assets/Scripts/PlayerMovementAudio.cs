using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovementAudio : MonoBehaviour
{
    public AudioClip movementAudioClip;
    public float minMoveSpeed = 0.1f;

    private AudioSource audioSource;
    private CharacterController characterController;
    private bool isMoving;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        
        bool isCurrentlyMoving = characterController.velocity.magnitude > minMoveSpeed;

        
        if (!isMoving && isCurrentlyMoving)
        {
            PlayMovementSound();
        }

        isMoving = isCurrentlyMoving;
    }

    private void PlayMovementSound()
    {
        if (movementAudioClip != null)
        {
            audioSource.clip = movementAudioClip;
            audioSource.PlayOneShot(movementAudioClip);
        }
    }
}
