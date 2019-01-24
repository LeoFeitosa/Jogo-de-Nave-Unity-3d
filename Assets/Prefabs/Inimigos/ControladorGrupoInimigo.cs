using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorGrupoInimigo : MonoBehaviour
{
    public GameObject prefabInimigo = null;
    public float direcao = 1.0f;
    public float velocidade = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        CriaJogo();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(velocidade * direcao * Time.deltaTime, 0.0f, 0.0f));

        if (this.transform.position.x >= 15.0f || this.transform.position.x <= -15.0f)
        {
            direcao = -direcao;
        }
    }

    public void CriaJogo()
    {
        for (int x=0; x<11; x++)
        {
            for (int y=0; y<5; y++)
            {
                // referencia para a nova nave
                GameObject novaNave = Instantiate<GameObject>(prefabInimigo);

                // seta como filha do novo grupo de naves
                novaNave.transform.SetParent(this.transform);

                // posicao da nave dentro do grupo/bloco
                novaNave.transform.localPosition = new Vector3( -15.0f + x * 3.0f, y * 3.0f, 0.0f);
            }
        }
    }
}
