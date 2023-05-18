using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private CounterView _counterView;
    [Inject] private GameController _gameController;

    private CounterPresenter _counterPresenter;
    
    private void Awake()
    {
        _counterPresenter = new CounterPresenter(_counterView, _gameController);
    }
}
