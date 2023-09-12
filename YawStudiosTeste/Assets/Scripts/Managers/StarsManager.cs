using System;
using UnityEngine;

public class StarsManager : MonoBehaviour
{
    public static Action ACT_IncrementStar;
    public int starsCount;

    private void OnEnable()
    {
        ACT_IncrementStar += IncrementStar;
    }

    private void OnDisable()
    {
        ACT_IncrementStar -= IncrementStar;
    }

    public void IncrementStar()
    {
        starsCount++;
    }
}
