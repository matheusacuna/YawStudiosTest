using Managers;
using UnityEngine;

public class ArrivalPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.WinGame();
        }
    }
}
