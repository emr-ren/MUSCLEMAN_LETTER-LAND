using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SearchManager : MonoBehaviour
{
    [SerializeField] GameObject fadeImg;
    AudioSource audioSearch;
    private void Awake()
    {
        audioSearch = GetComponent<AudioSource>();
    }
    void Start()
    {                                     //OnComplete = Bittikten sonra calistir
      fadeImg.GetComponent<CanvasGroup>().DOFade(0,1f).OnComplete(PlaySound);
    }

    //Bunu silebilirim!!!!
   /* void StartingSound()
    {
        audioSearch.Play();
    }
   */

    void PlaySound()
    {
        if (audioSearch)
        {
            audioSearch.Play();
        }
    }

    void Update()
    {
        
    }
     
    public void ChanceScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }
}
