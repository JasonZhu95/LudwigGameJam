using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayConversation : MonoBehaviour
{
    private PlayerInputHandler playerInput;
    private TypeWriterEffect typeWriterEffect;

    public Conversation conversation;

    public GameObject speakerLeft;
    public GameObject speakerRight;

    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    private int activeLineIndex = 0;

    private void Start()
    {
        
        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();

        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;

        playerInput = GameObject.Find("Player").GetComponent<PlayerInputHandler>();
        typeWriterEffect = GetComponent<TypeWriterEffect>();

        speakerUILeft.Hide();
        speakerUIRight.Hide();
    }

    private void Update()
    {
        if (playerInput.InteractInput)
        {
            AdvanceConversation();
        }
    }

    public void AdvanceConversation()
    {
        if(activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex += 1;
        }
        else
        {
            speakerUILeft.Hide();
            speakerUIRight.Hide();
            activeLineIndex = 0;
            gameObject.SetActive(false);

        }
    }

    private void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if (speakerUILeft.SpeakerIs(character))
        {
            SetDialog(speakerUILeft, speakerUIRight, line.text);
        }
        else
        {
            SetDialog(speakerUIRight, speakerUILeft, line.text);
        }

        //StartCoroutine(routine: StepThroughText(textObject));
    }

    void SetDialog(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeaker, string text)
    {
        activeSpeakerUI.Dialogue = text;
        activeSpeakerUI.Show();
        inactiveSpeaker.Hide();
    }

    //private IEnumerator StepThroughText(TextObject textObject)
    //{
    //    foreach (string dialogue in textObject.Dialogue)
    //    {
    //        yield return typeWriterEffect.Run(dialogue, textLabel);
    //        yield return new WaitForSeconds(15);
    //    }
    //    CloseDialogueBox();
    //}
}
