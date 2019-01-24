using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNave : MonoBehaviour
{
    public float velocidade = 1.0f;
    public GameObject prefabTiro = null; // Referencia para o tiro

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Pegar o Input
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * velocidade;
        //Debug.Log( horizontal.ToString() );

        //move a nave para direita e para esquerda
        transform.Translate(new Vector3(horizontal, 0.0f, 0.0f));

        //Tiro nave
        if (Input.GetButtonDown( "Fire1" ))
        {
            Debug.Log("Atirou");
            //Criar novo objeto de tiro
            GameObject novoTiro = Instantiate<GameObject>(prefabTiro);
            //Seta posicao do tiro para ser igual a da nave
            novoTiro.transform.position = this.transform.position;
            //Seta a direcao do novo tiro
            novoTiro.GetComponent<ControladorTiro>().velocidade = 30.0f;
        }
    }
}
