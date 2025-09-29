using UnityEngine;
using TMPro;

public class BestScoreText : MonoBehaviour
{
    private const string BEST_SCORE_KEY = "BestScore";
    
    [SerializeField] private Counter _counter;
    
    private TMP_Text _text;
    
    private void Awake() =>
        _text = GetComponent<TMP_Text>();
    
    private void OnEnable() =>
        UpdateBestScore();
    
    private void UpdateBestScore()
    {
        int currentBestScore = PlayerPrefs.GetInt(BEST_SCORE_KEY, 0);
        int currentScore = _counter.Score;
        
        if (currentScore > currentBestScore)
        {
            PlayerPrefs.SetInt(BEST_SCORE_KEY, currentScore);
            PlayerPrefs.Save();
            currentBestScore = currentScore; 
        }
        
        _text.text = currentBestScore.ToString();
    }
}
