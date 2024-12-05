using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchButtonManager : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    { 
        audioSource = GetComponent<AudioSource>();
    }

    public void WordSound()
    {
        if (audioSource) {audioSource.Play();}
    }
}
