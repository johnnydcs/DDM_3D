using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTileManager : MonoBehaviour
{
    public GameObject[] RayTileChildren;
    bool[] ValidTile;
    
    void Start()
    {
        ValidTile = new bool[6];

        for (int j = 0; j < ValidTile.Length; j++)
        {
            ValidTile[j] = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckValidDimension();
    }

    bool CheckValidDimension()
    {
        // Check if each Raycasting tile hits a black tile
        for (int i = 0; i < RayTileChildren.Length; i++)
        {
            if (RayTileChildren[i].GetComponent<RayTile>().HitBlackTile())
                ValidTile[i] = true;
            else
                ValidTile[i] = false;
        }

        // If any Raycasting tile does not hit a black tile, returns false; invalid
        for (int j = 0; j < ValidTile.Length; j++)
        {
            if (!ValidTile[j])
            {
                return false;
            }
        }

        // If pattern has adjacent player tile, valid
        for (int k = 0; k < RayTileChildren.Length; k++)
        {
            if (RayTileChildren[k].GetComponent<RayTile>().HitPlayerTile())
            {
                return true;
            }
        }
        
        // --------------- Will need to add in specific blue or red logic when there are player turns-------------
        // Since no adjacent player tile, invalid dimension
        return false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(this.name + "- Legal Summon?: " + CheckValidDimension());
        }
    }
}
