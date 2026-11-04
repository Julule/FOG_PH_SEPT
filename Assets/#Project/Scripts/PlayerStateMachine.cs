using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public enum PlayerStates {Walk, Talk, Journal};
    private PlayerStates currentState;
    private Player_Walk walk;
    private Player_Talk talk;
    private Player_Journal journal;

    void Start()
    {
        talk = GetComponent<Player_Talk>();
        talk.enabled = false;
        walk = GetComponent<Player_Walk>();
        walk.enabled = false;
        journal = GetComponent<Player_Journal>();
        journal.enabled = false;
        SwitchState(PlayerStates.Walk);
        //Debug.Log($"le state de début est {currentState}");
    }

    public void SwitchState(PlayerStates newState)
    {
        currentState = newState; 

        if (currentState == PlayerStates.Talk)
        {
            talk.enabled = true;
            walk.enabled = false;
            journal.enabled = false;
            //Debug.Log($"changement de state : {currentState} ");
        }

        else if (currentState == PlayerStates.Walk)
        {
            walk.enabled = true;
            talk.enabled = false;
            journal.enabled = false;
            //Debug.Log($"changement de state : {currentState}");
        }

        else if (currentState == PlayerStates.Journal)
        {
            walk.enabled = false;
            talk.enabled = false;
            journal.enabled = true;
            //Debug.Log($"changement de state : {currentState}");
        }
    }
}
