using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FindControlManager : MonoBehaviour
{
    int PartNo;
    AudioClip clip;

    public bool PressAble;

    int letterNumber;

    AudioSource[] allSounds;

    private void Start()
    {
        StartCoroutine(ShowLettersRoutine());
    }

    IEnumerator ShowLettersRoutine()
    {
        GameObject obj = this.transform.GetChild(PartNo).gameObject;

        Sound();

        while (letterNumber < 3)
        {
            obj.transform.GetChild(letterNumber).GetComponent<CanvasGroup>().DOFade(1, .1f);
            yield return new WaitForSeconds(.2f);
            letterNumber++;
        }
    }

    public void TurnBack()
    {
        SceneManager.LoadScene("MainScene");
    }

    void Sound()
    {
        PressAble = false;

        Transform obj = this.gameObject.transform.GetChild(PartNo);

        clip = obj.GetComponent<AudioSource>().clip;

        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);

        Invoke("isAbleToPress", clip.length);
    }

    private void isAbleToPress()
    {
        PressAble = true;
    }

    void StopAllSounds()
    {
        allSounds = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        foreach (AudioSource audioSource in allSounds)
        {
            audioSource.Stop();
        }
    }

    public void ListenAgain()
    {
        StopAllSounds();
        Sound();
    }
}
