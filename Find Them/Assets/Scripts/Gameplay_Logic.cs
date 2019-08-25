using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay_Logic : MonoBehaviour
{
    [SerializeField] private GameObject orbPrefab;

    //x and z is space orbs can spawn in starting at 0. Y is the height all orbs will spawn at.
    [SerializeField] private Vector3 playArea;

    private List<GameObject> orbList = new List<GameObject>();

    void Start()
    {
        spawnOrbs(5, 4);
    }

    private void spawnOrbs(int orbs, int bombs)
    {
        Debug.Assert(bombs <= orbs, "Tried to spawn more bombs than is possible.");
        Debug.Assert(1 <= orbs || 0 <= bombs, "An impossible number of orbs/bombs was given.");

        Debug.Assert(orbList == null || orbList.Count < 1, "The list of orbs is not empty.");

        float halfX = playArea.x / 2f;
        float halfZ = playArea.z / 2f;

        List<Orb_Logic> unassignedOrbs = new List<Orb_Logic>();

        for (int i = 0; i < orbs; ++i)
        {
            Vector3 vec3 = new Vector3(
                Random.Range(0f, playArea.x) - halfX,
                playArea.y,
                Random.Range(0f, playArea.z) - halfZ);

            orbList.Add(GameObject.Instantiate(orbPrefab, vec3, Quaternion.identity));
            unassignedOrbs.Add(orbList[i].GetComponent<Orb_Logic>());
        }

        for(int i = 0; i < bombs; ++i)
        {
            int num = Random.Range(0, unassignedOrbs.Count);
            Debug.Assert(unassignedOrbs[num] != null, "The orb to become a bomb does not exist.");

            unassignedOrbs[num].IsBomb = true;
            unassignedOrbs.RemoveAt(num);
        }
    }
}
