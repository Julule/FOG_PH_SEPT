using System;
using System.IO;
using UnityEngine;
[CreateAssetMenu(fileName = "DialogueSO", menuName = "Dialogue/DialogueNode")]
public class DialogueSO : ScriptableObject 
// SO permet de stocker des données accessibles et éditables dans l'inspec sans lien avec un objet de la hierarchie.  
// SO permet aussi de fournir les infos à plusieurs objets différents, offre un stock de données persistantes dans le jeu
{
    public DialogueLine[] lines;
    public DialogueOption[] optionToRightClue;

    public DialogueOption[] optionToFalseClue;
}

[System.Serializable] // Pour intégrer et afficher l'"enfant" ActorSO dans ce SO, et qu'il soit Serializable
public class DialogueLine
{
    public ActorSO speaker;
    [TextArea(3,5)] public string text;
}

[System.Serializable] // Pour intégrer et afficher l'"enfant" ActorSO dans ce SO, et qu'il soit Serializable
public class DialogueOption
{
    [TextArea(3,5)] public string optionText; // texte de l'option
    public DialogueSO nextDialogue; // ligne conditionelle à l'option correpsondante
    public string clue; // right or false clue here
}
