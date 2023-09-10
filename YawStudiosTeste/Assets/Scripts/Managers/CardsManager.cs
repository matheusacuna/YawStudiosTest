using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class CardsManager : MonoBehaviour
    {
        [Header("Cards Settings")]
        public List<Card> cardsToSelect = new List<Card>();
        public Transform containerCard;
        public GameObject cardPrefab;

        private void Start()
        {
            SetCards();
        }

        private void SetCards()
        {
            for (int i = 0; i < cardsToSelect.Count; i++) 
            {
                GameObject prefabCard = Instantiate(cardPrefab,containerCard);
                prefabCard.GetComponent<SetupCard>().card = cardsToSelect[i];
                prefabCard.GetComponent<Button>().onClick.AddListener(() => SelectedCard(prefabCard));
            }
        }

        private void SelectedCard(GameObject obj)
        {

            for (int i = 0; i < containerCard.childCount; i++)
            {
                containerCard.GetChild(i).GetChild(0).gameObject.SetActive(false);
            }

            obj.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
