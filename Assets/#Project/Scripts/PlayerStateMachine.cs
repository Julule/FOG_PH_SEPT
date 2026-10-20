using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public enum PlayerStates {Default, Walk, Talk};
    public PlayerStates currentState = PlayerStates.Walk;
    private PlayerStates defaultState;

    public Player_Walk walk;
    public Player_Talk talk;

    void Start()
    {
        defaultState = currentState;
        SwitchState(currentState);
    }

    public void SwitchState(PlayerStates newState)
    {
        currentState = newState;
        
    }
}
