using UnityEngine;

public class ClickableObject : MonoBehaviour
{

    private void OnMouseDown()
    {
        Debug.Log("L'objet a été cliqué !");
        // StartDialogue(); // passer en paramêtre le dialogue en question ? 
    }
}
