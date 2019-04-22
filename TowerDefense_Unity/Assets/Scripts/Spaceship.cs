using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private void Update() {
        Collider[] colliders = Physics.OverlapBox(transform.position, Vector3.one * .5f);
        
        for (int i = 0; i < colliders.Length; i++) {
            Enemy enemy = colliders[i].GetComponent<Enemy>();
            if (enemy != null) {
                Destroy(enemy.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        
    }
}
