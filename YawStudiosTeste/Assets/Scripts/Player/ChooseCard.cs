using Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChooseCard : MonoBehaviour
{
    [SerializeField] private CardsInventoryManager cardsInventoryManager;
    [SerializeField] private Animator anim;
    [SerializeField] private Button button;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        button.onClick.RemoveAllListeners();

        IPuzzle puzzle = collision.GetComponent<IPuzzle>();

        if(collision.gameObject.CompareTag("Puzzle"))
        {
            anim.Play("OpenDeckPlayer");

            if (puzzle != null)
            {
                button.onClick.AddListener(() => VerifyIdCards(collision.gameObject.GetComponent<Puzzle>().idPuzzle, puzzle));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puzzle"))
        {
            anim.Play("CloseDeckPlayer");
        }
    }

    public void VerifyIdCards(int id, IPuzzle Ipuzzle)
    {
        if(cardsInventoryManager.cardSelectedSO.id == id)
        {
            Ipuzzle.SolvePuzzle();
            anim.Play("CloseDeckPlayer");
            
        }
        else
        {
            Debug.Log("carta errada");
        }

        
    }
}
