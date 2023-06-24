using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

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
    [SerializeField] private CinemachineVirtualCamera _cutscene1_VC;
    [SerializeField] private CinemachineVirtualCamera _cutscene2_VC;
    [SerializeField] private GameObject[] _gameActiveObjects;

    private TimeLine _timeLine;
    private MainCamera _mainCamera;
    private PlayerVerticalSpeed _verticalSpeed;

    private void Start()
    {
        _mainCamera = FindObjectOfType<MainCamera>();
        _timeLine = FindObjectOfType<TimeLine>();
        _verticalSpeed = FindObjectOfType<PlayerVerticalSpeed>();
        _timeLine.OnGameWasEnd += StartCutscene_2;
        _startCutscene.played += OnCutscene1_Ended;
        _endCutscene.played += OnCutscene2_Ended;
        
        StartCutscene_1();
    }

    private void OnCutscene2_Ended(PlayableDirector obj)
    {
        // show finish UI after game end 
    }

    private void OnCutscene1_Ended(PlayableDirector obj)
    {
        StartGameAfter_Cutscene1();
    }

    private void StartCutscene_1()
    {
        _startCutscene.Play();
        _cutscene1_VC.Priority = 1000;
        SetGameEnvironment(false);
        _mainCamera.enabled = false;
        _verticalSpeed.enabled = false;
        _gameState = GameState.CutScene1;
    }

    private void SetGameEnvironment(bool state)
    {
        foreach (var obj in _gameActiveObjects)
        {
            obj.SetActive(state);
        }
    }

    private void StartGameAfter_Cutscene1()
    {
        _cutscene1_VC.Priority = 0;
        SetGameEnvironment(true);
        _mainCamera.enabled = true;
        _verticalSpeed.enabled = true;
        _gameState = GameState.Game;
    }
    
    private void StartCutscene_2()
    {
        _endCutscene.Play();
        _cutscene2_VC.Priority = 1000;
        SetGameEnvironment(false);
        _mainCamera.enabled = false;
        _verticalSpeed.enabled = false;
        _gameState = GameState.CutScene2;
    }
}
