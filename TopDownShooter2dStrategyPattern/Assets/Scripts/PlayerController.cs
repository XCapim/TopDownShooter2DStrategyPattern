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
    IArma arma;
    [SerializeField] string NomeArma;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ConfiguraArma(NomeArma);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            arma.Atirar();
        }
        
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

    public void ConfiguraArma(string tag)
    {
        switch (tag)
        {
            case "Pickup":
                RemoveArma();
                this.arma = gameObject.AddComponent<TiroSimples>();
                break;

            case "UFO":
                RemoveArma();
                this.arma = gameObject.AddComponent<TiroRaycast>();
                break;

            case "NovoTiro":
                RemoveArma();
                this.arma = gameObject.AddComponent<NovoTiro>();
                break;

            default:
                break;
        }
    }

    void RemoveArma()
    {

        //Para evitar a criacao de multiplos components do mesmo tipo no gameObject

        Component c = gameObject.GetComponent<IArma>() as Component;
        if (c != null) Destroy(c);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(!collision.CompareTag("Enemy"))
        ConfiguraArma(collision.tag);
    }
}
