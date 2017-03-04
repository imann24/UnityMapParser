/*
 * Author(s): Isaiah Mann
 * Description: Generic data class for the map
 * Usage: [no notes]
 */

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

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

    public string[] Delegates
    {
        get
        {
            return delegates;
        }
    }
        
    public bool IsSolid
    {
        get
        {
            return isSolid;
        }
    }

    public bool IsPortal
    {
        get
        {
            return isPortal;
        }
    }

    #endregion

    [SerializeField]
    string key;
    [SerializeField]
    string name;
    [SerializeField]
    string[] delegates;
    [SerializeField]
    bool isSolid;
    [SerializeField]
    bool isPortal;

    Dictionary<string, object> delegateLookup;

    public void SetDelegates(string[] keys, object[] vals)
    {
        delegateLookup = new Dictionary<string, object>();
        for(int i = 0; i < keys.Length; i++)
        {
            delegateLookup.Add(keys[i], vals[i]);
        }
    }

    public bool HasDelegate(string delegateId)
    {
        return DelegateValue(delegateId) != null;
    }

    public object DelegateValue(string delegateId)
    {
        object val;
        if(delegateLookup.TryGetValue(delegateId, out val))
        {
            return val;
        }
        else 
        {
            return null;
        }
    }

    public string DelegateStr(string deleateId)
    {
        return DelegateValue(deleateId).ToString();
    }

    // Adapted from http://stackoverflow.com/questions/1031023/copy-a-class-c-sharp
    public MapData Copy() {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, this);
            memoryStream.Position = 0;
            return formatter.Deserialize(memoryStream) as MapData;
        }
    }

}
