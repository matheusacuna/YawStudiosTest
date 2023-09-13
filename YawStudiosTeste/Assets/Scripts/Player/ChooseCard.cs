using Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Puzzles;

namespace Player
{
    public class ChooseCard : MonoBehaviour
    {
        [SerializeField] private CardsInventoryManager cardsInventoryManager;
        [SerializeField] private Animator anim;
        [SerializeField] private Button button;
        [SerializeField] private Animator animHeartBroken;
        [SerializeField] private Animator animDontHaveCard;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            button.onClick.RemoveAllListeners();

            IPuzzle puzzle = collision.gameObject.GetComponent<IPuzzle>();

            if (collision.gameObject.CompareTag("Puzzle"))
            {
                anim.Play("OpenDeckPlayer");

                if (puzzle != null)
                {
                    UnityAction action = () =>
                    {
                        VerifyIdCards(collision.gameObject.GetComponent<Puzzle>().idPuzzle, puzzle);
                        cardsInventoryManager.DecrementCardCount(cardsInventoryManager.cardSelectedObj);
                    };
                    button.onClick.AddListener(action);
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
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
                if(cardsInventoryManager.cardSelectedSO.cardCount > 0)
                {
                    Ipuzzle.SolvePuzzle();
                    anim.Play("CloseDeckPlayer");
                }
                else
                {
                    anim.Play("CloseDeckPlayer");
                    animDontHaveCard.Play("donthavecardsFeedback");
                }
            
            }
            else
            {
                HealthManager.ACT_DecrementHealth(1);
                animHeartBroken.Play("errorFeedback");
            }    
        }
    }
}
