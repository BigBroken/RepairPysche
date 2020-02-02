using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    public enum SelectedPlayer { Player1, Player2 };
    public SelectedPlayer Player;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void player1Movement()
    {
        horizontal = Input.GetAxisRaw("Player1Horizontal");
        vertical = Input.GetAxisRaw("Player1Vertical");
    }

    public void player2Movement()
    {
        horizontal = Input.GetAxisRaw("Player2Horizontal");
        vertical = Input.GetAxisRaw("Player2Vertical");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal, vertical).normalized * runSpeed;
    }
}
