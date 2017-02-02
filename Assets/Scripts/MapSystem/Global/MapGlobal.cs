﻿/*
 * Author(s): Isaiah Mann
 * Description: Global constants for the map system
 * Usage: [no notes]
 */

using System.IO;

public class MapGlobal : Global
{
    public const string MAP_DATA = "MapData";
    public const string MAP_TUNING = "MapTuning";

    #region Static Accessors

    public static string MAP_DATA_PATH
    {
        get
        {
            return Path.Combine(JSON_DIR, MAP_DATA);
        }
    }

    public static string MAP_TUNING_PATH
    {
        get
        {
            return Path.Combine(JSON_DIR, MAP_TUNING);
        }
    }

    #endregion

}
