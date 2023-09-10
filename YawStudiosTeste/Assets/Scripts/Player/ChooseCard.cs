using UnityEngine;

public class ChooseCard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPuzzle puzzle = collision.GetComponent<IPuzzle>();

        if (puzzle != null)
        {
            puzzle.SolvePuzzle();
        }
    }
}
