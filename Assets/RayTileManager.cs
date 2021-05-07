using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTileManager : MonoBehaviour
{
    public GameObject[] RayTileChildren;
    bool[] ValidTile;

    bool ValidDimension;

    void Start()
    {
        ValidTile = new bool[6];

        for (int j = 0; j < ValidTile.Length; j++)
        {
            ValidTile[j] = false;
        }

        ValidDimension = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < RayTileChildren.Length; i++)
        {
            if (RayTileChildren[i].GetComponent<RayTile>().HitBlackTile())
                ValidTile[i] = true;
            else
                ValidTile[i] = false;
        }

        for (int j = 0; j < ValidTile.Length; j++)
        {
            if (!ValidTile[j])
            {
                ValidDimension = false;
                Debug.Log("Invalid Dimension");
            }

            else
            {
                ValidDimension = true;
                Debug.Log("Valid Dimension");
            }
        }
    }
}
