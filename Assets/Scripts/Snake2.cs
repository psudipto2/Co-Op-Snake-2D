using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake2 : MonoBehaviour
{
    private Vector2 direction;
    public GameObject Snake_Head;
    private List<Transform> snakeBodies;
    public Transform SnakeBodyPrefab;
    private void Start()
    {
        snakeBodies = new List<Transform>();
        snakeBodies.Add(this.transform);
    }
    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)&&direction!=Vector2.down)
        {
            direction = Vector2.up;
            transform.eulerAngles = new Vector3(0, 0, 0);  
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)&& direction!=Vector2.up)
        {
            direction = Vector2.down;
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && direction != Vector2.right)
        {
            direction = Vector2.left;
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && direction != Vector2.left)
        {
            direction = Vector2.right;
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
    }
    private void FixedUpdate()
    {
        for(int i = snakeBodies.Count - 1; i > 0; i--)
        {
            snakeBodies[i].position = snakeBodies[i - 1].position;
        }
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x)+ direction.x, Mathf.Round(this.transform.position.y) + direction.y);
    }
    private void grow()
    {
        Transform SnakeBody = Instantiate(this.SnakeBodyPrefab);
        SnakeBody.position = snakeBodies[snakeBodies.Count - 1].position;
        snakeBodies.Add(SnakeBody);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        { 
            grow();
        }
        else if (collision.tag == "Wall"|| collision.tag == "Snake2Body")
        {
            SceneManager.LoadScene(0);
        }
    }

}
