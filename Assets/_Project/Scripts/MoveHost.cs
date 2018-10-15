using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHost : MonoBehaviour
{
    public enum dirs { None = -1, Up, Down, Left, Right };
    public dirs startDirection;
    public float speed;
    public GameObject player;
    private Vector3 originalPosition;
    private Vector3 currPosition;
    private Vector3 lastPosition;
    private dirs currDirection;
    private KeyCode keyUp;
    private KeyCode keyDown;
    private KeyCode keyLeft;
    private KeyCode keyRight;
    private bool isMoving;

    void Start()
    {
        currDirection = startDirection;
        originalPosition = transform.position;
        lastPosition = originalPosition;
        SetKeys();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyLeft))
        {
            if(currDirection == dirs.Up)
            {
                currDirection = dirs.Left;
            }

            if(currDirection == dirs.Down)
            {
                currDirection = dirs.Left;
            }

            isMoving = true;
        }

        if(Input.GetKeyDown(keyDown))
        {
            if(currDirection == dirs.Left)
            {
                currDirection = dirs.Down;
            }

            if(currDirection == dirs.Right)
            {
                currDirection = dirs.Down;
            }
            
            isMoving = true;
        }

        if(Input.GetKeyDown(keyRight))
        {
            if(currDirection == dirs.Down)
            {
                currDirection = dirs.Right;
            }

            if(currDirection == dirs.Up)
            {
                currDirection = dirs.Right;
            }

            isMoving = true;
        }

        if(Input.GetKeyDown(keyUp))
        {
            if(currDirection == dirs.Right)
            {
                currDirection = dirs.Up;
            }

            if(currDirection == dirs.Left)
            {
                currDirection = dirs.Up;
            }

            isMoving = true;
        }

        if(isMoving) 
        {
            switch (currDirection)
            {
                case dirs.Up:
                    transform.Translate(Vector3.forward * speed * -1f * Time.deltaTime, Space.Self);
                    break;
                case dirs.Down:
                    transform.Translate(Vector3.back * speed * -1f * Time.deltaTime, Space.Self);
                    break;
                case dirs.Left:
                    transform.Translate(Vector3.left * speed * -1f * Time.deltaTime, Space.Self);
                    break;
                case dirs.Right:
                    transform.Translate(Vector3.right * speed * -1f * Time.deltaTime, Space.Self);
                    break;
                case dirs.None:
                    //transform.position = originalPosition;
                    transform.Translate(Vector3.zero);
                    isMoving = false;
                    break;
            }
            currPosition = transform.position;
            float farenough = Vector3.Distance(lastPosition, currPosition);
            if (farenough > 30f)
            {
                var trailItem = Resources.Load("TrailItem");
                GameObject TI = Instantiate(trailItem, lastPosition, player.transform.rotation) as GameObject;

                var trail = GetComponent<TrailRenderer>();
                trail.time = 200f;
                lastPosition = transform.position;
            }
        }
    }

    private void SetKeys()
    {
        if (player.name == "Player1")
        {
            keyUp = KeyCode.W;
            keyDown = KeyCode.S;
            keyLeft = KeyCode.A;
            keyRight = KeyCode.D;
        }
        else
        {
            keyUp = KeyCode.I;
            keyDown = KeyCode.K;
            keyLeft = KeyCode.J;
            keyRight = KeyCode.L;
        }
    }
}
