using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUI : MonoBehaviour
{
    [SerializeField] private GameObject textBox; 
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private TextObject test;

    private TypeWriterEffect typeWriterEffect;
    private void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        ShowDialogue(test);
        //CloseDialogueBox();
    }

    public void ShowDialogue(TextObject textObject)
    {
        textBox.SetActive(true);
        StartCoroutine(routine: StepThroughText(textObject));
    }

    private IEnumerator StepThroughText(TextObject textObject)
    {
        yield return new WaitForSeconds(2);
        foreach(string dialogue in textObject.Dialogue)
        {
            yield return typeWriterEffect.Run(dialogue, textLabel);
            //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        //CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        textBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
