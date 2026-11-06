using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayCard : MonoBehaviour
{
    [SerializeField] public bool rightAnswer;
    [SerializeField] GameObject highlight; // un enfant (cadre, halo...) activé quand sélectionné

    public bool IsSelected { get; private set; }

    public void HighLight(bool value)
    {
        IsSelected = value;
        if (highlight != null) highlight.SetActive(value);
    }
}
