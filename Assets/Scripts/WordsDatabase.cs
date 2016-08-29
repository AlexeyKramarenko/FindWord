using System;
 

public static class WordsDatabase  
{
    public static Letter[] LETTERS_First = new Letter[]
    {
        new Letter{row = 0, col = 0, LetterValue ='с'},
        new Letter{row = 0, col = 1, LetterValue ='т' },
        new Letter{row = 0, col = 2, LetterValue ='е' },
        new Letter{row = 0, col = 3, LetterValue ='н' },
         
        new Letter{row = 1, col = 0, LetterValue ='с'},
        new Letter{row = 1, col = 1, LetterValue ='у' },
        new Letter{row = 1, col = 2, LetterValue ='р' },
        new Letter{row = 1, col = 3, LetterValue ='а' },
         
        new Letter{row = 2, col = 0, LetterValue ='ц'},
        new Letter{row = 2, col = 1, LetterValue ='е' },
        new Letter{ row = 2, col = 2, LetterValue ='а' },
        new Letter{ row = 2, col = 3, LetterValue ='я' },
         
        new Letter{row = 3, col = 0, LetterValue ='ь'},
        new Letter{row = 3, col = 1, LetterValue ='л' },
        new Letter{ row = 3, col = 2, LetterValue ='п' },
        new Letter{ row = 3, col = 3, LetterValue ='р' }, 
        };
    public static string[] WORDS_First = new string[]
        {
            "стена","цель","парус","яр"
        };


    public static Letter[] LETTERS_Second = new Letter[]
    {
        new Letter{row = 0, col = 0, LetterValue ='о'},
        new Letter{row = 0, col = 1, LetterValue ='л' },
        new Letter{row = 0, col = 2, LetterValue ='е' },
        new Letter{row = 0, col = 3, LetterValue ='н' },
        new Letter{row = 0, col = 4, LetterValue ='и'},
        new Letter{row = 0, col = 5, LetterValue ='т' },        

        new Letter{row = 1, col = 0, LetterValue ='п'},
        new Letter{row = 1, col = 1, LetterValue ='в' },
        new Letter{row = 1, col = 2, LetterValue ='р' },
        new Letter{row = 1, col = 3, LetterValue ='в' },
        new Letter{row = 1, col = 4, LetterValue ='о'},
        new Letter{row = 1, col = 5, LetterValue ='о' },
       
        new Letter{row = 2, col = 0, LetterValue ='и'},
        new Letter{row = 2, col = 1, LetterValue ='г' },
        new Letter{ row = 2, col = 2, LetterValue ='а' },
        new Letter{ row = 2, col = 3, LetterValue ='м' },
        new Letter{row = 2, col = 4, LetterValue ='о'},
        new Letter{row = 2, col = 5, LetterValue ='л' },
       
        new Letter{row = 3, col = 0, LetterValue ='а'},
        new Letter{row = 3, col = 1, LetterValue ='л' },
        new Letter{ row = 3, col = 2, LetterValue ='ч' },
        new Letter{ row = 3, col = 3, LetterValue ='к' },
        new Letter{row = 3, col = 4, LetterValue ='о'},
        new Letter{row = 3, col = 5, LetterValue ='с' },
       
        new Letter{row = 4, col = 0, LetterValue ='а'},
        new Letter{row = 4, col = 1, LetterValue ='р' },
        new Letter{ row = 4, col = 2, LetterValue ='г' },
        new Letter{ row = 4, col = 3, LetterValue ='и' },
        new Letter{row = 4, col = 4, LetterValue ='т'},
        new Letter{row = 4, col = 5, LetterValue ='т' },
        
        new Letter{row = 5, col = 0, LetterValue ='п'},
        new Letter{row = 5, col = 1, LetterValue ='е' },
        new Letter{row = 5, col = 2, LetterValue ='д' },
        new Letter{row = 5, col = 3, LetterValue ='а' },
        new Letter{row = 5, col = 4, LetterValue ='н'},
        new Letter{row = 5, col = 5, LetterValue ='ь' },       
    };
    public static string[] WORDS_Second = new string[]
        {
            "кость","воин","врач","молот","поле","игла","игра","педант"
        };


