/*
 * Author(s): Isaiah Mann
 * Description: Parses JSON files
 * Usage: [no notes]
 */

using UnityEngine;

public class JSONParser : Parser
{

    public T ParseJSONFromResources<T> (string fileName) {
        string json = GetTextAssetInResources(JSONPath(fileName)).text;
        return ParseJSON<T>(json);
    }

    public T ParseJSON<T> (string json) {
        return JsonUtility.FromJson<T>(json);
    }

}
