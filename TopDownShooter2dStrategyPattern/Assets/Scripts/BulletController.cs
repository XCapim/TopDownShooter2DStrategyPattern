using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] sbyte damage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject explosao = Instantiate(Resources.Load("Explosion", typeof(GameObject))) as GameObject;
            explosao.transform.position = transform.position;
            explosao.transform.rotation = transform.rotation;

            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
