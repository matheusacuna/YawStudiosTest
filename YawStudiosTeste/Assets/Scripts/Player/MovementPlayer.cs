using UnityEngine;
using Managers;

public class MovementPlayer : MonoBehaviour
{
    private Rigidbody2D rig;
    [Header("Scripts Reference")]
    public MyInputsManager myInputsManager;

    public float speed;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
