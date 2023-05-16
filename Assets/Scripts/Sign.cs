using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogueBox;
    public string dialogueText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueBox.SetActive(true);
            Text textComponent = dialogueBox.GetComponentInChildren<Text>();
            if (textComponent != null)
            {
                textComponent.text = dialogueText;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueBox.SetActive(false);
        }
    }
}
