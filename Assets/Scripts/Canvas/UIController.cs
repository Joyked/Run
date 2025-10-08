using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private CanvasGroup _startCanvas;
    [SerializeField] private CanvasGroup _scoreCanvas;
    [SerializeField] private CanvasGroup _returnCanvas;
    [Space] 
    [SerializeField] private InputSwipeHandler _startHandler;
    [SerializeField] private BuoyantForce _buoyantForce;

    private void OnEnable()
    {
        _buoyantForce.InWater += ReturnCanvasEnable;
        _startHandler.OnGameStart += ScoreCanvalEnable;
    }

    private void OnDisable()
    {
        _buoyantForce.InWater -= ReturnCanvasEnable;
        _startHandler.OnGameStart -= ScoreCanvalEnable;
    }

    private void ScoreCanvalEnable()
    {
        _startCanvas.gameObject.SetActive(false);
        _scoreCanvas.gameObject.SetActive(true);
    }
    
    private void ReturnCanvasEnable()
    {
        _scoreCanvas.gameObject.SetActive(false);
        _returnCanvas.gameObject.SetActive(true);
    }
}
