using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoverButtonManager : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Sound()
    {
        audioSource.Play();
    }
}
