using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiscoverManager : MonoBehaviour
{
    [SerializeField] 
    GameObject wordPrefab;

    [SerializeField]
    Transform wordsHolder; 

    [SerializeField]
    AudioClip[] wordsSounds;

    string[] words = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

    int wordsNo;

    private void Start()
    {
        SetWords();
        StartCoroutine(ShowWords());
    }

    void SetWords()
    {
        for (int i = 0; i < words.Length; i++)
        {
            GameObject wordObject = Instantiate(wordPrefab, wordPrefab.transform.position, Quaternion.identity);

            wordObject.transform.GetChild(0).GetComponent<Text>().text = words[i];
            wordObject.transform.SetParent(wordsHolder);

            wordsHolder.localPosition = new Vector3(2630, 0,0);
        }
    }

    public void TurnBack()
    {
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator ShowWords()
    {
        while (wordsNo < words.Length)
        {
            wordsHolder.GetChild(wordsNo).GetComponent<CanvasGroup>().DOFade(1, .5f);
            wordsHolder.GetChild(wordsNo).GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);

            wordsHolder.GetChild(wordsNo).GetComponent<AudioSource>().clip = wordsSounds[wordsNo];

            yield return new WaitForSeconds(.2f);
            wordsNo++;  
        } 
    }
}
