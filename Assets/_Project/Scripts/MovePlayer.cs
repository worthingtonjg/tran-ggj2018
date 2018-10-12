using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{ 
    public enum dirs { None = -1, Up, Down, Left, Right };
    public dirs startDirection;
    private dirs currDirection;
    private KeyCode keyUp;
    private KeyCode keyDown;
    private KeyCode keyLeft;
    private KeyCode keyRight;

    void Start()
    {
        currDirection = startDirection;
        SetKeys();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(keyLeft))
        {
            if(currDirection == dirs.Up)
            {
                currDirection = dirs.Left;
                transform.Rotate(0, -90, 0);
            }

            if(currDirection == dirs.Down)
            {
                currDirection = dirs.Left;
                transform.Rotate(0, 90, 0);
            }
        }

        if(Input.GetKeyDown(keyDown))
        {
            if(currDirection == dirs.Left)
            {
                currDirection = dirs.Down;
                transform.Rotate(0, -90, 0);
            }

            if(currDirection == dirs.Right)
            {
                currDirection = dirs.Down;
                transform.Rotate(0, 90, 0);
            }
        }

        if(Input.GetKeyDown(keyRight))
        {
            if(currDirection == dirs.Down)
            {
                currDirection = dirs.Right;
                transform.Rotate(0, 90, 0);
            }

            if(currDirection == dirs.Up)
            {
                currDirection = dirs.Right;
                transform.Rotate(0, -90, 0);
            }
        }

        if(Input.GetKeyDown(keyUp))
        {
            if(currDirection == dirs.Right)
            {
                currDirection = dirs.Up;
                transform.Rotate(0, 90, 0);
            }

            if(currDirection == dirs.Left)
            {
                currDirection = dirs.Up;
                transform.Rotate(0, -90, 0);
            }
        }

        print(currDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided with " + other.name);
        //Play sound "Light Cycle Explosion.mp3"
        var audioPlayer = gameObject.GetComponent<AudioSource>();
        audioPlayer.Play();  //.PlayOneShot(explosionClip);
        var trail = transform.parent.GetComponent<TrailRenderer>();
        trail.time = -1f;

        if (name == "Player1")
        {
            KeepScore.Instance.UpdateScores(1, 0);
        }
        if (name == "Player2")
        {
            KeepScore.Instance.UpdateScores(0, 1);
        }

        KeepScore.Instance.CheckForWin();
        
    }

    private void SetKeys()
    {
        if (gameObject.name == "Player1")
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
