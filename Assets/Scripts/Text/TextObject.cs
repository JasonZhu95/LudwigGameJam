using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Object")]
public class TextObject : ScriptableObject
{
    public int posX = 0;
    public int posY = 0;

    [SerializeField] [TextArea] private string[] dialogue;

    public string[] Dialogue => dialogue;

}
