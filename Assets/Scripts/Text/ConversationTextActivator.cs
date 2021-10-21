using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTextActivator : MonoBehaviour
{
    private DisplayConversation dis;
    public GameObject DialogueCanvas;

    public void Start()
    {
        dis = DialogueCanvas.GetComponent<DisplayConversation>();
    }
    public void Interact()
    {
        dis.AdvanceConversation();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerInputHandler player) && !other.isTrigger)
        {
            Interact();
        }

    }
}
