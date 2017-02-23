/*
 * Author(s): Isaiah Mann
 * Description: Testing parsing
 * Usage: [no notes]
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParsingTest : MonoBehaviour 
{
    [SerializeField]
    Sprite backgroundSprite;

    [SerializeField]
    CameraController activeCamera;

	// Use this for initialization
	void Start() 
	{
        CSVParser csv = new CSVParser();
        string mapName = "ComplexDemoMap";
        string[,] mapAsCSV = csv.ParseCSVFromResources(mapName);
        MapParser parser = new MapParser();
        parser.CreateWorld(mapName, mapAsCSV, transform);
        activeCamera.SetBackground(backgroundSprite);
	}

}
