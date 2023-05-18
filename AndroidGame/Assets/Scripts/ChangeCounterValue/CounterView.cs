using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textInCounter;

    public void ChangeCounterValue(int value)
    {
        _textInCounter.text = value.ToString();
    }

}
