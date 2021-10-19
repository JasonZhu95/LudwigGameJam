using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUI : MonoBehaviour
{
    [SerializeField] private GameObject textBox; 
    [SerializeField] private TMP_Text textLabel;
    
    public bool isOpen { get; private set; }

    private TypeWriterEffect typeWriterEffect;
    private void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        CloseDialogueBox();
    }

    public void ShowDialogue(TextObject textObject)
    {
        isOpen = true;
        textBox.SetActive(true);
        StartCoroutine(routine: StepThroughText(textObject));
    }

    private IEnumerator StepThroughText(TextObject textObject)
    {     
        foreach(string dialogue in textObject.Dialogue)
        {
            yield return typeWriterEffect.Run(dialogue, textLabel);
            yield return new WaitForSeconds(2);
        }
        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        isOpen = false;
        textBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
