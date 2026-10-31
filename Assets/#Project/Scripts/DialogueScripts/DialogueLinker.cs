using UnityEngine;

public class DialogueLinker : MonoBehaviour
{

    [SerializeField] private PlayerStateMachine stateMachine;
    private PlayerStateMachine.PlayerStates talk;
    public DialogueSO dialogueSO; // to give the right Dialogue 
    public void TalkButton()
    {
        Debug.Log("talkbouton clicked");
        talk = PlayerStateMachine.PlayerStates.Talk;
        stateMachine.SwitchState(talk);
        DialogueManager.Instance.StartDialogue(dialogueSO);
        
    }

}
