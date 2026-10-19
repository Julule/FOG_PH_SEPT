using System;
using System.IO;
using UnityEngine;
[CreateAssetMenu(fileName = "DialogueSO", menuName = "Dialogue/DialogueNode")]
public class DialogueSO : ScriptableObject
{
    public DialogueLine[] lines;
    public string rightDialogueClue;
    public string fakeDialogueClue;
}

[System.Serializable]
public class DialogueLine
{
    public ActorSO speaker;
    [TextArea(3,5)] public string text;
}
