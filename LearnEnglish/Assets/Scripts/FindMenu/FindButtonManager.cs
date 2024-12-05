using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindButtonManager : MonoBehaviour
{
    AudioSource audioSource;

    public bool isTrueAnswer;
    AudioSource[] allSounds;

    FindControlManager findControlManager;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        findControlManager = Object.FindObjectOfType<FindControlManager>(); 
    }
    public void PlaySound()
    {
        if (audioSource && findControlManager.PressAble)
        {
            StopAllSounds();
            audioSource.Play();
        }

        if (isTrueAnswer && findControlManager.PressAble)
        {
            StopAllSounds();
            audioSource.Play();

        }

    }
    void StopAllSounds()
    {
        allSounds = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        foreach (AudioSource audioSource in allSounds)
        {
            audioSource.Stop();
        }
    }
}
