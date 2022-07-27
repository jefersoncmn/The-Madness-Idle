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

    void Awake(){
        playerObject = this.gameObject;
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
        scenarioObject = GameObject.Find("Scenario") as GameObject;
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            Shoot();
        }
    }

    void Shoot(){
        Instantiate(bulletPrefab, playerObject.transform.position, Quaternion.identity, scenarioObject.transform);
    }
}
