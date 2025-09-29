using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int Score { get; private set; } = -1;

    public event Action<int> ScoreUpdader;

    public void AddPoint()
    {
        Score++;
        ScoreUpdader?.Invoke(Score);
    }
}
