using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public enum PlayerStates {Walk, Talk};
    private PlayerStates currentState;
    private Player_Walk walk;
    private Player_Talk talk;

    void Start()
    {
        talk = GetComponent<Player_Talk>();
        talk.enabled = false;
        walk = GetComponent<Player_Walk>();
        walk.enabled = false;
        SwitchState(PlayerStates.Walk);
        Debug.Log($"le state de début est {currentState}");
    }

    public void SwitchState(PlayerStates newState)
    {
        currentState = newState; 

        if (currentState == PlayerStates.Talk)
        {
            talk.enabled = true;
            walk.enabled = false;
            Debug.Log($"changement de state : {currentState} ");
        }

        else if (currentState == PlayerStates.Walk)
        {
            walk.enabled = true;
            talk.enabled = false;
            Debug.Log($"changement de state : {currentState}");
        }
    }
}
