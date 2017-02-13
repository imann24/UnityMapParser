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
	// Use this for initialization
	void Start() 
	{
        CSVParser csv = new CSVParser();
        string[,] mapAsCSV = csv.ParseCSVFromResources("DemoMap");
        MapParser parser = new MapParser();
        parser.CreateWorld(mapAsCSV, transform);
	}

}
