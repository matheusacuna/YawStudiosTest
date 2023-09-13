using Managers;
using UnityEngine;

namespace Puzzles
{
    public class EnemyMove : MonoBehaviour
    {
        [Header("Enemy Settings")]
        [SerializeField] private Transform leftPoint;
        [SerializeField] private Transform rightPoint;
        [SerializeField] private float moveSpeed;

        private Transform target; 

        void Start()
        {
            target = rightPoint; 
        }

        void Update()
        {
            Move();
        }
        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) < 0.01f)
            {
                if (target == leftPoint)
                {
                    target = rightPoint;
                }
                else
                {
                    target = leftPoint;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                GameManager.instance.LoserGame();
            }
        }
    }
}
