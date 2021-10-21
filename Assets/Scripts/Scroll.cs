using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2.5f;
    private Rigidbody2D rb;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.left * scrollSpeed;
    }

    
}
