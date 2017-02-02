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
        MapTuning tuning = MapTuning.Get;
        Debug.Log(tuning.DelegateKey);
        Debug.Log(tuning.JoinKey);
	}

}
