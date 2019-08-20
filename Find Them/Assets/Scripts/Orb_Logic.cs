using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_Logic : MonoBehaviour
{
    [SerializeField] private MeshRenderer OrbRenderer;

    [SerializeField] private Material BombMaterial;
    [SerializeField] private Material SafeMaterial;
    [SerializeField] private Material UnknownMaterial;

    private bool isBomb = false;

    public bool IsBomb
    {
        get { return isBomb; }
        set { isBomb = value;
            UpdateBombVisual();
        }
    }

    private void UpdateBombVisual()
    {
        if (isBomb)
        {
            OrbRenderer.material = BombMaterial;
        }
        else
        {
            OrbRenderer.material = SafeMaterial;
        }
    }
}
