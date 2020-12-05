using UnityEngine;
using System.Collections;

public class WallCheck : MonoBehaviour
{
    Camera cam;
    public GameObject[] openings;
    public bool canWalkThroughNextWall;

    public static bool canWalk;

    void Start()
    {
        cam = GetComponent<Camera>();
        Invoke("CheckWalk", 2f);
    }

    void CheckWalk()
    {
        openings = GameObject.FindGameObjectsWithTag("CanWalkThrough");

    }

    public void CheckWalls()
    {

        Vector3 viewPos = cam.WorldToViewportPoint(openings[0].transform.position);

        if (viewPos.z > 0.5F)
        {
            print("target is in front");
            canWalkThroughNextWall = true;
        }
        else
        {
            print("target is in not front");
            canWalkThroughNextWall = false;
        }

    }
}