using UnityEngine;
using System.Collections;

public class DestroyEnemy : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("working");
        Destroy(other.gameObject);
    }
}
