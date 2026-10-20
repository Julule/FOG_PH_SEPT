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
            // TalkButton();
    }

    void OnTriggerExit(Collider other)
    {
        Collider playerCollider = player.GetComponent<Collider>();
        if (other == playerCollider)
            talkButton.SetActive(false);
    }
}
