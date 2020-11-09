using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ClickableLetters : MonoBehaviour, IPointerClickHandler
{
     public void OnPointerClick(PointerEventData eventData )
    {
        if(randomLetter == GameController.Instance.Letter)
        {
            GetComponent<TMP_Text>().color = Color.green;
            enabled = false;
            GameController.Instance.HandleCorrectLetterClick();
            
        }
        
    }

    private void Update()
    {
         
    }
    


    char randomLetter;

    internal void SetLetters(char letter)
    {
        enabled = true;
        GetComponent<TMP_Text>().color = Color.white;
        randomLetter = letter;
        if(Random.Range(0,100) > 50)
        GetComponent<TMP_Text>().text = randomLetter.ToString();

        else
        GetComponent<TMP_Text>().text = randomLetter.ToString().ToUpper();

    }
}
