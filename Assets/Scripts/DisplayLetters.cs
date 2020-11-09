using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  

public class DisplayLetters : MonoBehaviour
{
    [SerializeField] bool _upperCase;
    internal void SetLetter(char letter)
    {
        if(_upperCase)
        GetComponent<TMP_Text>().text = letter.ToString().ToUpper();
        else
        GetComponent<TMP_Text>().text = letter.ToString().ToLower();
    }
  
}
