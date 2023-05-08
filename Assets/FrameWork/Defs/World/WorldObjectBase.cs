using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;

/// About the Class
/// WorldObjectBase is the base definition for a world objects stats,variables and interaction with 
/// the player. with this being the base class it lacks a lot of the specialized interactions/aspects 
/// that are defined more in depth by class such as Terrainbase, ResourceBase, PlantBase.
/// this along with children classes allows for stats/definitions of a world object to be created in and
/// pulled out of worldObjectDatabase;

public enum Support
{
    Light = 0,
    Medium = 1,
    Heavy = 2,
}

public class WorldObjectBase //: Tile
{
    public string name;
    public Support support;//todo
    public Support supportNeeded;//todo
    public string description;
    public List<Sprite> graphics = new List<Sprite>();
    private Tile tile = ScriptableObject.CreateInstance<Tile>();

    //gen Info
    public Stat height = new();
    public Stat mapLayer = new();
    public Stat moisture = new();
    public Stat tempature = new();

    //object info maybe add more to base object info
    public Stat hitPoints = new();//can just add a modifer every hit - need a figure out a way of removing/adding 
    public Stat flamability = new();
    public Stat fertility = new();
    public BuildCost[] biuldCost = new BuildCost[0];
    public BuildCost[] dropedItems = new BuildCost[0];
    public bool buildable;
    public bool dropsItems;
    public bool selectable = false; //todo

    //object info
    public Stat walkSpeed = new();
    
    public void SetName(string name) { this.name = name; }
    public void SetDescription(string description) { this.description = description; }   
    public void SetSelectable(bool value) { selectable = value; }
    public void SetHieght(float value) { height.SetValue(value); }
    public void SetMapLayer(float value) { mapLayer.SetValue(value); }
    public void SetMoisture(float value) { moisture.SetValue(value); }
    public void SetTempature(float value) { tempature.SetValue(value); }
    public void SetFertility(float value) { fertility.SetValue(value); }
    public void SetHitPoints(float value) { hitPoints.SetValue(value); }
    public void SetFlamability(float value) { flamability.SetValue(value); }
    public void SetWalkSpeed(float value) { walkSpeed.SetValue(value); }
    public void SetBiuldCost(BuildCost[] cost, bool canBiuld)
    {
        buildable = canBiuld;
        if (canBiuld)
        {
            biuldCost = cost;
        }
        else
        {
            biuldCost = null;
        }
    }
    public void SetDropedItems(BuildCost[] itemsToDrop, bool dropsItems)
    {
        this.dropsItems = dropsItems;
        if (dropsItems)
        {

            dropedItems = itemsToDrop;
        }
        else
        {
            dropedItems = null;
        }

    }

    //tile info
    public void SetSpirtes(int varients)
    {
        for (int i = 0; i < varients; i++)
        {
            if (Resources.Load<SpriteAtlas>("GraphicManger").GetSprite(this.name + "_" + i) == null)
            {
                graphics.Add(Resources.Load<SpriteAtlas>("GraphicManger").GetSprite("Default_Texture"));
            }
            else
            {
                graphics.Add(Resources.Load<SpriteAtlas>("GraphicManger").GetSprite(name + "_" + i));
            }
        }
    }
    public void SetSprites(List<Sprite> graphics) { this.graphics = graphics; }

    /*
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        //todo set up edge and those sort of tiles
        if (graphics.Count != 0)
        {
            tileData.sprite = graphics[Random.Range(0, graphics.Count)];
            tileData.color = Color.white;
            var m = tileData.transform;
            //m.SetTRS(Vector3.zero, GetRotation((byte)mask), Vector3.one);
            //tileData.transform = m;
            tileData.flags = TileFlags.LockTransform;
           // tileData.colliderType = ColliderType.None;
        }
        else
        {
            Debug.LogWarning("Not enough sprites in " + this.name +" instance");
        }
        base.GetTileData(position, tilemap, ref tileData);
    }*/
    
    public Tile GetTile()
    {
        if (graphics.Count != 0)
        {
            tile.sprite = graphics[Random.Range(0, graphics.Count)];
        }
        
        return tile;
    }
    public Tile GetTileold(int value)
    {
        tile.sprite = graphics[value];
        
        return tile;
    }

    //to do/figure out
    public BuildCost DropItem()
    {
        return dropedItems[0]; //placeholder
    }

    //to do
    public string CreateSaveFormat()
    {
        return "temp";
    }

}
