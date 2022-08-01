using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject playerObject;
    [SerializeField]
    private GameObject scenarioObject;
    
    ObjectPooler objectPooler;

    void Awake(){
        playerObject = this.gameObject;
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
        scenarioObject = GameObject.Find("Scenario") as GameObject;
    }

    void Start(){
        objectPooler = ObjectPooler.Instance;
    }

    void Update(){
        if(GameStateManager.currentGameState == GameState.Gameplay)
            return;
        if (Input.GetMouseButtonDown(0)){
            Shoot();
        }
    }

    void Shoot(){
        objectPooler.SpawnFromPool("Bullet", playerObject.transform.position, Quaternion.identity);
        
    }
}
