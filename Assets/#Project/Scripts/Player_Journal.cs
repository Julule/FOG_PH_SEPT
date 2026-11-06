using System;
using UnityEngine;

public class Player_Journal : Player_Talk
{
    [SerializeField] private GameObject journalCanvas;
    // [SerializeField] public GameObject openJournalButton;

    void OnEnable()
    {
        Freeze();
        OpenJournal();
    }

    void OpenJournal()
    {
        journalCanvas.gameObject.SetActive(true);
        openJournalButton.gameObject.SetActive(false);
    }


}
