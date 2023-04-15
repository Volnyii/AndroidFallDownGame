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

    private string SetText(bool chickenOrNot)
    {
        _counterInt = chickenOrNot ? _counterInt += 1 : _counterInt -= 1;
        if (_counterInt <= 0) 
            _counterInt = 0;
        return _counterInt.ToString();
    }

    public void SetCounterValue(bool chickenOrNot)
    {
        _textInCounter.text = SetText(chickenOrNot);
    }
}
