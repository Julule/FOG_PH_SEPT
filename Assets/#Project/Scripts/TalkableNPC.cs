using System;
using UnityEngine;

public class TalkableNPC : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject talkButton;

    void Start()
    {
        talkButton.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        Collider playerCollider = player.GetComponent<Collider>();

        if (other == playerCollider)
            Debug.Log($"collision with {player} !");
            talkButton.SetActive(true);
            // PlayerStatesMachine.SwitchState(Player_Talk)
    }

    void OnTriggerExit(Collider other)
    {
        Collider playerCollider = player.GetComponent<Collider>();
        if (other == playerCollider)
            talkButton.SetActive(false);
            // PlayerStates.SwitchState(Walk)
    }
}
