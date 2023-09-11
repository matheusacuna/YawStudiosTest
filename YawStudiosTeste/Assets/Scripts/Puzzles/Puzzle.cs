using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Puzzle : MonoBehaviour, IPuzzle
{
    public int idPuzzle;
    public UnityEvent eventPuzzle;

    public void SolvePuzzle()
    {
        eventPuzzle.Invoke();
    }
}
