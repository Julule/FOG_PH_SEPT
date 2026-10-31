using System;
using UnityEngine;

public class TalkableNPC : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject talkButton;
    [SerializeField] private GameObject nextButton;

    void Start()
    {
        talkButton.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        Collider playerCollider = player.GetComponent<Collider>();

        if (other == playerCollider)
            // Debug.Log($"Trigger Enter ! Collision with {player} !");
            talkButton.SetActive(true);

    }

    void OnTriggerExit(Collider other)
    {
        Collider playerCollider = player.GetComponent<Collider>();
        if (other == playerCollider)
           // Debug.Log($"Trigger Exit !");
            talkButton.SetActive(false);
    }
}
