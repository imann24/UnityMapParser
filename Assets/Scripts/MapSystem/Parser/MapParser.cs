/*
 * Author(s): Isaiah Mann
 * Description: Parses the game world from a collection of strings
 * Usage: [no notes]
 */

using UnityEngine;
using System.Collections.Generic;

public class MapParser : Parser
{
    char joinChar = DEFAULT_JOIN_CHAR;

    Dictionary<string, GameObject> bufferedPrefabs = new Dictionary<string, GameObject>();

    public void SetJoinChar (char joinChar) {
        this.joinChar = joinChar;
    }

    public GameObject[,][] ParseWorld (string[,] worldKeys) {
        int width = worldKeys.GetLength(0);
        int height = worldKeys.GetLength(1);
        GameObject[,][] world = new GameObject[width, height][];
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                string[] keys = worldKeys[x, y].Split(joinChar);
                world[x, y] = ParseObjectsAtPosition(keys, x, y);
            }
        }
        return world;
    }

    GameObject[] ParseObjectsAtPosition (string[] keys, int x, int y) {
        GameObject[] objectsAtPosition = new GameObject[keys.Length];
        for (int i = 0; i < objectsAtPosition.Length; i++) {
            objectsAtPosition[i] = GetPrefabFromKey(keys[i]);
        }
        return objectsAtPosition;
    }

    GameObject GetPrefabFromKey (string key) {
        return Resources.Load<GameObject>(PrefabsPath(key));
    }
}