    public static Letter[] LETTERS_Third = new Letter[]
    {
        new Letter{row = 0, col = 0, LetterValue ='с'},
        new Letter{row = 0, col = 1, LetterValue ='т' },
        new Letter{row = 0, col = 2, LetterValue ='м' },
        new Letter{row = 0, col = 3, LetterValue ='о' },
        new Letter{row = 0, col = 4, LetterValue ='п'},
        new Letter{row = 0, col = 5, LetterValue ='и' },
        new Letter{row = 0, col = 6, LetterValue ='р' },
        new Letter{row = 0, col = 7, LetterValue ='к' },

        new Letter{row = 1, col = 0, LetterValue ='б'},
        new Letter{row = 1, col = 1, LetterValue ='а' },
        new Letter{row = 1, col = 2, LetterValue ='е' },
        new Letter{row = 1, col = 3, LetterValue ='н' },
        new Letter{row = 1, col = 4, LetterValue ='с'},
        new Letter{row = 1, col = 5, LetterValue ='о' },
        new Letter{ row = 1, col = 6, LetterValue ='к' },
        new Letter{ row = 1, col = 7, LetterValue ='р' },

        new Letter{row = 2, col = 0, LetterValue ='у'},
        new Letter{row = 2, col = 1, LetterValue ='л' },
        new Letter{ row = 2, col = 2, LetterValue ='т' },
        new Letter{ row = 2, col = 3, LetterValue ='а' },
        new Letter{row = 2, col = 4, LetterValue ='т'},
        new Letter{row = 2, col = 5, LetterValue ='к' },
        new Letter{ row = 2, col = 6, LetterValue ='и' },
        new Letter{ row = 2, col = 7, LetterValue ='а' },

        new Letter{row = 3, col = 0, LetterValue ='р'},
        new Letter{row = 3, col = 1, LetterValue ='ь' },
        new Letter{ row = 3, col = 2, LetterValue ='п' },
        new Letter{ row = 3, col = 3, LetterValue ='е' },
        new Letter{row = 3, col = 4, LetterValue ='н'},
        new Letter{row = 3, col = 5, LetterValue ='а' },
        new Letter{ row = 3, col = 6, LetterValue ='р' },
        new Letter{ row = 3, col = 7, LetterValue ='с' },

        new Letter{row = 4, col = 0, LetterValue ='я'},
        new Letter{row = 4, col = 1, LetterValue ='ч' },
        new Letter{ row = 4, col = 2, LetterValue ='е' },
        new Letter{ row = 4, col = 3, LetterValue ='р' },
        new Letter{row = 4, col = 4, LetterValue ='е'},
        new Letter{row = 4, col = 5, LetterValue ='р' },
        new Letter{ row = 4, col = 6, LetterValue ='б' },
        new Letter{ row = 4, col = 7, LetterValue ='к' },

        new Letter{row = 5, col = 0, LetterValue ='ь'},
        new Letter{row = 5, col = 1, LetterValue ='ж' },
        new Letter{row = 5, col = 2, LetterValue ='о' },
        new Letter{row = 5, col = 3, LetterValue ='л' },
        new Letter{row = 5, col = 4, LetterValue ='д'},
        new Letter{row = 5, col = 5, LetterValue ='т' },
        new Letter{row = 5, col = 6, LetterValue ='а' },
        new Letter{row = 5, col = 7, LetterValue ='а' },

        new Letter{row = 6, col = 0, LetterValue ='п'},
        new Letter{row = 6, col = 1, LetterValue ='р' },
        new Letter{row = 6, col = 2, LetterValue ='е' },
        new Letter{row = 6, col = 3, LetterValue ='з' },
        new Letter{row = 6, col = 4, LetterValue ='и'},
        new Letter{row = 6, col = 5, LetterValue ='а' },
        new Letter{row = 6, col = 6, LetterValue ='к' },
        new Letter{row = 6, col = 7, LetterValue ='ц' },

        new Letter{row = 7, col = 0, LetterValue ='я'},
        new Letter{row = 7, col = 1, LetterValue ='б' },
        new Letter{row = 7, col = 2, LetterValue ='л' },
        new Letter{row = 7, col = 3, LetterValue ='о' },
        new Letter{row = 7, col = 4, LetterValue ='к'},
        new Letter{row = 7, col = 5, LetterValue ='о' },
        new Letter{row = 7, col = 6, LetterValue ='р' },
        new Letter{row = 7, col = 7, LetterValue ='и' },
    };

    public static string[] WORDS_Third = new string[]
        {
            "сталь","буря","ложь","цирк","абрикос","краска","пир","яблоко","карта","президент","череп", "монета"
        };


}