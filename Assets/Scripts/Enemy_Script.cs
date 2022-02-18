using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Script : MonoBehaviour
{
    //Reference to our enemies' NavMesh Agent component
    public NavMeshAgent cylinderAgent;
    //Reference to the Player cube
    public GameObject playerCube;
    public GameObject aoePrefab;
    //Current HP
    public int HP;
    // Start is called before the first frame update
    void Start()
    {
        //If Player does not have value, find it.
        if (playerCube == null)
        {
            playerCube = GameObject.Find("Player");
        }
        //NavMesh agent is given random speed.
        cylinderAgent.speed = Random.Range(2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //Chases after the player
        cylinderAgent.SetDestination(playerCube.transform.position);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Check if enemy has been hit by a bullet.
        if (collision.gameObject.tag == "Bullet")
        {
            //Minus HP
            HP -= 10;

            //If enemy's HP is less than or equal to 0, we destroy it.
            if (HP <= 0)
            {
                Destroy(this.gameObject);
            }

            //We destroy our bullet on impact
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Special Bullet")
        {
            Instantiate(aoePrefab, collision.gameObject.transform.position, Quaternion.identity);

            //Minus HP
            HP -= 20;

            //If enemy's HP is less than or equal to 0, we destroy it.
            if (HP <= 0)
            {
                Destroy(this.gameObject);//same text as line 43
            }

            //We destroy our bullet on impact
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.tag == "AoE")
        {
            Destroy(this.gameObject);//same text as line 61
        }
    }

}
