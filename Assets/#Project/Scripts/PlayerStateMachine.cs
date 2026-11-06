using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public enum PlayerStates {Walk, Talk, Journal, Accusation};
    private PlayerStates currentState;
    private Player_Walk walk => GetComponent<Player_Walk>();
    private Player_Talk talk => GetComponent<Player_Talk>();
    private Player_Journal journal => GetComponent<Player_Journal>();
    private Player_Accusation accusation => GetComponent<Player_Accusation>();

    void Awake()
    {
        talk.enabled = false;
        walk.enabled = false;
        journal.enabled = false;
        accusation.enabled = false;
    }
    void Start()
    {
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
            accusation.enabled = false;
        }

        else if (currentState == PlayerStates.Walk)
        {
            walk.enabled = true;
            talk.enabled = false;
            journal.enabled = false;
            accusation.enabled = false;
        }

        else if (currentState == PlayerStates.Journal)
        {
            walk.enabled = false;
            talk.enabled = false;
            journal.enabled = true;
            accusation.enabled = false;
        }

        else if (currentState == PlayerStates.Accusation)
        {
            walk.enabled = false;
            talk.enabled = false;
            journal.enabled = true;
            accusation.enabled = true;
        }
    }
}
