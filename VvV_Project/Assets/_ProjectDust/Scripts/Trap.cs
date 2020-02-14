using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject enemy;
    public GameObject door;

    public List<Transform> spawningPoints;

    public static int enemyNumber;

    // Start is called before the first frame update
    void Start()
    {
        enemyNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //print("in");
        if (other.tag == "Player")
        {
            door.transform.position = new Vector3(-65.28f, 2.65f, 34.74f);
            if (spawningPoints.Count > 0)
            {
                foreach (Transform sp in spawningPoints)
                {
                    Instantiate(enemy, sp.position, sp.rotation);
                }
            }

            /*while(enemyNumber < 5)
            {
                int index = Random.Range(0, 3);
                Instantiate(enemy, spawningPoints[index].transform.position, Quaternion.identity);
                enemyNumber++;
            }*/
        }

        //GetComponent<BoxCollider>().isTrigger = false;
    }
}
