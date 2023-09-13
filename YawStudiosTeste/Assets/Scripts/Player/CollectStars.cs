using Managers;
using UnityEngine;

public class CollectStars : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StarsManager.ACT_IncrementStar();
            Destroy(gameObject);
        }
    }
}
