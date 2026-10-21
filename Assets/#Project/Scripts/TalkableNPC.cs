using System;
using UnityEngine;

public class TalkableNPC : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject talkButton;
    [SerializeField] private PlayerStateMachine stateMachine;
    private PlayerStateMachine.PlayerStates talk;
    private PlayerStateMachine.PlayerStates walk;


    void Start()
    {
        talkButton.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        Collider playerCollider = player.GetComponent<Collider>();

        if (other == playerCollider)
            Debug.Log($"Trigger Enter ! Collision with {player} !");
            talkButton.SetActive(true);
            talk = PlayerStateMachine.PlayerStates.Talk;
            stateMachine.SwitchState(talk);
    }

    void OnTriggerExit(Collider other)
    {
        Collider playerCollider = player.GetComponent<Collider>();
        if (other == playerCollider)
            Debug.Log($"Trigger Exit !");
            talkButton.SetActive(false);
            // walk = PlayerStateMachine.PlayerStates.Walk;
            // stateMachine.SwitchState(walk);
    }
}
