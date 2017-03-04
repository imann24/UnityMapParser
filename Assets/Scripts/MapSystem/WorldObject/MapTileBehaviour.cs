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

    #region MapObjectBehaviour Overrides 

    public override void Initialize()
    {
        base.Initialize();
        if(GetTile.IsClimbable)
        {
            gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    #endregion

}
