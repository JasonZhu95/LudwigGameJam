using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private TextObject textObject;
    public void Interact(PlayerInputHandler player)
    {
        player.TextUI.ShowDialogue(textObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerInputHandler player))
        {
            player.Interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerInputHandler player))
        {
            if(player.Interactable is TextActivator textActivator && textActivator == this)
            {
                player.Interactable = null;
            }
        }
    }
}
