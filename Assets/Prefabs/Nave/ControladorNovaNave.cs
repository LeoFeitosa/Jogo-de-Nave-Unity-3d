using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNovaNave : MonoBehaviour
{
    //Referencia para nova nave
    public GameObject referenciaNave = null;

    private float _tempoNovaPartida = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_tempoNovaPartida <= 0.0f) {
            //Codigo executado quando a nave explodir
            if (GameObject.FindObjectsOfType<ControladorNave>().Length == 0)
            {
                //Destruir tiros que estao na cena
                ControladorTiro[] tiros = GameObject.FindObjectsOfType<ControladorTiro>();
                foreach (ControladorTiro tiro in tiros)
                {
                    Destroy(tiro.gameObject);
                }

                //Pausa a naves inimigas ate aparecer um novo jovagor
                GameObject.FindObjectOfType<ControladorGrupoInimigo>().enabled = false;
                ControladorInimigo[] inimigos = GameObject.FindObjectsOfType<ControladorInimigo>();
                foreach (ControladorInimigo inimigo in inimigos)
                {
                    inimigo.enabled = false;
                }

                //Aguardar 1 segundo para proxima nave
                _tempoNovaPartida = 1.0f;
            }
        } else
        {
            //Timer para inicio de nova partida
            _tempoNovaPartida -= Time.deltaTime; 

            if (_tempoNovaPartida <= 0.0f) 
            {
                //Ativar naves inimigas
                GameObject.FindObjectOfType<ControladorGrupoInimigo>().enabled = true;
                ControladorInimigo[] inimigos = GameObject.FindObjectsOfType<ControladorInimigo>();
                foreach (ControladorInimigo inimigo in inimigos)
                {
                    inimigo.enabled = true;
                }

                //Cria nova nave do jogador
                GameObject novaNave = Instantiate<GameObject>(referenciaNave);
                novaNave.transform.position = this.transform.position;
            }
        }
    }
}
