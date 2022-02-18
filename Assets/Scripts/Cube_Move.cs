using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Move : MonoBehaviour
{
    //How fast our cube moves
    public float Speed;
    //Reference to character's RigidBody
    public Rigidbody rigidBody;
    //reference to barrel;
    public GameObject barrel;
    public GameObject bullet;
    public GameObject specialBullet;
    public GameObject aimOffset;
    public ParticleSystem muzzleFlash;
    //reference to the speed of our dash
    public float dashSpeed;
    //reference to the speed of our impact pushback
    public float recoilSpeed;
    public Animator tankAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Define a ray between camera and mouse position
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Stores the object that our raycast hits
        RaycastHit hit;

        //Casts our ray from our camera to our mouse position and stores what we hit in the hit variable
        if (Physics.Raycast(cameraRay, out hit))
        {
            //rotates our cube to look at our mouse position
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }

        if (Input.GetKey(KeyCode.W))
        {
            //adds force to our rigid body
            rigidBody.AddForce(transform.forward * Speed * Time.fixedDeltaTime);

            //We clamp our rigidBody's velocity so that it does not infinitely stack
            rigidBody.velocity = new Vector3(Mathf.Clamp(rigidBody.velocity.x, -12, 12), Mathf.Clamp(rigidBody.velocity.y, -12, 12), Mathf.Clamp(rigidBody.velocity.z, -12, 12));

            Debug.Log(rigidBody.velocity);
        }
        else
        {
            rigidBody.velocity = Vector3.zero;
        }

        //We add a Left force to our player, causing a dash to the left
        if (Input.GetKeyDown(KeyCode.A))
        {
            rigidBody.AddForce(-transform.right * dashSpeed * Time.fixedDeltaTime);//same code as line 47
        }

        //We add a Right force to our player, causing a dash to the right
        if (Input.GetKeyDown(KeyCode.D))
        {
            rigidBody.AddForce(transform.right * dashSpeed * Time.fixedDeltaTime);//same code as line 62
        }

        //Input program for shooting the bullets
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Spawn the bullet at the barrel's location and store it in a variable
            GameObject spawnBullet = Instantiate(bullet, barrel.transform.position, Quaternion.identity);

            //Rotate bullet to look at the aimOffset game object
            Vector3 relativePosition = aimOffset.transform.position - spawnBullet.transform.position;
            Quaternion Rotation = Quaternion.LookRotation(relativePosition, Vector3.forward);
            spawnBullet.transform.rotation = Rotation;

            //we get our Bullet RigidBody and we add a force in the forward direction
            spawnBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 4000);
            
            //Plays the Muzzle Flash particle effect
            muzzleFlash.Play();

            //plays the kickback aesthetic from shooting
            rigidBody.AddForce(-transform.forward * recoilSpeed * Time.fixedDeltaTime);

            //Triggers attack animation when left mouse is clicked
            tankAnimator.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //Spawn the bullet at the barrel's location and store it in a variable
            GameObject spawnBullet = Instantiate(specialBullet, barrel.transform.position, Quaternion.identity);//same code as line 75

            //Rotate bullet to look at the aimOffset game object
            Vector3 relativePosition = aimOffset.transform.position - spawnBullet.transform.position;
            Quaternion Rotation = Quaternion.LookRotation(relativePosition, Vector3.forward);//same code as line 79
            spawnBullet.transform.rotation = Rotation;//same code as line 80

            //we get our Bullet RigidBody and we add a force in the forward direction
            spawnBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 4000);//same code as line 83

            //Plays the Muzzle Flash particle effect
            muzzleFlash.Play();//same code as line 86

            //plays the kickback aesthetic from shooting
            rigidBody.AddForce(-transform.forward * recoilSpeed * Time.fixedDeltaTime);//same code as line 89

            //Triggers attack animation when left mouse is clicked
            tankAnimator.SetTrigger("Attack");//same code as line 92
        }

    }
}
