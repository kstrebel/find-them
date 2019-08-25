using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Orb_Logic : MonoBehaviour
{
    //temporary
    [SerializeField] private Color colorHighlight;

    [SerializeField] private MeshRenderer orbRenderer;

    [SerializeField] private Material bombMaterial;
    [SerializeField] private Material safeMaterial;
    [SerializeField] private Material unknownMaterial;

    private bool isBomb = false;
    private bool isRevealed = false;

    public bool IsBomb
    {
        get { return isBomb; }
        set { isBomb = value; }
    }

    private void UpdateBombVisual()
    {
        if (isBomb)
        {
            orbRenderer.material = bombMaterial;
        }
        else
        {
            orbRenderer.material = safeMaterial;
        }

        isRevealed = true;
    }

    public void HighlightOrb(bool highlighted)
    {
        if (!isRevealed)
        {
            if (highlighted)
            {
                orbRenderer.material.color = colorHighlight;
            }
            else
            {
                orbRenderer.material = unknownMaterial;
            }
        }
    }

    public void ClickOrb()
    {
        if (!isRevealed)
        {
            UpdateBombVisual();
        }
    }
}
