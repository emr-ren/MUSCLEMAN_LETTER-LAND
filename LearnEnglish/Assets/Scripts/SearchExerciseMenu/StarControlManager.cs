using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StarControlManager : MonoBehaviour
{
    [SerializeField]
    GameObject star1,star2,star3;

    [SerializeField]
    GameObject bright1, bright2, bright3;
 
    public void BrightTheStar(int value)
    {
        if (value < 12) 
        {
            bright1.GetComponent<RectTransform>().DOScale(1, .2f).SetEase(Ease.OutBack);
            star1.GetComponent<Image>().fillAmount = value / 12f;
        }
        else if (value >=12 && value<24) 
        {
            bright2.GetComponent<RectTransform>().DOScale(1, .2f).SetEase(Ease.OutBack);
            star2.GetComponent<Image>().fillAmount = (value-12) / 12f;
        }
        else if ( value >=24 && value < 36)
        {
            bright3.GetComponent<RectTransform>().DOScale(1, .2f).SetEase(Ease.OutBack);
            star3.GetComponent<Image>().fillAmount= (value - 24) / 12f;
        }
        Invoke("DeleteBright", 0.5f);
    }
    void DeleteBright()
    {
        bright1.GetComponent<RectTransform>().DOScale(0, .2f);
        bright2.GetComponent<RectTransform>().DOScale(0, .2f);
        bright3.GetComponent<RectTransform>().DOScale(0, .2f);
    }
}
