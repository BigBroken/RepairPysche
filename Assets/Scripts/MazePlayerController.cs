using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePlayerController : MovementController
{
    void Update()
    {
        if (Player == SelectedPlayer.Player1)
        {
            player1Movement();
        }

        else if (Player == SelectedPlayer.Player2)
        {
            player2Movement();
        }
    }
}
