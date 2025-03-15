using UnityEngine;

public class LauncherMenu : MonoBehaviour
{
    private PlayerMover _playerMover;
    private TuchButton _startButton;
    private TuchButton _directionButton;
    private CanvasGroup _canvasGroup;

    public void Initialized(PlayerMover player, TuchButton startButton, CanvasGroup canvasGroup, TuchButton directionButton)
    {
        _playerMover = player;
        _startButton = startButton;
        _directionButton = directionButton;
        _canvasGroup = canvasGroup;
        _startButton.ButtonPressed += StartPlay;
    }
    
    private void OnDisable() => _startButton.ButtonPressed -= StartPlay;

    private void StartPlay()
    {
        _canvasGroup.gameObject.SetActive(false);
        _directionButton.gameObject.SetActive(true);
        _playerMover.enabled = true;
    }
}
