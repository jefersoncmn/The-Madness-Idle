using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class will be in the ButtonBoostMovement
public class ButtonBoostMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private Image buttonBoostMovementImage;
    [SerializeField]
    private float boostMovementDelayToLoad;

    void Awake(){
        buttonBoostMovementImage = transform.Find("LoadingImage").GetComponent<Image>();
        MovementBehaviour.OnRunning += ButtonBoostMovementSetLoader;
    }
    
    void ButtonBoostMovementSetLoader(MovementBehaviour movementBehaviour){
        StartCoroutine(LoadingButtonBoostMovement(movementBehaviour));
    }

    IEnumerator LoadingButtonBoostMovement(MovementBehaviour movementBehaviour){
        float time = 0.0f;

        movementBehaviour.setBoostMovementIsLoaded(false);
        
        while (!movementBehaviour.getBoostMovementIsLoaded()){
            time += 10f * Time.deltaTime;
            buttonBoostMovementImage.fillAmount = Mathf.Lerp (0f, 10f, time/100);
            if(time >= 10f){
                buttonBoostMovementImage.fillAmount = 0f;
                time = 0f;
                movementBehaviour.setBoostMovementIsLoaded(true);
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
