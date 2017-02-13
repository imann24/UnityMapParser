/*
 * Author(s): Isaiah Mann
 * Description: [to be added]
 * Usage: [no notes]
 */

using UnityEngine;

public class MapTileBehaviour : MapObjectBehaviour
{
    public MapTile GetTile 
    {
        get 
        {
            return this.Descriptor as MapTile;
        }
    }

}
