﻿/*
 * Author(s): Isaiah Mann
 * Description: Items placed on the map
 * Usage: [no notes]
 */

using UnityEngine;

[System.Serializable]
public class MapItem : MapData
{
    #region Instance Accessors

    public bool Collectible
    {
        get
        {
            return collectible;
        }
    }

    #endregion

    [SerializeField]
    bool collectible;

}
