using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class Player_Accusation : MonoBehaviour
{
    [SerializeField] Transform cardsContainer; // le parent des objets dans le journal
    [SerializeField] Button submitButton;      // le bouton "Soumettre"
    [SerializeField] int requiredCount = 3; // le nb de cartes nécéssaires au submit
    private List<PlayCard> selected = new List<PlayCard>(); // les objets actuellement sélectionnés
    PlayCard[] playCards; // tous les objets du journal

    void OnEnable()
    {
        playCards = cardsContainer.GetComponentsInChildren<PlayCard>(true);
        Debug.Log($"Démarage d'Accusation ! cartes en jeu : {playCards.Length}");

        selected.Clear();

        foreach (var card in playCards) // activer le highlight onclick
        {
            var pCard = card; // nécessaire pour l'équivalence
            pCard.HighLight(false);
            pCard.GetComponent<Button>().onClick.AddListener(() => Toggle(pCard));
        }

        submitButton.onClick.AddListener(Submit); // Préparer un evenement au clic sur le bouton
        RefreshSubmit();
    }

    void OnDisable()
    {
        foreach (var playCard in playCards) // retirer les listeners pour les highlights et le submit
        {
            playCard.GetComponent<Button>().onClick.RemoveAllListeners();
            submitButton.onClick.RemoveListener(Submit);   
        }
    }

    void Toggle(PlayCard playCard)
    {
        if (selected.Contains(playCard))
        {
            selected.Remove(playCard);
            playCard.HighLight(false);
        }
        else if (selected.Count < requiredCount)
        {
            Debug.Log("Maximum 3 cartes !");
            selected.Add(playCard);
            playCard.HighLight(true);
        }
        RefreshSubmit();
    }

    void Submit()
    {
        bool allRight = true;
        foreach (var item in selected)
        {
            if (!item.rightAnswer) { allRight = false; break; } // dès la première erreur, condition allRight devient fausse et le test s'arrête
        }

        if (allRight) OnWin();
        else OnFail();
        
    }


    void RefreshSubmit()
    {
        if (selected.Count == requiredCount) // il faut 3 cartes sélectionnées pour activer le submit button
        {
            submitButton.interactable = true;
        }
        else
        {
            submitButton.interactable = false;
        } 
    }
    void OnWin()  { Debug.Log("Bonne accusation !"); }
    void OnFail() { Debug.Log("Mauvaise accusation..."); }


}
