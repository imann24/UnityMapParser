/*
 * Author(s): Isaiah Mann
 * Description: [to be added]
 * Usage: [no notes]
 */

using UnityEngine;

public class MapTuning : Tuning<MapTuning>
{
    #region Instance Accessors 

    public string JoinKey
    {
        get
        {
            return joinKey;
        }
    }

    public string DelegateKey
    {
        get
        {
            return delegateKey;
        }
    }
        
    #endregion

    protected override string fileName 
    {
        get 
        {
            return MapGlobal.MAP_TUNING;
        }
    }

    [SerializeField]
    string joinKey;
    [SerializeField]
    string delegateKey;

}
