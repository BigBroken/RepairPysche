using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;
    public enum SelectedPlayer { Player1, player2 };
    public SelectedPlayer Player;
    public GameObject AttackPrefab;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Player == SelectedPlayer.Player1)
        {
            horizontal = Input.GetAxisRaw("Player1Horizontal");
            vertical = Input.GetAxisRaw("Player1Vertical");
            if (Input.GetButtonDown("Player1Attack"))
            {
                UseAttack();
            }
        }
        else if (Player == SelectedPlayer.player2)
        {
            horizontal = Input.GetAxisRaw("Player2Horizontal");
            vertical = Input.GetAxisRaw("Player2Vertical");
            if (Input.GetButtonDown("Player2Attack"))
            {
                UseAttack();
            }
        }
    }
    void UseAttack()
    {
        GameObject Attack = Instantiate(AttackPrefab, this.transform);
        Attack.GetComponent<AttackController>().SetDirection(body.velocity);
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal, vertical).normalized * runSpeed;
    }
}
