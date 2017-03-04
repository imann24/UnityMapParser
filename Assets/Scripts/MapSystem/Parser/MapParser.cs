﻿/*
 * Author(s): Isaiah Mann
 * Description: Parses the game world from a collection of strings
 * Usage: [no notes]
 */

using System.Collections.Generic;

using UnityEngine;

public class MapParser : Parser
{
    string joinKey = DEFAULT_JOIN_KEY;
    string delegateKey = DEFAULT_DELEGATE_KEY;
    string delegateSeparatorKey = DEFAULT_DELEGATE_SEPARATOR_KEY;

    MapTemplate template;

    Dictionary<string, GameObject> bufferedPrefabs = new Dictionary<string, GameObject>();

    protected MapTuning tuning
    {
        get
        {
            return MapTuning.Get;   
        }
    }

    #region Constructors 

    public MapParser()
    {
        MapTuning tuning = MapTuning.Get;
        joinKey = tuning.JoinKey;
        delegateKey = tuning.DelegateKey;
        template = MapTemplate.Get;
    }

    #endregion

    public MapDescriptor ParseWorld(string mapName, string[,] worldKeys) 
    {
        int width = worldKeys.GetLength(0);
        int height = worldKeys.GetLength(1);
        GameObject[,][] world = new GameObject[width, height][];
        for(int x = 0; x < width; x++) 
        {
            for(int y = 0; y < height; y++) 
            {
                string keysInCell = worldKeys[x, y];
                if(string.IsNullOrEmpty(keysInCell))
                {
                    world[x, y] = new GameObject[0];
                }
                else
                {
                    string[] keys = worldKeys[x, y].Split(joinKey.ToCharArray());
                    world[x, y] = ParseObjectsAtPosition(keys, x, y);
                }
            }
        }
        MapDescriptor descriptor = new MapDescriptor(mapName, world);
        JSONParser metaDataParser = new JSONParser();
        metaDataParser.ParseJSONOverwriteFromResources(getMetaFileName(mapName), descriptor);
        return descriptor;
    }

    GameObject[] ParseObjectsAtPosition(string[] keys, int x, int y) 
    {
        GameObject[] objectsAtPosition = new GameObject[keys.Length];
        for(int i = 0; i < objectsAtPosition.Length; i++) 
        {
            string key;
            bool hasDelegates = false;
            string[] keyPlusDelegates = null;

            if(keys[i].Contains(delegateKey))
            {
                hasDelegates = true;
                keyPlusDelegates = keys[i].Split(delegateKey.ToCharArray());
                key = keyPlusDelegates[0];
            }
            else 
            {
                key = keys[i];
            }
            key = key.Replace("\"", "");
            Debug.Log(key);
            objectsAtPosition[i] = GetPrefabFromKey(key);
            MapObjectBehaviour behaviour = objectsAtPosition[i].GetComponent<MapObjectBehaviour>();
            MapData descriptor;
            if(behaviour && template.TryGetData(key, out descriptor))
            {
                behaviour.AssignDescriptor(descriptor);
                if(hasDelegates && keyPlusDelegates != null)
                {
                    string[] delegateVals = keyPlusDelegates[1].Split(delegateSeparatorKey.ToCharArray());
                    descriptor.SetDelegates(descriptor.Delegates, delegateVals);
                }
            }
        }
        return objectsAtPosition;
    }

    GameObject GetPrefabFromKey(string key) 
    {
        GameObject obj;
        if(bufferedPrefabs.TryGetValue(key, out obj))
        {
            return obj;
        }
        else 
        {
            obj = Resources.Load<GameObject>(PrefabsPath(key));
            bufferedPrefabs.Add(key, obj);
            return obj;
        }
    }

    string getMetaFileName(string mapName)
    {
        return string.Format("{0}{1}", mapName, tuning.MetaSuffix);
    }

}
