using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTiro : MonoBehaviour
{
    public float velocidade = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(0.0f, velocidade * Time.deltaTime, 0.0f));

        //Quando o tiro sair da tela, será desruido o objeto
        if (this.transform.position.y >= 100.0f || this.transform.position.y <= -100.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
