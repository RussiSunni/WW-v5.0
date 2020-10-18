using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;

    // 1 - need bottom door
    // 2 - need top door
    // 3 - need left door
    // 4 - need right door

    private RoomTemplates templates;
    private int rand;
    public bool spawned;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        // Debug.Log("test");
        if (spawned == false)
        {
            // Debug.Log("test");

            if (openingDirection == 1)
            {
                //spawn room with bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //spawn room with top door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //spawn room with left door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //spawn room with right door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //   Debug.Log(other.gameObject.name + " : " + gameObject.name);

        if (other.CompareTag("Spawn Point"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {

            }

            Destroy(gameObject);
        }
    }
}
