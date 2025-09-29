using UnityEngine;
using DG.Tweening;

public class SwipeIconAnimation : MonoBehaviour
{
    [SerializeField] private float _invisibilityDelay;
    [SerializeField] private float _travelTime;
    
    private RectTransform _transform;
    private CanvasGroup _canvasGroup;
    private Sequence _sequence;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _sequence = DOTween.Sequence();
    }

    private void Start()
    {
        _sequence.Append(_transform.DOAnchorPos(new Vector2(100, _transform.anchoredPosition.y), 3f));
        _sequence.Append(_canvasGroup.DOFade(0, 0.5f));
        _sequence.AppendInterval(_invisibilityDelay);
        _sequence.Append(_canvasGroup.DOFade(1, 0.5f));
        
        _sequence.Append(_transform.DOAnchorPos(new Vector2(-100, _transform.anchoredPosition.y), 3f));
        _sequence.Append(_canvasGroup.DOFade(0, 0.5f));
        _sequence.AppendInterval(_invisibilityDelay);
        _sequence.Append(_canvasGroup.DOFade(1, 0.5f));
    
        _sequence.SetLoops(-1);
    }
}
