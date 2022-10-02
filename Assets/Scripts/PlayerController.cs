using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private State currentState;

    [SerializeField]
    private GameObject currentWeaponPrefab;

    private Weapon currentWeapon;

    [HideInInspector]
    public UnityEvent locationFinished;
    public State CurrentState => currentState;

    // Animation + models
    AnimatorController animatorController;
    GameObject character;

    // Controls    
    PlayerInput inputActions;

    // Navigation
    Camera mainCamera;
    NavMeshAgent navMeshAgent;
    Vector3 targetPosition;
    GameObject viewPoint;

    LayerMask rayCastMask;

    private float rotationSpeed = 1f;
    private bool rotating = false;

    public enum State
    {
        shooting,
        moving,
        disabled,
        idle
    }

    #region Unity
    void Awake()
    {
        Global.Log.MyGreenLog(" PC.OnAwake");

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;

        animatorController = GetComponentInChildren<AnimatorController>();

        inputActions = new PlayerInput();
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += OnFingerDown;

        // Ordinary Input System
        /*inputActions.Main.MouseClick.performed += OnTap;
        inputActions.Main.TouchTap.started += OnTap;*/

        //Setting Weapon
        var weaponSlot = GameObject.Find("PlayerWeapon").transform;
        Instantiate(currentWeaponPrefab, weaponSlot);
        Global.Log.MyGreenLog("Weapon Instantiated");

        currentWeapon = currentWeaponPrefab.GetComponent<Weapon>();

        character = transform.Find("Character").gameObject;

        mainCamera = Camera.main;
        rayCastMask = LayerMask.GetMask("Shootable");

        SetState(State.idle);
    }

    #endregion

    #region Events
    // Ordinary Event Callback

    //void OnTap(InputAction.CallbackContext callbackContext)
    //{
    //	Global.Log.MyGreenLog($"OnTap || callbackContext = {callbackContext}");
    //	if (currentState == State.idle)
    //	{
    //		Global.Log.MyGreenLog("Location Finished Invoke");
    //		locationFinished.Invoke();			
    //	}
    //	else if ( currentState == State.shooting)
    //	{
    //		//Shoot(); // #toDo Get TAP coordinates
    //	}
    //}

    // Enhanced input callback
    void OnFingerDown(Finger finger)
    {
        if (InScreen(finger.screenPosition))
        {
            //Global.Log.MyGreenLog($"OnFingerDown || Screen: {Screen.width}x{Screen.height} || finger X = {finger.screenPosition.x}");
            if (currentState == State.idle)
            {
                // Global.Log.MyGreenLog("Location Finished Invoke");
                locationFinished.Invoke();
            }
            else if (currentState == State.shooting)
            {
                Shoot(finger.screenPosition);
            }
        }
    }

    private bool InScreen(Vector2 position)
    {
        if (position.x > 0 && position.x < Screen.width && position.y > 0 && position.y < Screen.height)
            return true;
        else return false;
    }

    private void OnDisable()
    {
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= OnFingerDown;
        //  EnhancedTouchSupport.Enable();
        //  TouchSimulation.Disable();
    }

    #endregion

    public void MoveToNextWaypoint(Vector3 targetPosition, GameObject viewPoint = null)
    {
        this.targetPosition = targetPosition;
        navMeshAgent.destination = targetPosition;

        if (viewPoint != null)
        {
            rotating = true;
            this.viewPoint = viewPoint;
        }
        else
        {
            rotating = false;
        }
        SetState(State.moving);
    }

    void SetState(State state)
    {
        Global.Log.MyGreenLog($"Setting State {state}");
        currentState = state;
        switch (state)
        {
            case State.moving:
                animatorController.RunAnimation();
                navMeshAgent.isStopped = false;
                inputActions.Main.Disable();
                break;
            case State.shooting:
                navMeshAgent.isStopped = true;
                animatorController.StopRun();
                inputActions.Main.Enable();
                break;
            case State.idle:
                inputActions.Main.Enable();
                navMeshAgent.isStopped = true;
                break;
            default:
                throw new System.ArgumentException();
        }
    }

    public void Shoot(Vector2 tapPosition)
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(tapPosition.x, tapPosition.y, 0));

        RaycastHit hit;
        Vector3 target;
        if (Physics.Raycast(ray, out hit, 200f, rayCastMask))
        {
            target = hit.point;
        }
        else
        {
            target = ray.GetPoint(1000);
        }
        currentWeapon.Fire(target);
        character.transform.LookAt(new Vector3(target.x, character.transform.position.y, target.z));
    }

    private void Update()
    {
        if (currentState == State.moving)
        {
            if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                SetState(State.shooting);
            }
            if (rotating)
            {
                Quaternion lookDirection = Quaternion.LookRotation(viewPoint.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, rotationSpeed * Time.deltaTime);
            }
        }
    }
}

