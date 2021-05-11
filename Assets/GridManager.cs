using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Sprite RedRef;
    public Sprite BlueRef;
    public Sprite BlackRef;

    private readonly int Rows = 19;
    private readonly int Cols = 13;

    public GameObject[,] GridBoard;
    
    public GameObject TileRef;

    // Start is called before the first frame Update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDimension();
    }

    void GenerateGrid()
    {
        // Create all black tiles
        GameObject[,] GridBoard = new GameObject[Rows, Cols];

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                GridBoard[i, j] = Instantiate(TileRef, new Vector3(j, i, 0), Quaternion.identity);
            }
        }

        // Make Red and Blue starting tiles - Player Avatar
        GridBoard[0, 6].GetComponent<SpriteRenderer>().sprite = BlueRef;

        GridBoard[18, 6].GetComponent<SpriteRenderer>().sprite = RedRef;
    }

    void CheckDimension()
    {
        var rtm = GetComponent<RayTileManager>().CheckValidDimension();

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(this.name + "- Legal Summon?: " + rtm);
            // Destroy RayTiles and flip black tiles to red or blue
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (GridBoard[i, j].GetComponent<Tile>().IsMarked())
                    {
                        GridBoard[i, j].GetComponent<SpriteRenderer>().sprite = BlueRef;
                    }
                }
            }
        }
    }
}
