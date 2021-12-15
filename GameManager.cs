using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CartaPrefab;
    List<GameObject> Cartas = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 1; i < 11; i++)
        {
            if (i < 6)
            {
                GameObject nueva_carta = Instantiate(CartaPrefab, new Vector3(-9, 2, 0) + Vector3.right * 3 * i, Quaternion.identity);
                nueva_carta.name = "Card" + i;
                Cartas.Add(nueva_carta);
            }
            else
            {
                GameObject nueva_carta = Instantiate(CartaPrefab, new Vector3(-9, -2, 0) + Vector3.right*3 * (i - 5), Quaternion.identity);
                Cartas.Add(nueva_carta);
                nueva_carta.name = "Card" + i;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
