using UnityEngine;
using UnityEngine.UI;

//скрипт висит на Panel обьекте в канвасе под назва Inventory
public class LettersField : MonoBehaviour
{
    #region Variables
    
    public GameObject slots;
    float x = 0f;
    float y = 0f;

    public static Letter[] LETTERS = null;
    public static string[] WORDS = null;
    #endregion Variables

    void Start()
    {
        ChooseDatabaseBySceneName();
        GenerateLettersField();
    }

    #region Methods
    private void ChooseDatabaseBySceneName()
    {
        //WordsDatabase db = GameObject.Find("ItemDatabase").GetComponent<WordsDatabase>();

        string sceneName = Application.loadedLevelName;

        if (sceneName == "First")
        {
            LETTERS = WordsDatabase.LETTERS_First;
            WORDS = WordsDatabase.WORDS_First;
        }
        else if (sceneName == "Second")
        {
            LETTERS = WordsDatabase.LETTERS_Second;
            WORDS = WordsDatabase.WORDS_Second;
        }
        else if (sceneName == "Third")
        {
            LETTERS = WordsDatabase.LETTERS_Third;
            WORDS = WordsDatabase.WORDS_Third;
        }
    }    
    private void GenerateLettersField()
    {
        int last = LETTERS.Length - 1;
        int rows = LETTERS[last].row + 1;
        int cols = LETTERS[last].col + 1;

        int index = 0;


        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                GameObject slot = (GameObject)Instantiate(slots);
                slot.transform.SetParent(this.gameObject.transform);
                slot.GetComponent<Transform>().localPosition = new Vector3(x, y, 0);
                slot.GetComponent<Image>().color = Color.yellow;
                slot.gameObject.GetComponentInChildren(typeof(Text)).GetComponent<Text>().text = LETTERS[index].LetterValue.ToString();
                slot.name = r + "x" + c;
                x = x + 47f;
                if (c == cols - 1)
                {
                    x = 0;
                    y = y - 47f;
                }

                index += 1;
            }
        }
    }

    #endregion Methods

}
