using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.W)&&direction!=Vector2.down)
        {
            direction = Vector2.up;
            transform.eulerAngles = new Vector3(0, 0, 0);
            //Snake_Head.GetComponent<SpriteRenderer>().sprite = GameAssets.i.Head_up;
        }
        if (Input.GetKeyDown(KeyCode.S)&& direction!=Vector2.up)
        {
            direction = Vector2.down;
            transform.eulerAngles = new Vector3(0, 0, 180);
            //Snake_Head.GetComponent<SpriteRenderer>().sprite = GameAssets.i.Head_down;
        }
        if (Input.GetKeyDown(KeyCode.A) && direction != Vector2.right)
        {
            direction = Vector2.left;
            transform.eulerAngles = new Vector3(0, 0, 90);
            //Snake_Head.GetComponent<SpriteRenderer>().sprite = GameAssets.i.Head_left;
        }
        if (Input.GetKeyDown(KeyCode.D) && direction != Vector2.left)
        {
            direction = Vector2.right;
            transform.eulerAngles = new Vector3(0, 0, -90);
            //Snake_Head.GetComponent<SpriteRenderer>().sprite = GameAssets.i.Head_right;
        }
    }
    private void FixedUpdate()
    {
        for(int i = snakeBodies.Count - 1; i > 0; i--)
        {
            snakeBodies[i].position = snakeBodies[i - 1].position;
        }
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x)+ direction.x, Mathf.Round(this.transform.position.y) + direction.y);
        //this.transform.eulerAngles = new Vector3(0, 0, 180);
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
        else if (collision.tag == "Wall")
        {
            SceneManager.LoadScene(0);
        }
    }

    /*private void ResetState()
    {
        for(int i = 1; i <= snakeBodies.Count; i++)
        {
            Destroy(snakeBodies[i].gameObject);
        }
        snakeBodies.Clear();
        snakeBodies.Add(this.transform);
        this.transform.position = Vector3.zero;
    }*/
}
