using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameSetup_Logic : MonoBehaviour
{
    [SerializeField] private Slider orbsSlider;
    [SerializeField] private TextMeshProUGUI orbsValue;

    [SerializeField] private Slider bombsSlider;
    [SerializeField] private TextMeshProUGUI bombsValue;

    private float bombToOrbRatio;

    void Start()
    {
        orbsValue.text = orbsSlider.value.ToString();
        bombsValue.text = bombsSlider.value.ToString();
    }

    public void StartGame()
    {
        GameInformation.StartNewGame((int)orbsSlider.value, (int)bombsSlider.value);
    }

    public void ValueChangeOrbStart()
    {
        bombToOrbRatio=bombsSlider.value/orbsSlider.value;
    }

    public void ValueChangeOrb()
    {
        int value = (int)orbsSlider.value;

        bombsSlider.maxValue = value; //the slider will visually show what fraction of orbs are bombs, even though all orbs being bombs is not possible

        bombsSlider.value = (int)(value * bombToOrbRatio);

        orbsValue.text = value.ToString();
        bombsValue.text = bombsSlider.value.ToString();

        checkBombValue();
    }

    public void ValueChangeBomb()
    {
        int value = (int)bombsSlider.value;

        bombsValue.text = value.ToString();

        checkBombValue();
    }

    void checkBombValue()
    {
        Debug.Assert(0 <= bombsSlider.value, "Currently not set to spawn any bombs.");

        if(bombsSlider.maxValue<= bombsSlider.value)
        {
            bombsSlider.value = bombsSlider.maxValue - 1;
        }
    }
}
