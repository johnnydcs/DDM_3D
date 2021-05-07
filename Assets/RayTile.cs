using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTile : MonoBehaviour
{
    bool HittingBlackTile;

    public GameObject ParentObj;

    public bool HitBlackTile()
    {
        return HittingBlackTile;
    }

    void FixedUpdate()
    {
        // Cast a ray straight down.
        RaycastHit hit;

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "BlackTile")
            {
                HittingBlackTile = true;
            }

            else
                HittingBlackTile = false;
        }
    }
}
