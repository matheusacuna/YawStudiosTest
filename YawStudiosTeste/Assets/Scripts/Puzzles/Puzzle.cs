using UnityEngine;

public class Puzzle : MonoBehaviour, IPuzzle
{
    public string txt;
    public void SolvePuzzle()
    {
        Debug.Log(txt);
    }

}
