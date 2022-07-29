using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private GameObject bulletObject;
    
    void Awake(){
        bulletObject = this.gameObject;
    }

    public void OnObjectSpawn(){
        //This is new Start method
    }

    void FixedUpdate(){
        BulletDefaultMovement();
    }

    void BulletDefaultMovement(){
        bulletObject.transform.position += new Vector3(10 * Time.deltaTime,0,0); 
    }

    public void DestroyBullet(){
        bulletObject.SetActive(false);
    }
}
