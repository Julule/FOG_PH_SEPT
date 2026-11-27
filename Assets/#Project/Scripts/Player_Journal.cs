using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Journal : Player_Talk
{
    [SerializeField] private GameObject journalCanvas;
    [SerializeField] private GameObject page1;
    // [SerializeField] private AudioSource stateJournalSource;


    void OnEnable()
    {
        Freeze();
        journalCanvas.gameObject.SetActive(true);
        openJournalButton.gameObject.SetActive(false);
        // JournalManager.Instance.OpenJournal(page1);
        // stateJournalSource.Play();
        stateSource.Play();
    }

    void OnDisable()
    {
        //stateJournalSource.Stop();
        stateSource.Stop();
    }

}
