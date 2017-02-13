/*
 * Author(s): Isaiah Mann
 * Description: Describes the behaviour of an object on the map
 * Usage: [no notes]
 */

using UnityEngine;

public abstract class MapObjectBehaviour : MonoBehaviour
{
    public MapData Descriptor
    {
        get
        {
            return this.descriptor;
        }
    }

    MapData descriptor;

    public void AssignDescriptor(MapData descriptor)
    {
        this.descriptor = descriptor;
    }

    public MapData CopyDescriptor()
    {
        return this.descriptor.Copy();
    }
        
    public virtual void Initialize()
    {
        if(Descriptor.IsSolid)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }
    }


}
