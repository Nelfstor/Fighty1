using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void LocationFinished(WayPoint sender);
public class WayPoint : MonoBehaviour
{
    //private Vector3 position;
    //public event UnityAction locationFinished;
    public event LocationFinished locationFinished;

    private GameObject? viewPoint;
    public GameObject ViewPoint => viewPoint;

    

    public Vector3 Position => transform.position;

    [SerializeField]
    private List<EnemyController> enemyList = new List<EnemyController>();

    private int NPCleft;

    private void Start()
    {
        var viewPointSource = transform.Find("ViewPoint");
        if (viewPointSource != null)  viewPoint = viewPointSource.gameObject;

        NPCleft = enemyList.Count;
        foreach(var NPC in enemyList)
        {
            NPC.killed += OnNPCDead;
        }
        
    }

    private void OnNPCDead(EnemyController enemy)
    {
        Global.Log.MyCyanLog($"OnNPCDead || NPCleft = {NPCleft}");
        enemy.killed -= OnNPCDead;
        if (--NPCleft == 0)
        {
            locationFinished.Invoke(this);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }

}
