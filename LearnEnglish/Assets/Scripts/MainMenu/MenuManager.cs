using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject LogoImg;
    void Start()
    {
        OpenLogo();
    }

    void OpenLogo()
    {                                         //Parlakligini
        LogoImg.GetComponent<CanvasGroup>().DOFade(1,1f);
                                              //Boyutunu 
        LogoImg.GetComponent<RectTransform>().DOScale(0.9f,1);
    }

    //Change scene
    public void EnterScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
