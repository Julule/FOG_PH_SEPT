using System;
using UnityEngine;

public class Player_Journal : Player_Talk
{
    [SerializeField] private GameObject journalCanvas;

    void Update()
    {
        Freeze();
        OpenJournal();
    }

    void OpenJournal()
    {
        journalCanvas.gameObject.SetActive(true);
    }


}
