using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickInput : MonoBehaviour, IDragHandler, IEndDragHandler
{
    

    private void Start()
    {
        // Find the PlayerMovement script in the scene
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Calculate the direction of the joystick input
        Vector2 inputDirection = eventData.position - (Vector2)transform.position;
        inputDirection = inputDirection.normalized;

        // Pass the input direction to the player movement script
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // When the joystick is released, reset the input direction to zero
        
    }
}
