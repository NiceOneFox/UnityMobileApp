using System.Collections.Generic;
using UnityEngine;

public class InitializeAllWords : MonoBehaviour
{
    private string fileText;
    public List<string> questions = new List<string>();
    public List<string> answers = new List<string>();
    public Dictionary<string, string> wordsWithTranslationsDictionary = new Dictionary<string, string>();

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("AllWords");
        fileText = textAsset.text;
        wordsWithTranslationsDictionary = CompileDictionary(fileText);
    }

    public Dictionary<string, string> CompileDictionary(string text)
    {
        Dictionary<string, string> wordsWithTranslations = new Dictionary<string, string>();
        string word = string.Empty;
        string answer = string.Empty;

        bool isWord = true;

        for (int i = 0; i < fileText.Length; i++)
        {
            if (fileText[i] != '*' & fileText[i] != ' ')
            {
                if (isWord)
                {
                    word += fileText[i];
                }
                else
                {
                    answer += fileText[i];
                }
            }
            else if (fileText[i] == '*')
            {
                isWord = false;
            }
            else if (fileText[i] == ' ')
            {
                questions.Add(word);
                answers.Add(answer);
                wordsWithTranslations.Add(word, answer);
                word = string.Empty;
                answer = string.Empty;
                isWord = true;
            }
        }
        return wordsWithTranslations;
    }
}
