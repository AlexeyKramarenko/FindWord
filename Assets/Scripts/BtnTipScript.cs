using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

//Висит на Button
public class BtnTipScript : MonoBehaviour, IPointerClickHandler
{
    Animator animator;
    static int ArrayLength;
    string buttonText;

    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Tip").GetComponent<Animator>();
    }

    void Update()
    {
        //Button
        GetComponentInChildren<Text>().text = string.Format("Подсказка ({0})", LettersField.WORDS.Length);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (LettersField.WORDS.Length > 0)
        {
            StartCoroutine(TipPlay());
        }
    }
    
    //coroutine
    IEnumerator TipPlay()
    {
        //текст подсказки
        GameObject.FindGameObjectWithTag("Tip").GetComponentInChildren<Text>().text = LettersField.WORDS[LettersField.WORDS.Length - 1];
        animator.SetBool("PlayTip", true);
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("PlayTip", false);
        yield return new WaitForSeconds(1f);
    }
}
