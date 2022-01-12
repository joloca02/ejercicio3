using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CartaPrefab;
    List<GameObject> Cartas = new List<GameObject>();
    public List<Sprite> imagenesCartas = new List<Sprite>();
    int[] repetidos = { 0, 0, 0, 0, 0 };
    int[] puntuacion = { 7, 1, 0, 9, 6 };
    int estado = 1;
    int cardUp, indiceVolteada;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 1; i < 11; i++)
        {
            GameObject nueva_carta;
            if (i < 6)
            {
                nueva_carta = Instantiate(CartaPrefab, new Vector3(-9, 2, 0) + Vector3.right * 3 * i, Quaternion.identity);

            }
            else
            {
                nueva_carta = Instantiate(CartaPrefab, new Vector3(-9, -2, 0) + Vector3.right*3 * (i - 5), Quaternion.identity);

            }
            nueva_carta.name = "Card" + i;
            Cartas.Add(nueva_carta);
            int posicion = 0;
            bool listo = false;
            while (listo == false)
            {
            posicion = Random.Range(0, 5);
                if (repetidos[posicion] < 2)
                {
                    repetidos[posicion]++;
                    listo = true;
                }
            nueva_carta.GetComponent<CardScript>().front = imagenesCartas[posicion];
            nueva_carta.GetComponent<CardScript>().puntuacion = puntuacion[posicion];
            nueva_carta.GetComponent<CardScript>().indice = i-1;

            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void clickOnCard(int puntuacion, int indice)
    {
        if (estado == 1)
        {
            cardUp = puntuacion;
            indiceVolteada = indice;
            estado = 2;
        }
        else
        {
            if(puntuacion == cardUp)
            {
                Debug.Log("Las cartas volteadas son pareja");
                Cartas[indice].SetActive(false);
                Cartas[indiceVolteada].SetActive(false);
            }
            else
            {
                Debug.Log("Las cartas volteadas no son pareja");
                StartCoroutine(Wait(indice, indiceVolteada));

            }
            estado = 1;
        }
        //Debug.Log("click en "+name+ " con un valor de "+puntuacion);
    }
    IEnumerator Wait(int indice, int indiceVolteada)
    {
        yield return new WaitForSeconds(2);
        Cartas[indice].GetComponent<CardScript>().Vuelta();
        Cartas[indiceVolteada].GetComponent<CardScript>().Vuelta();
    }
}
