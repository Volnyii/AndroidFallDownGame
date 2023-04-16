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

    public void SetCounterValue(ObjectType objectType)
    {
        if (objectType == ObjectType.Chicken)
        {
            _counterInt += 1;
        }
        else if (objectType == ObjectType.Cloud)
        {
            _counterInt -= 1;
        }

        if (_counterInt <= 0) 
            _counterInt = 0;
        
        _textInCounter.text = _counterInt.ToString();
    }
}
