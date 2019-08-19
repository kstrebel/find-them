using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay_Logic : MonoBehaviour
{
    [SerializeField] private GameObject orbPrefab;

    void Start()
    {
        try
        {
            spawnOrbs(3, 1);
        }
        catch(Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    private void spawnOrbs(int orbs, int bombs)
    {
        if (orbs <= bombs)
        {
            throw new Exception("Tried to spawn more bombs than is possible.");
        }
        if (orbs <= 0 || bombs <= 0)
        {
            throw new Exception("An impossible number of orbs/bombs was given.");
        }
    }
}
