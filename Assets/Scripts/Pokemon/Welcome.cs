using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Welcome : MonoBehaviour
{
    public Text txtNick; //
    public Text level; //
    public Text xp; //
    public Text moedas;
    public Text capBag; //
    public Text capPokemon; //
    public GameObject _Instinct;
    public GameObject _Mystic;
    public GameObject _Valor;
    public GameObject _Fem;
    public GameObject _Masc;
    private Vector3 time = new Vector3(-44.64f, -22.33f, 110.0f); 
    private Vector3 gen = new Vector3(-70.2f, 27.6f, 110.0f);

    void Start()
    {

        string JsonDoJogador = PlayerPrefs.GetString("Player");
        Jogadores.Jogador jogador = JsonUtility.FromJson<Jogadores.Jogador>(JsonDoJogador);

        txtNick.text = string.Concat("Olá ", jogador.nick);
        level.text = string.Concat("Level: ", jogador.level);
        xp.text = string.Concat("XP: ", jogador.xp);
        moedas.text = string.Concat("Moedas: ", jogador.moedas);

        capBag.text = jogador.capBag.ToString();

        capPokemon.text = jogador.capPokemon.ToString();

        if(jogador.time == "Instinct")
        {
            Instantiate(_Instinct, time , Quaternion.identity);
        }
        else if (jogador.time == "Mystic")
        {
            Instantiate(_Mystic, time, Quaternion.identity);
        }
        else if (jogador.time == "Valor")
        {
            Instantiate(_Valor, time, Quaternion.identity);
        }

        if (jogador.genero == "M")
        {
            Instantiate(_Masc, gen, Quaternion.identity);
        }
        if (jogador.genero == "F")
        {
            Instantiate(_Fem, gen, Quaternion.identity);
        }
    }
}
