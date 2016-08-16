using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;
    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    void Start() {
        animator = GameObject.FindObjectOfType<Animator>();

        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent) {
            projectileParent = new GameObject("Projectiles");
        }
        SetMyLaneSpawner();
        print(myLaneSpawner);
    }

    void Update() {
        if (AttackerAhead()){
            animator.SetBool("isAttacking", true);
        }
        else {
            animator.SetBool("isAttacking", false);
        }
    }

    // assign this defender an adjacant spawner
    void SetMyLaneSpawner() {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawnerArray) {
            if (spawner.transform.position.y == transform.position.y) {
                myLaneSpawner = spawner;
                return;
            }
        }
        Debug.LogError(name + " can't find spawner in lane");
    }

    bool AttackerAhead() {
        //Exit if no attackers in late
        if (myLaneSpawner.transform.childCount <= 0) {
            return false;
        }

        // Check if attackers are ahead
        foreach (Transform attacker in myLaneSpawner.transform) {
            if (attacker.transform.position.x >= transform.position.x) {
                return true;
            }
        }

        // Attackers in lane but already has passed
        return false;
    }

    private void Fire() {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
