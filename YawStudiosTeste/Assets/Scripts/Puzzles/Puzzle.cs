using UnityEngine;
using UnityEngine.Events;

namespace Puzzles
{
    public class Puzzle : MonoBehaviour, IPuzzle
    {
        public int idPuzzle;
        public UnityEvent eventPuzzle;

        public void SolvePuzzle()
        {
            eventPuzzle.Invoke();
        }
    }
}
