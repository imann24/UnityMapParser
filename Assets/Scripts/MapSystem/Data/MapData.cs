/*
 * Author(s): Isaiah Mann
 * Description: Generic data class for the map
 * Usage: [no notes]
 */

using UnityEngine;

using k = MapGlobal;

[System.Serializable]
public abstract class MapData 
{
    #region Instance Accessors

    public string Key
    {
        get
        {
            return key;
        }
    }
    public string Name
    {
        get
        {
            return name;
        }
    }

    #endregion

    [SerializeField]
    string key;
    [SerializeField]
    string name;

}
