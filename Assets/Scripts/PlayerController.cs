using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forceMultiplier;
    private Rigidbody2D playerRB;
    private Animator playerAnimator;

    private bool shouldFlap = false;

    private void Awake() {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        shouldFlap = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !shouldFlap){
            shouldFlap = true;
        }
    }

    private void FixedUpdate() {
        if (shouldFlap) Flap();
    }

    private void Flap()
    {
        playerRB.velocity = Vector2.zero;
        playerRB.AddForce(Vector2.up * forceMultiplier,ForceMode2D.Impulse);
        shouldFlap = false;
        playerAnimator.SetTrigger("flap");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        GameManager.Instance.NotifyPlayerDied();
    }

    private void OnBecameInvisible() {
        GameManager.Instance.NotifyPlayerDied();
    }

    private void OnTriggerExit2D(Collider2D other) {
        GameManager.Instance.AddOneToScore();
    }
}
