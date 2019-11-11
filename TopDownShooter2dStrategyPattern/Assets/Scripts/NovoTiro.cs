using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovoTiro :Arma, IArma
{
    Transform firePoint;
    float velocidade = 100;
    public float timer = 0;
   

    // Start is called before the first frame update
    void Start()
    {
        firePoint = GetComponentInChildren<Transform>().GetChild(0);
       
        damage = 3;
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }


    public void Atirar()
    {
        

        if (timer >= 1)
        {
            GameObject bullet = Instantiate(Resources.Load("Bullet", typeof(GameObject))) as GameObject;

            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.GetComponent<Rigidbody2D>().velocity = transform.up * velocidade;
            timer = 0;
        }
        
            
        
       
    }
}
