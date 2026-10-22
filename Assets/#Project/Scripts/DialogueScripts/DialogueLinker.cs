using UnityEngine;

public class DialogueLinker : MonoBehaviour
{

    public DialogueSO dialogueSO; // to give the right Dialogue 
    public void TalkButton()
    {
        Debug.Log("boutonnnnnn");
        DialogueManager.Instance.StartDialogue(dialogueSO);
    }

}
