using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Welcome : MonoBehaviour
{
    void Start()
    {
        Text txt = GetComponent<Text>();

        string JsonDoJogador = PlayerPrefs.GetString("Player");
        Jogadores.Jogador jogador = JsonUtility.FromJson<Jogadores.Jogador>(JsonDoJogador);

        txt.text = string.Concat("Olá ", jogador.nick);
    }
}
