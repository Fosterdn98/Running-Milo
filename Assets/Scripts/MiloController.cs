using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiloController : MonoBehaviour {

	private Rigidbody2D myRigidBody;
    private float startTime;
    public int jumpsLeft = 2;
	public float bunnyJumpForce = 500f;
    public Text scoreText;
	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
        startTime = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Title");
        }
		if ((Input.GetButtonUp ("Jump") || Input.GetButtonUp("Fire1")) && jumpsLeft > 0) {
            if(myRigidBody.velocity.y < 0)
            {
                myRigidBody.velocity = Vector2.zero;
            }
            if (jumpsLeft == 1)
            {
                myRigidBody.AddForce(transform.up * bunnyJumpForce *0.75f);
            }
            else
            {
                myRigidBody.AddForce(transform.up * bunnyJumpForce);
            }
			
            jumpsLeft--;
		}
        scoreText.text = (Time.time - startTime).ToString("0.0");
    }
	void OnCollisionEnter2D(Collision2D collison){
		if (collison.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
            
             Application.LoadLevel("Title");
            
			
		}
        else if (collison.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            jumpsLeft = 2;
        }
	}
}
