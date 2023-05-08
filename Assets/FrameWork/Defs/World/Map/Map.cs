using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map //figur eout a way of getting rid/combining this with environment map
{
    private List<Tilemap> layers = new List<Tilemap>();
    private Vector2 selectedTile = new Vector2(0,0);
    private Color highlight = new Color(0, .5f, 0);
    private Color baseColor = new();
    private bool tileSeletced = false;
    //make last selected varible/current selected

    public void AddMap(Tilemap layer)
    {
        layers.Add(layer);
    }
    public Tilemap GetMap(float value)
    {
        return layers[((int)value)];
    }

    //make function to return tile
    public void SetTile(int layer,int x, int y,TileBase tileToPlace)
    {
        layers[layer].SetTile(new Vector3Int(x,y,0), tileToPlace);
    }
    public void SetColor(int layer, int x, int y, Color color)//maybe make a ui element later that just is like an outline
    {
        layers[layer].SetColor(new Vector3Int(x, y, 0), color);
    }
    public Color GetColor(int layer, int x, int y)//maybe make a ui element later that just is like an outline
    {
        return layers[layer].GetColor(new Vector3Int(x, y, 0));
    }

    public void SetFlag(int layer, int x, int y, TileFlags flag)
    {
        layers[layer].SetTileFlags(new Vector3Int(x, y, 0), flag);
    }
    public TileBase CheckLayer(int layer, int x, int y)
    {
        return layers[layer].GetTile(new Vector3Int(x,y,0));
    }

    public void SelectTile(int layer,int x,int y)
    {
        //check for if their is a tile selected or not
        if (!tileSeletced)
        {
            baseColor = GetColor(layer, x, y);

            SetColor(layer, x, y, highlight);
            selectedTile.x = x;
            selectedTile.y = y;
            tileSeletced = true;
        }
        else if (selectedTile.x != x || selectedTile.y != y)
        {
            //unselecting old
            SetColor(layer, ((int)selectedTile.x), ((int)selectedTile.y), baseColor);            

            //select new
            selectedTile.x = x;
            selectedTile.y = y;
            baseColor = GetColor(layer, x, y);
            SetColor(layer, x, y, highlight);

            tileSeletced = true;
        }
       
    }
    public void UnSelectTile(int layer, int x, int y)
    {
        if (tileSeletced)
        {
            //baseColor = GetColor(layer, x, y);
            SetColor(layer, ((int)selectedTile.x), ((int)selectedTile.y), baseColor);
            tileSeletced = false;
        }
    }


    //needs fixing get dads help
    /*
    public bool CheckTileNeighbored(int currentLayer,TerrainBase tileToCheck, int row, int col)
    {       
        int totalSimiler = 0;
        int startRow = row - 1;
        int startCol = col - 1;
        int endRow = row + 1;
        int endCol = col + 1;
        //TileBase test = tileToCheck.GetTile();

        Debug.Log("______________________");
       // Debug.Log(tileToCheck.GetTile().GetInstanceID());
        //Debug.Log("______________________");
        //Debug.Log(startRow + " | " + endRow + " | "+row+ " | " +col);
        for (int x = startRow; x <= endRow; x++)
        {
            for (int y = startCol; y <= endCol; y++)
            {
                //for (int i = 0; i < tileToCheck.graphics.Count; i++)
                //{
                    Debug.Log(totalSimiler);

                    //checking for if tile is smiler or nothing
                    //tile map to check is ground tile so 1
                    //Debug.Log(CheckLayer(currentLayer, x, y).GetInstanceID());
                    if (x == row && y == col)
                    {
                        //Debug.Log("OG");
                        break;
                    }
                    else if (CheckLayer(currentLayer, x, y) == null || CheckLayer(currentLayer, x, y) == tileToCheck.GetTile())
                    {
                        //Debug.Log("Found");
                        totalSimiler++;
                        break;
                    }
                //}
            }
        }
        if (totalSimiler == 8)
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/
}
