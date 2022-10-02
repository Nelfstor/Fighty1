using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WayController : MonoBehaviour
{
    [SerializeField]
    List<WayPoint> wayPoints;

    PlayerController playerController;    

    private int currentWayPointndex = 0;

    #region Unity
    void Awake()
    {
        var player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        playerController.locationFinished.AddListener(GoToNext);

        foreach(var wayPoint in wayPoints)
        {
            wayPoint.locationFinished += OnLocationFinished;
        }        
    }

    private void OnLocationFinished(WayPoint sender)
    {
        sender.locationFinished -= OnLocationFinished;
        GoToNext();
    }

    private void GoToNext()
	{
        currentWayPointndex++;
        if (currentWayPointndex == wayPoints.Count)
        {
            Global.Log.MyGreenLog("Last Way Point Done");
            // SceneManager.UnloadSceneAsync(0);
            SceneManager.LoadScene(0);
        }
        else
        {
            int index = currentWayPointndex % (wayPoints.Count);
            var currentWayPoint = wayPoints[index];
            if (currentWayPoint.ViewPoint != null)
            {
                playerController.MoveToNextWaypoint(currentWayPoint.Position, currentWayPoint.ViewPoint);
            }
            else
            {
                playerController.MoveToNextWaypoint(currentWayPoint.Position);
            }
        }

    }
	#endregion
}
