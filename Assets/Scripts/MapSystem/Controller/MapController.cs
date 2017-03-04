﻿/*
 * Author(s): Isaiah Mann
 * Description: Controls the map
 * Usage: [no notes]
 */

using System.Collections.Generic;
using UnityEngine;

// Dependency class to manage the portals:
[RequireComponent(typeof(PortalController))]
    
public class MapController : Controller 
{
    [SerializeField]
    string startingMapName;

    [SerializeField]
    bool createMapOnStart = true;

    CameraController cam;
    PortalController portals;

    MapDescriptor currentMap;
    Dictionary<string, MapDescriptor> mapBuffer = new Dictionary<string, MapDescriptor>();

    public MapDescriptor PeekMap()
    {
        return this.currentMap;
    }

    protected override void Awake()
    {
        base.Awake();
        this.portals = GetComponent<PortalController>();
    }

    void Start() 
    {
        this.cam = CameraController.Get;
        this.currentMap = parseMap(startingMapName);
        if(createMapOnStart)
        {
            createMap(currentMap);
        }
    }

    public bool TryChangeMap(string name)
    {
        MapDescriptor map;
        if(tryGetMap(name, out map))
        {
            teardownMap();
            createMap(map);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void HandlePortalEnter(MapObjectBehaviour target, MapObjectBehaviour portal)
    {
        portals.HandlePortalEnter(target, portal);    
    }

    void createMap(MapDescriptor map)
    {
        setMap(map);
        new MapLoader().CreateWorld(map, this, portals, cam, transform);
    }

    void setMap(MapDescriptor map)
    {
        this.currentMap = map;
    }

    MapDescriptor parseMap(string mapName)
    {
        CSVParser csv = new CSVParser();
        string[,] mapAsCSV = csv.ParseCSVFromResources(mapName);
        MapDescriptor descriptor = new MapParser().ParseWorld(mapName, mapAsCSV);
        trackMap(descriptor);
        return descriptor;
    }

    // Overwrites any existing map in the lookup
    void trackMap(MapDescriptor descriptor)
    {
        if(mapBuffer.ContainsKey(descriptor.MapName))
        {
            mapBuffer[descriptor.MapName] = descriptor;
        }
        else
        {
            mapBuffer.Add(descriptor.MapName, descriptor);
        }
    }

    bool tryGetMap(string mapName, out MapDescriptor descriptor)
    {
        return mapBuffer.TryGetValue(mapName, out descriptor);
    }

    void teardownMap()
    {
        portals.ClearActivePortals();
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
        
}
