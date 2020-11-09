 using UnityEngine;
using System;
using System.Linq; 
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField] List<AudioClip> _audioClips;

    private  int _correctClicks;
    public  char Letter = 'a';
    public  int _correctAnswers = 5;
    public static GameController Instance { get; private set; }

    AudioSource _audioSource;

    private void OnEnable() 
    {
        GenerateBoard();
        UpdateLetters();
    }

    void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();

    }
    void GenerateBoard()
    {
        var clickables = FindObjectsOfType<ClickableLetters>();
        int count = clickables.Length;

        List<char> charsList = new List<char>();


        for (int i = 0; i < _correctAnswers; i++)
            charsList.Add(Letter);
            
            for (int i = _correctAnswers; i < count; i++)
            {
            var ChosenLetter = ChooseInvalidRandomLetter();
            charsList.Add(ChosenLetter);

        }

        charsList = charsList.OrderBy(t => UnityEngine.Random.Range(0, 10000)).ToList();

        for (int i = 0; i < clickables.Length; i++)
        {
            clickables[i].SetLetters(charsList[i]);
        }

         FindObjectOfType<RemainingCounterText>().SetRemaining(_correctAnswers - _correctClicks);
    }

    internal  void HandleCorrectLetterClick()
    {
        var clip = _audioClips.FirstOrDefault(t => t.name == Letter.ToString());
        _audioSource.PlayOneShot(clip);
        _correctClicks++;
        FindObjectOfType<RemainingCounterText>().SetRemaining(_correctAnswers - _correctClicks);
        if(_correctClicks >= _correctAnswers )
        {
            Letter++;
            UpdateLetters();

            _correctClicks = 0;
            GenerateBoard();
        }

    }
    private  void UpdateLetters()
    {
          foreach(var displayLetters in FindObjectsOfType<DisplayLetters>())
            {
                displayLetters.SetLetter(Letter);
            }
    }

     private  char ChooseInvalidRandomLetter()
        {
            int a = UnityEngine.Random.Range(0, 26);
                var randomLetter = (char)('a' + a);
                while(randomLetter == Letter)
                {
                    a = UnityEngine.Random.Range(0, 26);
                    randomLetter = (char)('a' + a);
                }
                if(randomLetter == Letter)
                    return ChooseInvalidRandomLetter();

        return randomLetter;

    }

    
}
