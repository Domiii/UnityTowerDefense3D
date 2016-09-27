using UnityEngine;
using System.Collections;



/// <summary>
/// Run-time instantiations of GameObjects
/// should be managed by the GameObjectManager
/// </summary>
public class GameObjectManager : MonoBehaviour
{
    public static GameObjectManager Instance
    {
        get;
        private set;
    }

    public GameObjectManager()
    {
        Instance = this;
    }

    public GameObject Obtain(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        // TODO: Implement GO recycling
        var go = (GameObject)Instantiate(prefab, position, rotation);
        return go;
    }

    public GameObject ObtainEmpty(string name, Vector3 position, Quaternion rotation)
    {
        // TODO: Implement GO recycling
        var go = new GameObject(name);
        go.transform.position = position;
        go.transform.rotation = rotation;
        return go;
    }

    public void Recycle(GameObject obj)
    {
        // TODO: Implement GO recycling (use special pool for empty's)
        GameObject.Destroy(obj);
    }

    public T AddComponent<T>(GameObject go)
        where T : MonoBehaviour, IPooledObject
    {
        return go.AddComponent<T>();
    }

    public void RemoveComponent<T>(T component)
        where T : MonoBehaviour, IPooledObject
    {
        Destroy(component);
    }
}
