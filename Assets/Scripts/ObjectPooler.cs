using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Code will control the objects creation.
public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    [SerializeField]
    private GameObject scenarioObject;
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    
    #region Singleton

    public static ObjectPooler Instance;

    void Awake(){
        Instance = this;

        scenarioObject = GameObject.Find("Scenario") as GameObject;
    }

    #endregion

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        //For each pool, this will create all objects
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int index = 0; index < pool.size; index++){
                GameObject _object = Instantiate(pool.prefab,scenarioObject.transform);
                _object.SetActive(false);
                objectPool.Enqueue(_object);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation){
        if(!poolDictionary.ContainsKey(tag)){
            Debug.LogWarning("Pool with tag "+ tag +" doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();

        if(pooledObject != null){
            pooledObject.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
