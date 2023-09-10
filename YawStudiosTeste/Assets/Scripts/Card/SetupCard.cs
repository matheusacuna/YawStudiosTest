using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetupCard : MonoBehaviour
{
    [Header("Setup Infos Card")]
    public Card card;
    public GameObject backgroundSelected;
    public TextMeshProUGUI nameCard;
    public TextMeshProUGUI descriptionCard;
    //public Image iconCard;

    void Start()
    {
        nameCard.text = card.nameCard;
        descriptionCard.text = card.descriptionCard;
        //iconCard.sprite = card.iconSprite;
    }
}
