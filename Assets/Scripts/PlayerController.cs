using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer playerSprite;

    private PlayerControls playerControls;
    private Rigidbody rb;
    private Vector3 movement;
    //private PartyManager partyManager;

    private const string IS_WALK_PARAM = "IsWalk";
    private const float TIME_PER_STEP = 0.5f;
    private const string BATTLE_SCENE = "BattleScene";

    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        // partyManager = GameObject.FindFirstObjectByType<PartyManager>();
        // if(partyManager.GetPosition() != Vector3.zero ){
        //     transform.position = partyManager.GetPosition();
        // }
    }
    private void OnEnable()
    {
        playerControls.Enable();
        // Subscribe to the performed event of the Move action
        playerControls.Player.Move.performed += OnMovePerformed;
    }

    private void OnDisable()
    {
        // Unsubscribe from the performed event to prevent memory leaks
        playerControls.Player.Move.performed -= OnMovePerformed;
        playerControls.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        // Get the movement input value
        Vector2 movementInput = context.ReadValue<Vector2>();
        float x = movementInput.x;
        int y = 0;
        float z = movementInput.y;

        movement = new Vector3(x, y, z).normalized;
        //anim.SetBool(IS_WALK_PARAM, movement != Vector3.zero);

        // if (x != 0 && x < 0)
        // {
        //     playerSprite.flipX = true;
        // }
        // if (x != 0 && x > 0)
        // {
        //     playerSprite.flipX = false;
        // }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);

        // Collider[] colliders = Physics.OverlapSphere(transform.position, 1, grassLayer);
        // movingInGrass = colliders.Length != 0 && movement != Vector3.zero;

        // if (movingInGrass == true)
        // {
        //     stepTimer += Time.fixedDeltaTime;
        //     if (stepTimer > TIME_PER_STEP)
        //     {
        //         stepsInGrass++;
        //         stepTimer = 0;

        //         // Check to see if we have reached an encounter
        //         if (stepsInGrass >= stepsToEncounter)
        //         {
        //             partyManager.SetPosition(transform.position);
        //             SceneManager.LoadScene(BATTLE_SCENE);
        //         }

        //         // -> Change the scene
        //     }
        // }

    }

    // public void SetOverworldVisuals(Animator animator, SpriteRenderer spriteRenderer){
    //     anim = animator;
    //     playerSprite = spriteRenderer;
    // }


}
