using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorRange_Logic : MonoBehaviour
{
    List<Orb_Logic> objectsInRange = new List<Orb_Logic>();

    public List<Orb_Logic> OrbsInRange => objectsInRange;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Orb")
        {
            Orb_Logic script = collision.collider.GetComponentInParent<Orb_Logic>();

            script.HighlightOrb(true);

            objectsInRange.Add(script);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Orb")
        {
            Orb_Logic script = collision.collider.GetComponentInParent<Orb_Logic>();

            script.HighlightOrb(false);

            objectsInRange.Remove(script);
        }
    }

    void OnDestroy()
    {
        while (1 <= objectsInRange.Count)
        {
            objectsInRange[0].HighlightOrb(false);

            objectsInRange.RemoveAt(0);
        }
    }
}
