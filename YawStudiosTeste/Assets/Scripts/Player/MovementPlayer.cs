using UnityEngine;
using Managers;

namespace Player
{
    public class MovementPlayer : MonoBehaviour
    {
        [Header("Scripts Reference")]
        public MyInputsManager myInputsManager;
        public float speed;

    
        private Vector2 movement;
        private Rigidbody2D rig;

        void Start()
        {
            rig = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Inputs();
        }
        void FixedUpdate()
        {
            Move();
        }

        private void Inputs()
        {
            movement = myInputsManager.myInputs.Player.Move.ReadValue<Vector2>().normalized;
        }

        public void Move()
        {
            if(GameManager.instance.startGame)
            {
                rig.velocity = new Vector2(movement.x * speed, movement.y * speed);
            }
        }
    }
}
