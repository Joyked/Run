using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _score = -1;

    public event Action<int> ScoreUpdader;

    public void AddPoint()
    {
        _score++;
        ScoreUpdader?.Invoke(_score);
    }
}
