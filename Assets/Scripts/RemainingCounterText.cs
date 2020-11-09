using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemainingCounterText : MonoBehaviour
{
    internal void SetRemaining(int remaining)
    {
        GetComponent<TMP_Text>().text = "x" + remaining;
    }
}
