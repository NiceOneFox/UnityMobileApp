using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class InitializeAllWords : MonoBehaviour
{
    private string filePath;
    private int maxDictionarySize = 200;
    public int totalSize = 7968;
    
    public List<string> questions = new List<string>();
    public List<string> answers = new List<string>();
    public Dictionary<string, string> wordsWithTranslationsDictionary = new Dictionary<string, string>();
   
    private void Start()
    {
        filePath = Application.persistentDataPath + "/Words.txt";
        Debug.Log(Application.persistentDataPath);
        Debug.Log(Application.dataPath);
        Initialize();
    }
    
    public void Initialize()
    {
        wordsWithTranslationsDictionary.Clear();
        questions.Clear();
        answers.Clear();

        CompileDictionary(maxDictionarySize);
    }

    public void Initialize(int size)
    {
        CompileDictionary(size);
    }


    public void CompileDictionary(int size)
    {
        StringBuilder word = new StringBuilder();
        StringBuilder answer = new StringBuilder();
        
        //ArrayList arrayList = new ArrayList(8000);
        string[] arrayList = new string[totalSize];
        
        int iter = 0;
        byte dictionarySize = 0;
        
        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                arrayList[iter] = reader.ReadLine();
                iter++;
            }
        }
        
        System.Random rnd = new System.Random();


        for (int j = 0; j < size; j++)
        {
            int random = rnd.Next(1, totalSize);
            string currentLine = arrayList[random];
                    
            bool isSeparator = false;
            for (int i = 0; i < currentLine.Length; i++)
            {
                if (currentLine[i].Equals('*'))
                {
                    isSeparator = true;
                    continue;
                }
                        
                if (!isSeparator)
                {
                    word.Append(currentLine[i]);
                }
                else
                {
                    answer.Append(currentLine[i]);
                }
                if (currentLine[i].Equals(' ') || (i + 1 == currentLine.Length))
                {
                    if (wordsWithTranslationsDictionary.ContainsKey(word.ToString()))
                    {
                        j--;
                        continue;
                    }

                    questions.Add(word.ToString());
                    answers.Add(answer.ToString());
                    wordsWithTranslationsDictionary.Add(word.ToString(), answer.ToString());
                    dictionarySize++;
                    word.Clear();
                    answer.Clear();
                }
            }
        }
        
    }
}
