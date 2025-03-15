using UnityEngine;

public class DrawerCanvasBackMenu : MonoBehaviour
{
    private PlayerMover _playerMover;
    private TuchButton _directionButton;
    private CanvasGroup _canvasGroup;
    private BuoyantForce _buoyantForce;
    
    public void Initialized(PlayerMover player, TuchButton directionButton, CanvasGroup canvasGroup, BuoyantForce buoyantForce)
    {
        _playerMover = player;
        _directionButton = directionButton;
        _canvasGroup = canvasGroup;
        _buoyantForce = buoyantForce;
        _buoyantForce.InWater += Draw;
    }

    private void OnDisable() => _buoyantForce.InWater += Draw;

    private void Draw()
    {
        _canvasGroup.gameObject.SetActive(true);
        _directionButton.gameObject.SetActive(false);
        _playerMover.enabled = false;
    }
}
