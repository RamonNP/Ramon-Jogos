using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//requer um boxCollider2D
[RequireComponent(typeof(Rigidbody2D))]
public class MoveObject2D : MonoBehaviour
{ // funciona apenas com cameras ortograficas

    Vector3 posicInicial;
    Vector3 posicDestino;
    Vector3 vetorDirecao;
    public Rigidbody2D _rigidbody2D;
    bool estaArrastando;
    float distancia;

    [HideInInspector]
    public bool estaConectado;

    [Range(1, 15)]
    public float velocidadeDeMovimento = 10;
    [Space(10)]
    public Transform conector;
    [Range(0.1f, 2.0f)]
    public float distanciaMinimaConector = 0.5f;

    void Start()
    {
        //_rigidbody2D = transform.root.GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 1;
    }

    void OnMouseDown()
    {
        if(!estaConectado)
        {
           // Debug.Log("OnMouseDown");
            posicInicial = transform.root.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _rigidbody2D.gravityScale = 0;
            estaArrastando = true;
            estaConectado = false;
        }
    }

    void OnMouseDrag()
    {
        if (!estaConectado)
        {
            //Debug.Log("OnMouseDrag");
            posicDestino = posicInicial + Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vetorDirecao = posicDestino - transform.root.position;
            _rigidbody2D.velocity = vetorDirecao * velocidadeDeMovimento;
        }
    }

    void OnMouseUp()
    {
        if (!estaConectado)
        {
            //Debug.Log("OnMouseUp");
            _rigidbody2D.gravityScale = 0;
            estaArrastando = false;
            _rigidbody2D.velocity = vetorDirecao * velocidadeDeMovimento;
        }
    }

    void FixedUpdate()
    {
        if (!estaArrastando && !estaConectado)
        {
            distancia = Vector2.Distance(transform.position, conector.position);
            Debug.Log(distancia+"-------" + distanciaMinimaConector);
            if (distancia < distanciaMinimaConector)
            {
                _rigidbody2D.gravityScale = 0;
                _rigidbody2D.velocity = Vector2.zero;
                transform.root.position = Vector2.MoveTowards(transform.root.position, conector.position, 0.02f);
            }
            if (distancia < 0.10f)
            {
                Debug.Log("COMPLETOU");
                estaConectado = true;
                transform.position = conector.position;

            }
        }
    }
}