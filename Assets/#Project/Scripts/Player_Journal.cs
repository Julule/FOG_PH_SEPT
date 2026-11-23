using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Journal : Player_Talk
{
    [SerializeField] private GameObject journalCanvas;
    [SerializeField] private GameObject page1;


    void OnEnable()
    {
        Freeze();
        journalCanvas.gameObject.SetActive(true);
        openJournalButton.gameObject.SetActive(false);
        // JournalManager.Instance.OpenJournal(page1);
    }

}
