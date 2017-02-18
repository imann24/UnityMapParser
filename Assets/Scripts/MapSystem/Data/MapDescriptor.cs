/*
 * Author(s): Isaiah Mann
 * Description: Describes a map in pure data that can be loaded in
 * Usage: [no notes]
 */

using UnityEngine;

public class MapDescriptor 
{
    public string BackgroundSprite
    {
        get
        {
            return backgroundSprite;
        }
    }

    public MapData[,][] Map 
    {
        get 
        {
            return _map;
        }
        set
        {
            _map = value;
        }
        
    }


    [SerializeField]
    string backgroundSprite;
   
    MapData[,][] _map;

}
