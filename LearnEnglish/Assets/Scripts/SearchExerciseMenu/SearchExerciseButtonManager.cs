using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SearchExerciseButtonManager : MonoBehaviour
{
    AudioSource audioSource;
    
    public bool isTrueAnswer;
    
    SearchExerciseManager searchExerciseManager;
    
    AudioSource[] allSounds;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        searchExerciseManager = Object.FindObjectOfType<SearchExerciseManager>();
    }

    public void PlaySound()
    {
        if (audioSource && searchExerciseManager.PressAble)
        {
            StopAllSounds();
            audioSource.Play();
        }
    
        if(isTrueAnswer && searchExerciseManager.PressAble) 
        {
            StopAllSounds();
            audioSource.Play();
            searchExerciseManager.MovePannel(); 
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
