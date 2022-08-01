using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestKeySpawnerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject chestKeyPrefab;
    [SerializeField]
    private float positionY;
    [SerializeField]
    private GameObject cameraObject;
    [SerializeField]
    private GameObject scenarioObject;

    ObjectPooler objectPooler;

    void Awake(){
        chestKeyPrefab = Resources.Load<GameObject>("Prefabs/ChestKey");
        cameraObject = GameObject.Find("Main Camera") as GameObject;
        scenarioObject = GameObject.Find("Scenario") as GameObject;

        positionY = 4;
    }

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        InvokeRepeating("SpawnChestKey", 2.0f, 1.0f);
    }

    void SpawnChestKey(){
        if(GameStateManager.currentGameState == GameState.Gameplay)
            return;
        var position = new Vector3(cameraObject.transform.position.x+15, positionY, 0);
        objectPooler.SpawnFromPool("ChestKey", position, Quaternion.identity);
    }
}
