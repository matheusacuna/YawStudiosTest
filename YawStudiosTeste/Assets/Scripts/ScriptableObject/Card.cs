using UnityEngine;


[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObject/Card")]
public class Card : ScriptableObject
{
    public Sprite iconSprite;
    public string nameCard;
    public string descriptionCard;
    public int id;

    public virtual void ActiveCardEffect()
    {

    }
}
