using UnityEngine;

namespace Managers
{
    public class CardsDeckManager : MonoBehaviour
    {
        [Header("Cards Deck Settings")]
        public Transform containerCardsDeck;
        public GameObject prefabCardDeck;
        public CardsInventoryManager cardsInventoryManager;

        public void InstantiateCardsDeck()
        {
            for (int i = 0; i < cardsInventoryManager.deckCardPlayer.Count; i++)
            {
                GameObject deckCardPrefab = Instantiate(prefabCardDeck, containerCardsDeck);
                deckCardPrefab.GetComponent<SetupCard>().card = cardsInventoryManager.deckCardPlayer[i];
            }
        }
    }

}
