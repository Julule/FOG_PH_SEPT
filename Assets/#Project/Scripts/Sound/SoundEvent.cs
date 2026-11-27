using System.Collections.Generic;
using UnityEngine;

public class SoundEvent : MonoBehaviour
{
    [SerializeField] public AudioSource source;
    [SerializeField] public List<AudioClip> allClips = new();
    private int i = 0;


    public void PlaySound()
    {
        source.Play();
    }


    public void PlayRandomSound()
    {
        
        if (i == 0)
        {
            source.Stop();
            source.PlayOneShot(allClips[1]);
            i = 1;
        }
        else if (i == 1)
        {
            source.Stop();
            source.PlayOneShot(allClips[0]);
            i = 0;
        }
    }

    public void StopSound()
    {
        source.Stop();
    }
}
