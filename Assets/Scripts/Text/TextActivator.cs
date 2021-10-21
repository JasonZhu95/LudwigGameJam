using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextActivator : MonoBehaviour, IInteractable
{
    [SerializeField] public TextObject textObject;

    public void Interact(PlayerInputHandler player)
    {
        player.TextUI.ShowDialogue(textObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerInputHandler player) && !other.isTrigger)
        {
            player.Interactable = this;

            if(player.Interactable != null)
            {
                Interact(player); 
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerInputHandler player) && !other.isTrigger)
        {
            if(player.Interactable is TextActivator textActivator && textActivator == this)
            {
                player.Interactable = null;
            }
        }
    }
}
