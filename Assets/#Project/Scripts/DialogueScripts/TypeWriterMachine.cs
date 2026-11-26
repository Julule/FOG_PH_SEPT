using System.Collections;
using TMPro;
using UnityEngine;

public class TypeWriterMachine : MonoBehaviour
{
    public static TypeWriterMachine Instance;
    [SerializeField] private float charsPerSecond = 40f;
    private Coroutine typing;
    private AudioSource audioSource;

    [SerializeField] float audioSpeed;

    void Awake()
    {        
        if (Instance == null)
            Instance = this; // Instance variable contains this one
        else 
            Destroy(gameObject); // pour supprimer s'il n'y a pas d'instance
        
        audioSource = GetComponent<AudioSource>();
    }

    public void Show(string line, TMP_Text textPlaceholder)
    {
        if (typing != null) StopCoroutine(typing);
        typing = StartCoroutine(Type(line, textPlaceholder));
    }

    private IEnumerator Type(string line, TMP_Text textPlaceholder)
    {
        audioSource.Play();
        textPlaceholder.text = line;
        textPlaceholder.maxVisibleCharacters = 0;
        textPlaceholder.ForceMeshUpdate();

        int total = textPlaceholder.textInfo.characterCount;
        float delay = 1f / charsPerSecond;

        for (int i = 1; i <= total; i++)
        {
            if (i == total)
            {
                audioSource.Stop();
            }
            textPlaceholder.maxVisibleCharacters = i;
            // Debug.Log($"i={i}/{total}");
            yield return new WaitForSeconds(delay);
        }
        
        // Debug.Log("fin du typing");
        typing = null; 
    }

}
