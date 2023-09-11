using System.Collections.Generic;
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

        public bool emptyCardsInventory;

        private void Start()
        {
            board.SetActive(true);
            InstantiateCards(cardsToSelect, cardPrefab, containerCard, buttonSelectCard);
        }

        public void InstantiateCards(List<Card> cardList, GameObject cardPrefab, Transform containerCards, Button button)
        {
            for (int i = 0; i < cardList.Count; i++)
            {
                GameObject obj = Instantiate(cardPrefab, containerCards);
                obj.GetComponent<SetupCard>().card = cardList[i];
                obj.GetComponent<Button>().onClick.AddListener(() => SelectedCard(obj, containerCards, button));
            }
        }

        private void SelectedCard(GameObject obj, Transform container, Button button)
        {
            cardSelectedSO = obj.GetComponent<SetupCard>().card;
            cardSelectedObj = obj;

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

            if (countCardsChosen == 3)
            {
                InstantiateCards(deckCardPlayer, prefabCardDeck, containerCardsDeck, buttonCardDeckSelected);
                board.gameObject.SetActive(false);
                GameManager.ACT_CanStartGame(true);
            }
        }
    }
}
