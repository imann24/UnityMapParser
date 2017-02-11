/*
 * Author(s): Isaiah Mann
 * Description: [to be added]
 * Usage: [no notes]
 */

using UnityEngine;

[System.Serializable]
public class MapTemplate : MapData
{
    #region Instances Accessors 

    public MapUnit[] Units
    {
        get
        {
            return units;
        }
    }
    public MapTile[] Tiles
    {
        get
        {
            return tiles;
        }
    }
    public MapItem[] Items
    {
        get
        {
            return items;
        }
    }

    #endregion

    [SerializeField]
    MapUnit[] units;
    [SerializeField]
    MapTile[] tiles;
    [SerializeField]
    MapItem[] items;

}
