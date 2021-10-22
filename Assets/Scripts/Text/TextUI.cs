using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUI : MonoBehaviour
{
    [SerializeField] private GameObject textBox; 
    [SerializeField] private TMP_Text textLabel;
    private PlayerInputHandler playerInput;
    private TypeWriterEffect typeWriterEffect;
    private RectTransform boxTransform;
    

    public bool isOpen { get; private set; }

    
    private void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        boxTransform = textBox.GetComponent<RectTransform>();
        CloseDialogueBox();
    }

    public void ShowDialogue(TextObject textObject)
    {
        isOpen = true;
        boxTransform.anchoredPosition = new Vector2(textObject.posX, textObject.posY);
        textBox.SetActive(true);
        StartCoroutine(routine: StepThroughText(textObject));
        DestroyImmediate(textObject, true);
    }

    private IEnumerator StepThroughText(TextObject textObject)
    {     
        foreach(string dialogue in textObject.Dialogue)
        {
            yield return typeWriterEffect.Run(dialogue, textLabel);

            yield return new WaitForSeconds(1);
            textLabel.CrossFadeAlpha(0, 1, false);
            yield return new WaitForSeconds(1);
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
