using System;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private Text _textInCounter;
    private int _counterInt;

    private void Awake()
    {
        _textInCounter = GetComponent<Text>();
    }

    public void SetCounterValue(bool chickenOrNot)
    {
        _textInCounter.text = chickenOrNot ? (_counterInt += 1).ToString() : (_counterInt -= 1).ToString();
    }
}
