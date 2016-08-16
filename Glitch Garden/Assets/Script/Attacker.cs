using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip ("Average number of seconds between appearances")]
    public float seenEverySeconds;
    private float currentSpeed;
    private GameObject currentTarget;
    private Animator anim;
	

    void Start() {
        anim = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget) {
            anim.SetBool("isAttacking", false);
        }
	}

    void OnTriggerEnter2D() {

    }

    public void SetSpeed(float speed) {
        currentSpeed = speed;
    }

    // Called from the animator at the time of the actual blow
    public void StrikeCurrentTarget(float damage) {
        if (currentTarget) {
            Health health = currentTarget.GetComponent<Health>();
            if (health) {
                Debug.Log(gameObject + " Dealing Damage: " + damage);
                health.DealDamage(damage);
            }
        }
    }

    // puts Attacker into attack mode
    public void Attack(GameObject obj) {
        currentTarget = obj;
    }

}
