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
    private readonly float BOTTOMTHRESSHOLD = -6f;

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
        if(transform.position.y < BOTTOMTHRESSHOLD) GameManager.Instance.NotifyPlayerDied();
        if(GameManager.Instance.IsTutorialOnScreen()) transform.position = new Vector2(-6.5f,0f);
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
        FindObjectOfType<AudioManager>().Play("FlapFX");
    }

    private void OnCollisionEnter2D() {
        GameManager.Instance.NotifyPlayerDied();
    }

    private void OnTriggerEnter2D() {
        GameManager.Instance.AddOneToScore();
    }
}
