using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 direction;
    public GameObject Snake_Head;
    private List<Transform> segments;
    private void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
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
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x)+ direction.x, Mathf.Round(this.transform.position.y) + direction.y);
        //this.transform.eulerAngles = new Vector3(0, 0, 180);
    }
}
