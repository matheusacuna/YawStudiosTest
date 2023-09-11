using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [Header("Portal Settings")]
    [SerializeField] private Transform targetPortal;
    [SerializeField] private Transform playerTransform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerTransform = collision.gameObject.transform;
        }
    }

    public void GetPlayerTransform()
    {
        playerTransform.position = targetPortal.position;
    }


}
