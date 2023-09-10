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

        [Header("Card Seletected")]
        public Card cardSelectedSO;
        public GameObject cardSelectedObj;

        public bool emptyCardsInventory;

        private void Start()
        {
            InstantiateInventoryCards();
        }

        private void InstantiateInventoryCards()
        {
            for (int i = 0; i < cardsToSelect.Count; i++) 
            {
                GameObject prefabCard = Instantiate(cardPrefab,containerCard);
                prefabCard.GetComponent<SetupCard>().card = cardsToSelect[i];
                prefabCard.GetComponent<Button>().onClick.AddListener(() => SelectedCard(prefabCard));
            }
        }

        public void InstantiateCardsDeck()
        {
            for (int i = 0; i < deckCardPlayer.Count; i++)
            {
                GameObject deckCardPrefab = Instantiate(prefabCardDeck, containerCardsDeck);
                deckCardPrefab.GetComponent<SetupCard>().card = deckCardPlayer[i];
            }
        }

        private void SelectedCard(GameObject obj)
        {
            cardSelectedSO = obj.GetComponent<SetupCard>().card;
            cardSelectedObj = obj;

            for (int i = 0; i < containerCard.childCount; i++)
            {
                containerCard.GetChild(i).GetChild(0).gameObject.SetActive(false);
            }

            obj.transform.GetChild(0).gameObject.SetActive(true);
            buttonSelectCard.gameObject.SetActive(true);

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
                InstantiateCardsDeck();
                board.gameObject.SetActive(false);
            }
        }
    }
}
