using System;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private TMP_Text _text;
    private Counter _counter;

    public void Initialized(Counter counter)
    {
        _counter = counter;
        _counter.CountUpdated += UpdateScore;
    }

    private void Awake() =>  _text = GetComponent<TMP_Text>();
    private void OnDisable() => _counter.CountUpdated -= UpdateScore;
    private void UpdateScore(int score) => _text.text = Convert.ToString(score);
}
