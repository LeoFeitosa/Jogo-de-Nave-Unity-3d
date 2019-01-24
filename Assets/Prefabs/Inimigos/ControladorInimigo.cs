using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInimigo : MonoBehaviour
{
    public GameObject prefabTiro = null;

    //timer para o proximo tiro
    private float _tempoTiro = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        _tempoTiro = Random.Range(2.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        _tempoTiro -= Time.deltaTime;

        if (_tempoTiro <= 0.0f)
        {
            //pega todos os tiros do inimigo na tela
            GameObject[] tirosInimigo = GameObject.FindGameObjectsWithTag("TiroInimigo");

            //caso tenha menos de 5 tiros na tela
            if (tirosInimigo.Length < 5)
            {
                //cria novo tiro
                GameObject novoTiro = Instantiate<GameObject>(prefabTiro);
                novoTiro.transform.position = this.transform.position;
                novoTiro.GetComponent<ControladorTiro>().velocidade = -10.0f;
                novoTiro.tag = "TiroInimigo";
            }

            _tempoTiro = Random.Range(2.0f, 10.0f);            
        }
    }
}
