using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MovementState { LEFT , RIGHT, IDLE, JUMP };

public class AutomatedMovement : MonoBehaviour
{
    MovementState movementState = MovementState.IDLE;
    MovementState lastMovementState = MovementState.IDLE;
    float randomTimer;
    public float movementSpeed;
    Transform objectsTransform;
    Vector2 position;
    CircleCollider2D collider;
    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        randomTimer = Random.Range(3f, 10f);
        objectsTransform = GetComponent<Transform>();
        collider = GetComponent<CircleCollider2D>();
        position = objectsTransform.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        randomTimer -= Time.deltaTime;
        if(randomTimer <= 0f)
        {
            GetRandomMovementState();
            RestartTimer();
        }
        //Debug.Log("Movement State: " + movementState.ToString()+
        //    "\nLast Movement State: " + this.lastMovementState.ToString());

        Move();
    }


    void GetRandomMovementState()
    {
        
        
        int[] states = new int[4] { 0, 1, 2, 3 };
        int randomStateValue = states[(int) Random.Range(0, states.Length)];

        if (randomStateValue == 0 && lastMovementState.ToString() != "LEFT")
        {
            lastMovementState = this.movementState;
            movementState = MovementState.LEFT;
        }
        else if (randomStateValue == 1 && lastMovementState.ToString() != "RIGHT")
        {
            lastMovementState = this.movementState;
            movementState = MovementState.RIGHT;
        }
        else if (randomStateValue == 2 && lastMovementState.ToString() != "IDLE")
        {
            lastMovementState = this.movementState;
            movementState = MovementState.IDLE;

        }
        else if (randomStateValue == 3 && lastMovementState.ToString() != "JUMP")
        {
            lastMovementState = this.movementState;
            movementState = MovementState.JUMP;
        }
    }

    void Move()
    {
        if(movementState == MovementState.LEFT)
        {
            Vector2 movement = new Vector2(-1f, 0);
            objectsTransform.position += (Vector3) movement * Time.deltaTime * movementSpeed;
            
        }
        if (movementState == MovementState.RIGHT)
        {
            Vector2 movement = new Vector2(1f, 0);
            objectsTransform.position += (Vector3)movement * Time.deltaTime * movementSpeed;
            
        }

        if (movementState == MovementState.IDLE)
        {
            Vector2 movement = new Vector2(0f, 0);
            objectsTransform.position += (Vector3)movement * movementSpeed;

        }
        if(movementState == MovementState.JUMP)
        {
            Vector2 velocity = new Vector2(0f, .07f);
            rigidbody.AddForce(velocity, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftWall")
        {
            this.movementState = MovementState.RIGHT;
            //RestartTimer();
        } else if(collision.gameObject.tag == "RightWall")
        {
            this.movementState = MovementState.LEFT;
           //RestartTimer();
        } 

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Roof")
        {
            rigidbody.AddForce(new Vector2(0f, -.07f), ForceMode2D.Impulse);
            movementState = MovementState.IDLE;
            RestartTimer();
        }
    }

    private void RestartTimer()
    {
        randomTimer = Random.Range(3f, 5f);
    }
}
