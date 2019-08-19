using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_Logic : MonoBehaviour
{
    private bool isBomb = false;

    public bool IsBomb
    {
        get { return isBomb; }
        set { isBomb = value; }
    }
}
