using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject coinPrefab;
    [SerializeField]
    private float[] verticalRange;
    [SerializeField]
    private GameObject cameraObject;
    [SerializeField]
    private GameObject scenarioObject;

    ObjectPooler objectPooler;

    void Awake(){
        coinPrefab = Resources.Load<GameObject>("Prefabs/Coin");
        cameraObject = GameObject.Find("Main Camera") as GameObject;
        scenarioObject = GameObject.Find("Scenario") as GameObject;

        verticalRange = new float[]{3, 6};
    }

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        InvokeRepeating("SpawnCoin", 2.0f, 1.0f);
    }

    void SpawnCoin(){
        var position = new Vector3(cameraObject.transform.position.x+15, Random.Range(verticalRange[0],verticalRange[1]), 0);
        objectPooler.SpawnFromPool("Coin", position, Quaternion.identity);
    }
}
