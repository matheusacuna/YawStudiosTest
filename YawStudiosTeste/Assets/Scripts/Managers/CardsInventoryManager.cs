using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class CardsInventoryManager : MonoBehaviour
    {
        [Header("Cards Inventory Settings")]
        public List<Card> cardsToSelect = new List<Card>();
        public List<Card> deckCardPlayer = new List<Card>();
        public Transform containerCard;
        public GameObject cardPrefab;
        public GameObject board;
        public Button buttonSelectCard;
        public int countCardsChosen;

        [Header("Cards Deck Settings")]
        public Transform containerCardsDeck;
        public GameObject prefabCardDeck;
        public Button buttonCardDeckSelected;

        [Header("Card Inventory Seletected")]
        public Card cardSelectedSO;
        public GameObject cardSelectedObj;
        public int cardCount;

        public bool emptyCardsInventory;

        private void Start()
        {
            board.SetActive(true);
            InstantiateCardsBoard();
        }

        public void InstantiateCardsBoard()
        {
            for (int i = 0; i < cardsToSelect.Count; i++)
            {
                GameObject obj = Instantiate(cardPrefab, containerCard);
                obj.GetComponent<SetupCard>().card = cardsToSelect[i];
                obj.transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text = obj.GetComponent<SetupCard>().card.cardCount.ToString(); ;
                obj.GetComponent<Button>().onClick.AddListener(() => SelectedCard(obj, containerCard, buttonSelectCard));
                obj.transform.GetChild(6).GetComponent<Button>().onClick.AddListener(() => IncrementCardCount(obj));
                
            }
        }

        public void InstantiateCardsDeck()
        {
            for (int i = 0; i < deckCardPlayer.Count; i++)
            {
                GameObject obj = Instantiate(prefabCardDeck, containerCardsDeck);
                obj.GetComponent<SetupCard>().card = deckCardPlayer[i];
                obj.transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text = obj.GetComponent<SetupCard>().card.cardCount.ToString();
                obj.GetComponent<Button>().onClick.AddListener(() => SelectedCard(obj, containerCardsDeck, buttonCardDeckSelected));

            }
        }

        private void SelectedCard(GameObject obj, Transform container, Button button)
        {
            cardSelectedSO = obj.GetComponent<SetupCard>().card;
            cardSelectedObj = obj;
            cardCount = obj.GetComponent<SetupCard>().card.cardCount;

            for (int i = 0; i < container.childCount; i++)
            {
                container.GetChild(i).GetChild(0).gameObject.SetActive(false);
            }

            obj.transform.GetChild(0).gameObject.SetActive(true);
            button.gameObject.SetActive(true);

        }

        public void SendCardToDeck()
        {
            if(cardsToSelect.Contains(cardSelectedSO))
            {
                cardsToSelect.Remove(cardSelectedSO);
                deckCardPlayer.Add(cardSelectedSO);

               countCardsChosen++;
            }

            Destroy(cardSelectedObj);

            if (countCardsChosen == 2)
            {
                InstantiateCardsDeck();
                board.gameObject.SetActive(false);
                GameManager.ACT_CanStartGame(true);
            }
        }

        public void IncrementCardCount(GameObject obj)
        {
            obj.GetComponent<SetupCard>().card.cardCount++;

            obj.transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text = obj.GetComponent<SetupCard>().card.cardCount.ToString();
        }

        public void DecrementCardCount(GameObject obj)
        {
            if(obj.GetComponent<SetupCard>().card.cardCount > 0)
            {
                obj.GetComponent<SetupCard>().card.cardCount--;
            }

            obj.transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text = obj.GetComponent<SetupCard>().card.cardCount.ToString();
        }
    }
}
