using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float movimento;
    [SerializeField] float velocidade;
    Rigidbody2D rb2d;
    Vector3 mousePosition;
    Quaternion rotacao;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotacao = Quaternion.LookRotation(transform.position-mousePosition,Vector3.forward);

        transform.rotation = rotacao;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        movimento = Input.GetAxis("Vertical");
        rb2d.AddForce(gameObject.transform.up * movimento * velocidade);

    }
}
