/*
 * Author(s): Isaiah Mann
 * Description: Base class for parsing text
 * Usage: [no notes]
 */

using System.IO;
using UnityEngine;

public abstract class Parser 
{
    const string JSON_DIR = "JSON";
    const string CSV_DIR = "CSV";
    const string PREFABS_DIR = "Prefabs";

    protected const char DEFAULT_JOIN_CHAR = '+';

    protected TextAsset GetTextAssetInResources (string path) {
        return Resources.Load<TextAsset>(path);
    }

    protected string JSONPath (string fileName) {
        return Path.Combine(JSON_DIR, fileName);
    }

    protected string CSVPath (string fileName) {
        return Path.Combine(CSV_DIR, fileName);
    }
        
    protected string PrefabsPath (string fileName) {
        return Path.Combine(PREFABS_DIR, fileName);
    }
}
