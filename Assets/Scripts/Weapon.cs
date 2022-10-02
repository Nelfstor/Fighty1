using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private GameObject riffle;

    private Camera mainCamera;

    bool init = false;
    bool initRifle = false;

    #region Unity
    public void Awake()
    {
       // Global.Log.MyGreenLog($" Weapon.Awake || Weapon Hash: {this.GetHashCode()}");
       // Global.Log.MyGreenLog($" Weapon.Awake || Riffle Hash: {riffle.GetHashCode()}");
    }
    #endregion
    
    private void Init()
    {
        mainCamera = Camera.main;
        
    }

    public void Fire(Vector3 targetPosition)
    {
        if (!init)
        {
            Init();
            init = true;
        }
       // if (!initRifle)
        {
            riffle = GameObject.Find("Riffle").gameObject; // For some reason it creates wrong version in Awake or Start;
            initRifle = true;
        }

        // Global.Log.MyGreenLog($" Weapon.Fire || Riffle Hash: {riffle.GetHashCode()}");

        Projectile.CreateOrTakeFromPool(projectilePrefab, riffle.transform, targetPosition);
    }
    
}
