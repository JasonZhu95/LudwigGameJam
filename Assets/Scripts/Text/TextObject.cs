using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Object")]
public class TextObject : ScriptableObject
{
    public int posX = 0;
    public int posY = 0;
    public bool show = true;

    [SerializeField] [TextArea] private string[] dialogue;

    public string[] Dialogue => dialogue;

}
