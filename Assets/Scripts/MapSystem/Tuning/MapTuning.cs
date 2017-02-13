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

    public string DelegateSeparator
    {
        get
        {
            return delegateSeparator;
        }
    }

    public float CharacterMoveSpeed
    {
        get
        {
            return characterMoveSpeed;
        }
    }

    public float CharacterJumpSpeed
    {
        get
        {
            return characterJumpSpeed;
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
    [SerializeField]
    string delegateSeparator;
    [SerializeField]
    float characterMoveSpeed;
    [SerializeField]
    float characterJumpSpeed;

}
