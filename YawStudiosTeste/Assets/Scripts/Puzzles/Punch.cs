using UnityEngine;

public class Punch : MonoBehaviour, IPuzzle
{
    public void SolvePuzzle()
    {
        Debug.Log("Destruiu o inimigo");
        Destroy(gameObject);
    }

}
