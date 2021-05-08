using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTile : MonoBehaviour
{
    bool HittingBlackTile;
    bool FoundRedOrBlueTile;

    public GameObject ParentObj;

    Vector3[] FindRBTile;

    private void Start()
    {
        HittingBlackTile = false;
        FoundRedOrBlueTile = false;
        FindRBTile = new Vector3[4];

        FindRBTile[0] = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        FindRBTile[1] = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        FindRBTile[2] = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        FindRBTile[3] = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
    }

    public bool HitBlackTile()
    {
        return HittingBlackTile;
    }

    public bool HitPlayerTile()
    {
        return FoundRedOrBlueTile;
    }

    void FixedUpdate()
    {
        DoRayCast();
    }

    void DoRayCast()
    {
        // Raycast straight down to find a black tile
        RaycastHit hit, hit2;

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "BlackTile")
            {
                HittingBlackTile = true;
            }

            else
                HittingBlackTile = false;
        }

        // Cast a ray one space above, below, left, and right each RayTile to find 
        // at least one blue/red tile next to the unfolded layout
        for (int i = 0; i < FindRBTile.Length; i++)
        {
            if (Physics.Raycast(FindRBTile[i], this.transform.forward, out hit2, Mathf.Infinity))
            {
                if (hit2.collider.tag == "PlayerTile")
                {
                    FoundRedOrBlueTile = true;
                }
            }
        }
    }
}
