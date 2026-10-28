using System;
using System.IO;
using UnityEngine;
[CreateAssetMenu(fileName = "DialogueSO", menuName = "Dialogue/DialogueNode")]
public class DialogueSO : ScriptableObject 
// SO permet de stocker des données accessibles et éditables dans l'inspec sans lien avec un objet de la hierarchie.  
// SO permet aussi de fournir les infos à plusieurs objets différents, offre un stock de données persistantes dans le jeu
{
    public DialogueLine[] lines;
    public string rightDialogueClue;
    public string fakeDialogueClue;
}

[System.Serializable] // Pour intégrer et afficher l'"enfant" ActorSO dans ce SO, et qu'il soit Serializable
public class DialogueLine
{
    public ActorSO speaker;
    [TextArea(3,5)] public string text;
}
