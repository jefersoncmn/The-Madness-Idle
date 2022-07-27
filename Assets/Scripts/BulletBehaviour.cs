using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletObject;
    
    void Awake(){
        bulletObject = this.gameObject;
    }

    void FixedUpdate(){
        BulletDefaultMovement();
    }

    void BulletDefaultMovement(){
        bulletObject.transform.position += new Vector3(10 * Time.deltaTime,0,0); 
    }
}
