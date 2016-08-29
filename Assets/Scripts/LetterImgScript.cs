using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;
using System.Collections;

//скрипт висит на префабе imgBtn
public class LetterImgScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler
{
    #region Variables

    Text score;
    static List<Letter> tempLetters = new List<Letter>();
    static string Word;
    static int previous;
    static Letter previousLetter;
    static Letter lastLetter;
    static Color BingoColor;
    static int scoreCount = 0;

    //связующая черточка между клетками
    public GameObject consistentLine;
    Quaternion verticalAngleOfConsistantLine = Quaternion.Euler(new Vector3(0, 0, 90));    
    Image img;

    //цвет выделения ячейки
    Color selectionColor = Color.green;
    static int availableInWORDSArray;
    SceneManager SM;

    #endregion Variables


    void Start()
    {
        availableInWORDSArray = LettersField.WORDS.Length;
        img = this.GetComponent<Image>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        score.text = string.Format("Счет: {0}", scoreCount);
        SM = GameObject.Find("Canvas").GetComponent<SceneManager>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        //если курсор поверх желтой клетки поля
        if (img.color == Color.yellow)
        {
            ClickOnUnselectedCell();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        BingoColor = ColorDatabase.colors[UnityEngine.Random.Range(0, 12)];

        if (Input.GetMouseButton(0))
        {
            MainActionForPointerEnter();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        FindInputLettersInRealWords();

        if (availableInWORDSArray < 1)//отгаданы все буквы
        {
            //поздравления и переход на новый уровень
            StartCoroutine(SM.Congratulation());
        }
    }
    

    #region Methods
    private void ClickOnUnselectedCell()
    {
        img.color = selectionColor;

        int index = this.name.IndexOf('x');
        string ROW = this.name.Remove(index);
        string COL = this.name.Remove(0, index).Replace("x", "");

        int row = -100;
        int col = -100;
        if ((int.TryParse(ROW, out row)) && (int.TryParse(COL, out col)))
        {
            //можно сделать клик только при условии что tempLetters пуст
            Letter letter = LettersField.LETTERS.Where(a => a.row == row && a.col == col).Single();
            if (tempLetters.Count == 0)
            {
                tempLetters.Add(letter);
                AddLetterToWord(letter.LetterValue);
            }
        }
    }
    private void MainActionForPointerEnter()
    {
        if (img.color == Color.yellow)
        {
            img.color = selectionColor;

            int index = this.name.IndexOf('x');
            string ROW = this.name.Remove(index);
            string COL = this.name.Remove(0, index).Replace("x", "");

            int row = -100;
            int col = -100;
            if ((int.TryParse(ROW, out row)) && (int.TryParse(COL, out col)))
            {                
                Letter letter = LettersField.LETTERS.Where(a => a.row == row && a.col == col).Single();
                tempLetters.Add(letter);
                AddLetterToWord(letter.LetterValue);

                if (tempLetters.Count > 1)
                {
                    ShowConsistentLine();
                }
            }
        }
    }  
    void AddConsistentLineToHierarchy(Vector3 localPosition, Quaternion angle)
    {
        GameObject line = (GameObject)Instantiate(consistentLine, transform.position + localPosition, angle);
        line.transform.SetParent(this.gameObject.transform.parent.transform);
    }
    void CalculateLettersOrder()
    {
        previous = tempLetters.Count - 2;
        previousLetter = tempLetters[previous];
        lastLetter = tempLetters[previous + 1];
    }

    //добавить черточку между клетками
    void ShowConsistentLine()
    {
        CalculateLettersOrder();

        //БУКВЫ С ОДНОГО РЯДА
        if (previousLetter.row == lastLetter.row)
        {
            //СЛЕВА НАПРАВО
            if ((previousLetter.col - lastLetter.col) == -1)
            {
                AddConsistentLineToHierarchy(new Vector3(-24, 0, 0), Quaternion.identity);
            }
            //СПРАВА НАЛЕВО
            else if ((previousLetter.col - lastLetter.col) == 1)
            {
                AddConsistentLineToHierarchy(new Vector3(24, 0, -10), Quaternion.identity);
            }
            //ПРОСКОК
            else if (Mathf.Abs(previousLetter.col - lastLetter.col) != 1)
            {
                ForbiddenTransition();
            }
        }

        //БУКВЫ С ОДНОЙ КОЛОНКИ
        if (previousLetter.col == lastLetter.col)
        {
            //СВЕРХУ ВНИЗ
            if ((previousLetter.row - lastLetter.row) == -1)
            {
                AddConsistentLineToHierarchy(new Vector3(0, 24, -70), verticalAngleOfConsistantLine);
            }
            //СНИЗУ ВВЕРХ
            else if ((previousLetter.row - lastLetter.row) == 1)
            {
                AddConsistentLineToHierarchy(new Vector3(0, -24, -70), verticalAngleOfConsistantLine);
            }
            //ПРОСКОК
            else if (Mathf.Abs(previousLetter.row - lastLetter.row) != 1)
            {
                ForbiddenTransition();
            }
        }
        //ЗАПРЕТ НА ПЕРЕХОД ПО ДИАГОНАЛИ        
        else if (previousLetter.row != lastLetter.row && previousLetter.col != lastLetter.col)
        {
            ForbiddenTransition();
        }
    }
    //при попадании курсора в клетку, которая не есть следующая идет удаление всех предыдущих
    void ResetAllToYellow()
    {
        Letter lastLetter = tempLetters.Last();

        foreach (Letter l in tempLetters)
        {
            string name = l.row + "x" + l.col;

            if (name != lastLetter.row + "x" + lastLetter.col)
                GameObject.Find(name).GetComponent<Image>().color = Color.yellow;
        }
    }
    void DeleteAllConsistantLines()
    {
        //пробегаемся по всем дочерним обьектам
        foreach (Transform tr in GameObject.Find("LettersField").transform)
        {
            if (tr.gameObject.name == "line(Clone)")
            {
                Destroy(tr.gameObject);
            }
        }
    }
    void AllRedToYellow()
    {
        foreach (Letter l in tempLetters)
        {
            if (GameObject.Find(l.row + "x" + l.col).GetComponent<Image>().color == selectionColor)
                GameObject.Find(l.row + "x" + l.col).GetComponent<Image>().color = Color.yellow;
        }
    }
    void FindInputLettersInRealWords()
    {
        string bingo = null;
        bingo = (from a in LettersField.WORDS
                 where a == Word//Word - это куча набранных букв юзером
                 select a).FirstOrDefault();

        if (bingo != null)
        {
            IncreaseScore(bingo);
            foreach (char _char in bingo)//bingo - это слово вытащенное из БД совпавшее с тем, что набрал юзер
            {
                Letter _letter = (from a in tempLetters//tempLetters - тут находятся все набранные символы юзером, до совпадения со словом из db.WORDS
                                  where a.LetterValue == _char //&&
                                  select a).First();

                //нам нужно очищать tempLetters от уже готовых решений
                Letter letterToDelete = (from a in tempLetters
                                         where a.row == _letter.row && a.col == _letter.col
                                         select a).Single();

                tempLetters.Remove(letterToDelete);

                //меняем цвет на ФИНАЛЬНЫЙ, если слово совпадает
                GameObject.Find(_letter.row.ToString() + "x" + _letter.col.ToString()).GetComponent<Image>().color = BingoColor;
            }
            ResetWordToEmpty();
            DeleteAllConsistantLines();
            ClearTempLetters();
            availableInWORDSArray = Delete_Element_From_WORDS_Array(bingo);
        }
        else//если юзер вместо слова ПАКЕТ набрал больше, например ПАКЕТО
        {
            AllRedToYellow();
            ResetWordToEmpty();
            ClearTempLetters();
            DeleteAllConsistantLines();
        }
    }
    void IncreaseScore(string bingo)
    {
        scoreCount += bingo.Length;
        score.text = string.Format("Счет: {0}", scoreCount);
    }
    int Delete_Element_From_WORDS_Array(string word)
    {
        int idx = Array.IndexOf(LettersField.WORDS, word);
        List<string> tmp = new List<string>(LettersField.WORDS);
        tmp.RemoveAt(idx);
        LettersField.WORDS = tmp.ToArray();
        return LettersField.WORDS.Length;
    }
    void ForbiddenTransition()//ПРОСКОК ИЛИ ПЕРЕХОД ПО ДИАГОНАЛИ
    {
        ResetAllToYellow();
        DeleteAllConsistantLines();
        DeleteAllLettersFromWordWithoutLast();
        ResetTempLettersWithoutLast();
        GameObject.Find(this.name).GetComponent<Image>().color = selectionColor;
    }
    void ResetTempLettersWithoutLast()
    {
        var last = tempLetters.Last();
        tempLetters.Clear();
        tempLetters.Add(last);
    }
    void ClearTempLetters()
    {
        tempLetters.Clear();
    }
    void ResetWordToEmpty()
    {
        Word = "";
    }
    void AddLetterToWord(char value)
    {
        Word += value;
    }
    void DeleteAllLettersFromWordWithoutLast()
    {
        //Удаление всей коллекции кроме последнего элемента в ней
        Word = Word.Last().ToString();
    }

    #endregion Methods
}
