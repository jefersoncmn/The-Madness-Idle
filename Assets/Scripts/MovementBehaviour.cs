using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerRigidBody;
    [SerializeField]
    private Vector2 playerDirection;
    [SerializeField]
    private Player player;
    [SerializeField]
    private BoxCollider2D playerCollider;
    [SerializeField]
    private bool playerIsGround = false;
    [SerializeField]
    private float normalJumpForce = 5.0f;
    private float highJumpForce = 7.0f;


    ///BoostMovement
    
    private bool boostMovementIsActive = false;
    
    private float boostMovementDuration = 10.0f;
    
    private bool boostMovementIsLoaded = true;
    
    private float boostMovementDelayToLoad { get; set; } = 10.0f;

    public static event Action<MovementBehaviour> OnRunning;

    //
    [SerializeField]
    private double temps;

    void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        if(GameStateManager.currentGameState == GameState.Gameplay)
            return;
        MouseClickToJump();
    }

    

    void FixedUpdate(){
        if(GameStateManager.currentGameState == GameState.Gameplay)
            return;
        if(boostMovementIsActive){
            PlayerBoostMoviment();
        } else {
            PlayerDefaultMovement();
        }
        
    }

    void MouseClickToJump(){
        if (Input.GetMouseButtonDown(0)){
            temps = Time.time ;
        }

        if (Input.GetMouseButtonUp(0) && (Time.time - temps) < 0.2 )
            PlayerJumpMovement(normalJumpForce);

        if (Input.GetMouseButtonUp(0) && (Time.time - temps) > 0.2 )
            PlayerJumpMovement(highJumpForce);
    }

    ///Running function
    void PlayerDefaultMovement(){
        playerRigidBody.velocity = new Vector2(player.getPlayerSpeed(), playerRigidBody.velocity.y);
    }

    void PlayerJumpMovement(float _jumpForce){
        if(playerIsGround){
            playerIsGround = false;
            playerRigidBody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
    }

    void PlayerBoostMoviment(){
        playerRigidBody.velocity = new Vector2(player.getPlayerBoostSpeed(), playerRigidBody.velocity.y);
    }

    public void BoostMovement(){
        if(boostMovementIsActive != true && boostMovementIsLoaded == true){
            StartCoroutine(EnableBoostMovement());
            OnRunning(this);
        }
    }

    private IEnumerator EnableBoostMovement(){
        boostMovementIsActive = true;
        yield return new WaitForSeconds(boostMovementDuration);
        boostMovementIsActive = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground"){
            playerIsGround = true;
        }
        
    }

    public void setBoostMovementIsLoaded(bool value){
        boostMovementIsLoaded = value;
    }
    
    public bool getBoostMovementIsLoaded(){
        return boostMovementIsLoaded;
    }


}
