using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ParentNoteManager : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] Text TouchTheHiddenText;
    [SerializeField] Image Circle;
    [SerializeField] GameObject NoteToParrent;

    bool isPressed;

    float PressTime;
    float TotalPressTime=2f;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
    private void Update()
    {
        if (isPressed) 
        {
            
            TouchTheHiddenText.gameObject.SetActive(true);

            PressTime += Time.deltaTime;

            if (PressTime >= TotalPressTime )
            {
                isPressed=false;
                TouchTheHiddenText.gameObject.SetActive(false);
                NoteToParrent.gameObject.SetActive(true);
            }
            Circle.fillAmount = PressTime/TotalPressTime;
        }
        if(!isPressed) 
        {
            PressTime -= Time.deltaTime;
            if(PressTime <= 0)
            {
                PressTime = 0;
            }

            TouchTheHiddenText.gameObject.SetActive(false);
            Circle.fillAmount = PressTime / TotalPressTime;
        }
    }
    public void ExitNote()
    {
        PressTime=0;
        isPressed = false;
        NoteToParrent.SetActive(false);
    }
}
