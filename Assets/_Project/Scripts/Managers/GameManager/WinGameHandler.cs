using UnityEngine;
using UnityEngine.UI;

public sealed class WinGameHandler : MonoBehaviour
{
    [Header("Panels UI")]
    [SerializeField] private GameObject _winPanelObject;
    [SerializeField] private GameObject _endGamePanelObject;

    [Header("Buttons UI")]
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _mainMenuButton;

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;

    [Header("Game State Scriptable Object")]
    [SerializeField] private GameStateScriptableObject _gameStateScriptableObject;

    private SceneHandler _sceneHandler = new SceneHandler();

    private bool canSaveGame = true;

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void SubscribeEvents()
    {
        _globalGameEvents.OnLevelCompleted += OnLevelCompleted_LevelComplete;

        _continueButton.onClick.AddListener(_sceneHandler.LoadNextScene);
        _mainMenuButton.onClick.AddListener(_sceneHandler.BackToMainMenu);
    }

    private void UnsubscribeEvents()
    {
        _globalGameEvents.OnLevelCompleted -= OnLevelCompleted_LevelComplete;

        _continueButton.onClick.RemoveAllListeners();
        _mainMenuButton.onClick.RemoveAllListeners();
    }

    private void OnLevelCompleted_LevelComplete()
    {
        StopGame();

        SetGameState(GameState.WIN);

        if(_sceneHandler.NextSceneExists())
        {
            HandleGameSaving();

            _winPanelObject.SetActive(true);
        }
        else
        {
            _endGamePanelObject.SetActive(true);
        }
    }

    private void StopGame()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
    }

    private void SetGameState(GameState newGameState)
    {
        _gameStateScriptableObject._currentGameState = newGameState;

        _globalGameEvents.OnGameStateChanged?.Invoke(newGameState);
    }

    private void HandleGameSaving()
    {
        if(canSaveGame)
        {
            SaveSystem.GetLocalData().currentLevelIndex++;
            
            SaveSystem.SaveGameData();

            canSaveGame = false;
        }
    }
}