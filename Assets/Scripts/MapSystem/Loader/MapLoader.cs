/*
 * Author(s): Isaiah Mann
 * Description: Spawns the map
 * Usage: [no notes]
 */

using UnityEngine;

public class MapLoader : Loader
{
    public void CreateWorld(MapDescriptor descriptor, CameraController camera, Transform parent)
    {
        GameObject[,][] worldTemplate = descriptor.Map;
        for(int x = 0; x < worldTemplate.GetLength(0); x++) 
        {
            for(int y = 0; y < worldTemplate.GetLength(1); y++)
            {
                foreach(GameObject mapObj in worldTemplate[x, y])
                {
                    MapObjectBehaviour behaviour = Object.Instantiate(mapObj, new Vector3(x, y), Quaternion.identity).GetComponent<MapObjectBehaviour>();
                    behaviour.transform.SetParent(parent);
                    behaviour.AssignDescriptor(mapObj.GetComponent<MapObjectBehaviour>().CopyDescriptor());
                    behaviour.Initialize();
                }
            }
        }
        Sprite background = new SpriteLoader().Load(descriptor.BackgroundSprite);
        camera.SetBackground(background);
    }
        
}
