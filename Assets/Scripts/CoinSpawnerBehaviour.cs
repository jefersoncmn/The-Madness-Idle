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

    void Awake(){
        coinPrefab = Resources.Load<GameObject>("Prefabs/Coin");
        cameraObject = GameObject.Find("Main Camera") as GameObject;
        scenarioObject = GameObject.Find("Scenario") as GameObject;

        verticalRange = new float[]{3, 6};
    }

    void Start()
    {
        InvokeRepeating("SpawnCoin", 2.0f, 1.0f);
    }

    void SpawnCoin(){
        var position = new Vector3(cameraObject.transform.position.x+15, Random.Range(verticalRange[0],verticalRange[1]), 0);
        Instantiate(coinPrefab, position, Quaternion.identity, scenarioObject.transform);
    }
}
