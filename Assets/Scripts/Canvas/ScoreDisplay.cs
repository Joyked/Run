using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable() =>
        _counter.ScoreUpdader += DrawNewScore;

    private void OnDisable() =>
        _counter.ScoreUpdader -= DrawNewScore;

    private void DrawNewScore(int score)
    {
        _text.text = score.ToString();
    }
}
