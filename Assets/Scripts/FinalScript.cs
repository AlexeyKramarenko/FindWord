using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//скрипт висит на BtnAgain & BtnExit
public class FinalScript : MonoBehaviour, IPointerClickHandler
{

    string text;
    void Start()
    {
        text = GetComponentInChildren<Text>().text;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (text == "Сыграть снова")
        {
            Application.LoadLevel(0);
        }
        else if (text == "Выйти из игры")
        {
            Application.Quit();
        }
       
    }
}
