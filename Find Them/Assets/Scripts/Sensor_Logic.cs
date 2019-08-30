using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sensor_Logic : MonoBehaviour
{
    [SerializeField] private TextMeshPro countText;
    [SerializeField] private SensorRange_Logic rangeScript;

    private float effectiveRadius;
    private List<Orb_Logic> objectsInRange = new List<Orb_Logic>();

    public void onPlacement()
    {
        objectsInRange = rangeScript.OrbsInRange;

        int orbs = 0, bombs = 0;

        for (int i = 0; i < objectsInRange.Count; ++i)
        {
            if (objectsInRange[i].tag == "Orb")
            {
                ++orbs;

                if (objectsInRange[i].GetComponent<Orb_Logic>().IsBomb)
                {
                    ++bombs;
                }
            }
        }

        countText.text = bombs + " /" + orbs;
    }
}
