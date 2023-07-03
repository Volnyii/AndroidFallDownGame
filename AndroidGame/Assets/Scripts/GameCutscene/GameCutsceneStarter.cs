using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Serialization;

public enum GameState : byte
{
    None = 0,
    CutScene1 = 1,
    Game = 2,
    CutScene2 = 3
}
public class GameCutsceneStarter : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    
    [SerializeField] private PlayableDirector _startCutscene;
    [SerializeField] private PlayableDirector _endCutscene;
    [SerializeField] private GameObject[] _cutscene1GameObjects;
    [SerializeField] private GameObject[] _cutscene2GameObjects;
    [SerializeField] private GameObject[] _playmodeGameObjects;

    private TimeLine _timeLine;
    private bool _gameStarted;

    private void Start()
    {
        _timeLine = FindObjectOfType<TimeLine>(true);
        EnabledOrDisabledObjects(_cutscene1GameObjects,true);
        EnabledOrDisabledObjects(_playmodeGameObjects,false);
        _timeLine.OnGameWasEnd += StartCutscene_2;
        StartCutscene_1();
    }

    private void OnCutscene2_Ended()
    {
        // show finish UI after game end 
    }

    private void OnCutscene1_Ended()
    {
        EnabledOrDisabledObjects(_cutscene1GameObjects,false);
        EnabledOrDisabledObjects(_playmodeGameObjects,true);
        StartGameAfter_Cutscene1();
        _gameStarted = true;
    }

    private void EnabledOrDisabledObjects(GameObject[] container, bool whatDoYouWant)
    {
        foreach (var gameObj in container)
        {
            gameObj.SetActive(whatDoYouWant);
        }
    }

    private void StartCutscene_1()
    {
        _startCutscene.Play();
        _gameState = GameState.CutScene1;
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (_startCutscene.state == PlayState.Playing)
            {
                _startCutscene.Stop();
                EnabledOrDisabledObjects(_cutscene1GameObjects,false);
                EnabledOrDisabledObjects(_playmodeGameObjects,true);
            }
        }
        if (_startCutscene.state != PlayState.Playing && !_gameStarted)
        {
            OnCutscene1_Ended();
        }
    }

    private void StartGameAfter_Cutscene1()
    {
        EnabledOrDisabledObjects(_cutscene1GameObjects,false);
        EnabledOrDisabledObjects(_playmodeGameObjects,true);
        _gameState = GameState.Game;
    }
    
    private void StartCutscene_2()
    {
        EnabledOrDisabledObjects(_cutscene2GameObjects,true);
        EnabledOrDisabledObjects(_playmodeGameObjects,false);
        _endCutscene.Play();
        _gameState = GameState.CutScene2;
    }
}
