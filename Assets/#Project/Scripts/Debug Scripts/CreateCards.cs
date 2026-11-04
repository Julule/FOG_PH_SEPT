using UnityEngine;

public class CreateCards : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        JournalManager.Instance.CreateCard("test1");
        JournalManager.Instance.CreateCard("test2");
        JournalManager.Instance.CreateCard("test3");
        JournalManager.Instance.CreateCard("Fin du test!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
