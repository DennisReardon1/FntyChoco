using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragME : MonoBehaviour
{
    Vector2 difference = Vector2.zero;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        //without this the item we drag drops like a rock
        rb.velocity = Vector2.zero;
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        //without this the item we drag drops like a rock
        rb.velocity = Vector2.zero;
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }
}
