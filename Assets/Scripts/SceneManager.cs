using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//висит на Canvas'e
public class SceneManager : MonoBehaviour
{
    #region Variables

    Text congratulation;
    Animator anim;
    static string NextLevelName;

    #endregion Variables

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Congratulation").GetComponent<Animator>();
        congratulation = GameObject.FindGameObjectWithTag("Congratulation").GetComponentInChildren<Text>();
        SetLevelsOrder();
    }

    #region Methods

    void SetLevelsOrder()
    {
        GameObject.FindGameObjectWithTag("Level").GetComponent<Text>().text = string.Format("Уровень: {0}", Application.loadedLevel + 1);
        if (Application.loadedLevelName == "First")
            NextLevelName = "Second";
        else if (Application.loadedLevelName == "Second")
            NextLevelName = "Third";
        else if (Application.loadedLevelName == "Third")
            NextLevelName = "Final";
    }
    public IEnumerator Congratulation()
    {
        congratulation.text = string.Format(@"Поздравляем!
                                             Вы прошли {0} уровень!", Application.loadedLevel + 1);
        anim.SetBool("ConratulationsPlay", true);
        yield return new WaitForSeconds(3.0f);
        anim.SetBool("ConratulationsPlay", false);
        Application.LoadLevel(NextLevelName);
    }

    #endregion Methods
}
