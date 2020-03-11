using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameInformation
{
    private static int orbs = 8;
    private static int bombs = 4;

    public static void StartNewGame(int numberOfOrbs, int numberOfBombs)
    {
        Orbs = numberOfOrbs;
        Bombs = numberOfBombs;

        SceneManager.LoadScene("Gameplay");
    }

    public static int Orbs
    {
        get { return orbs;}
        set { orbs = value; }
    }

    public static int Bombs
    {
        get { return bombs; }
        set { bombs = value; }
    }
}
