using System;
using UnityEngine;
using DG.Tweening;

public class PusleText : MonoBehaviour
{
    [SerializeField] private float _maxScale = 1.3f;
    [SerializeField] private float _minScale = 1;
    
    private RectTransform _transform;
    private Sequence _sequence;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        _sequence = DOTween.Sequence();
    }

    private void Start()
    {
        _sequence.Append(_transform.DOScale(new Vector2(_maxScale,_maxScale), 1f));
        _sequence.Append(_transform.DOScale(new Vector2(_minScale,_minScale), 1f));
        _sequence.SetLoops(-1);
    }
}
