using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [Range(0.1f, 10f)]
    [SerializeField]
    private float speed = 1f;

    [Range(100, 5000)]
    [SerializeField]
    private float force = 1000f;

    [Range(2, 10)]
    [SerializeField]
    private float lifetime = 5f;

    private Rigidbody rigidBody;

    private bool active;

    public bool Active
    {
        get
        {
            this.gameObject.SetActive(true);
            return active = true;
        }
        set
        {
            active = value;
            this.gameObject.SetActive(value);
        }
    }

    private static Stack<Projectile> pool = new Stack<Projectile>();

    #region Unity
    void Awake()
    {
        active = true;
        rigidBody = GetComponent<Rigidbody>();
    }
    //public static void CreateOrTakeFromPool(GameObject projectilePrefab, Vector3 startPosition, Vector3 targetPosition)
    //{
    //    if (pool.Count > 0)
    //    {
    //        var projectileFromPool = pool.Pop();
    //        projectileFromPool.ActivateAtPosition(startPosition, targetPosition);
    //        Global.Log.MyYellowLog($" Taking bullet from pool: {projectileFromPool.GetHashCode()}");
    //    }
    //    else
    //    {
    //        var projectile = Instantiate(projectilePrefab, startPosition, Quaternion.identity);  // #todo
    //        Global.Log.MyYellowLog($" Instantiating new bullet: {projectile.GetHashCode()}");
    //        projectile.GetComponent<Projectile>().Fire(startPosition, targetPosition);
    //    }
    //}

    public static void CreateOrTakeFromPool(GameObject projectilePrefab, Transform riffle, Vector3 targetPosition)
    {
        if (pool.Count > 0)
        {
            var projectileFromPool = pool.Pop();
            projectileFromPool.ActivateAtPosition(riffle, targetPosition);
            Global.Log.MyYellowLog($" Taking bullet from pool: {projectileFromPool.GetHashCode()}");
        }
        else
        {
            var projectile = Instantiate(projectilePrefab, riffle);  // #todo
            Global.Log.MyYellowLog($" Instantiating new bullet: {projectile.GetHashCode()}");
            var projectileObject = projectile.GetComponent<Projectile>();
            projectileObject.Active = true;
            projectileObject.Fire(riffle.position, targetPosition);
        }

    }

    //private void ActivateAtPosition(Vector3 startPosition, Vector3 targetPosition)
    //{
    //    Active = true;
    //    this.transform.position = startPosition;

    //    Fire(startPosition, targetPosition);
    //}
    private void ActivateAtPosition(Transform parent, Vector3 targetPosition)
    {
        Active = true;
        // Debug.DrawLine(parent.transform.position, targetPosition, Color.blue, 3f);
        gameObject.SetActive(true);
        this.transform.position = parent.transform.position;
        Fire(parent.position, targetPosition);
    }

    private void Fire(Vector3 startPosition, Vector3 targetPosition)
    {
        rigidBody.AddForce((targetPosition - startPosition).normalized * force * speed);
        StartCoroutine(DisActivateRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        HideInPool();
    }

    private IEnumerator DisActivateRoutine()
    {
        yield return new WaitForSeconds(lifetime);

        HideInPool();
    }

    private void HideInPool()
    {
        rigidBody.velocity = Vector3.zero;
        pool.Push(this);
        Active = false;
    }

    private void OnDisable()
    {
        pool.Clear();
    }

    #endregion
}

