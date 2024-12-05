using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SearchExerciseManager : MonoBehaviour
{
    int PartNo;

    public bool PressAble;

    AudioClip clip;

    AudioSource[] allSounds;

    StarControlManager starControlManager;

    private void Awake()
    {
        starControlManager = Object.FindObjectOfType<StarControlManager>();
    }

    private void Start()
    {
        PressAble = false;
        StopAllSounds();
        Sound();
    }


    public void MovePannel()
    {
        if (PartNo >= 37)
        {
            return;
        }

        PartNo++;

        if (PartNo == 37)
        {
            // 37. panelde bir işlem yapma
            Transform panel37 = this.gameObject.transform.GetChild(PartNo);
            if (panel37 != null)
            {
                panel37.GetComponentInChildren<Button>().interactable = true;
            }
            return;
        }

        starControlManager.BrightTheStar(PartNo);
        this.gameObject.GetComponent<RectTransform>().DOLocalMoveX(this.gameObject.GetComponent<RectTransform>().localPosition.x - 1280f, 0.5f);
        Sound();
    }


    void Sound()
    {
        PressAble = false;

        if (PartNo >= this.gameObject.transform.childCount)
        {
            Debug.LogWarning("PartNo geçerli çocuk sayısını aşıyor!");
            return;
        }

        Transform obj = this.gameObject.transform.GetChild(PartNo);

        for (int i = 0; i < 3; i++)
        {
            var buttonManager = obj.GetChild(i).GetComponent<SearchExerciseButtonManager>();
            if (buttonManager != null && !buttonManager.isTrueAnswer)
            {
                clip = obj.GetChild(i).GetComponent<AudioSource>().clip;
                if (clip != null)
                {
                    AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
                    Invoke("isAbleToPress", clip.length);
                }
                else
                {
                    Debug.LogWarning("Ses klibi bulunamadı!");
                }
                return;
            }
        }
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

    public void TurnBack()
    {
        SceneManager.LoadScene("SearchScene");
    }

    public void TurnHome()
    {
        SceneManager.LoadScene("MainScene");
    }

}