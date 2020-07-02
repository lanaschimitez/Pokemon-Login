using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CadastrarJogador : MonoBehaviour
{
    public InputField txtNick;
    public InputField txtPass;
    public Dropdown meuTime;
    public InputField txtEmail;
    public Dropdown genero;
    public void botaoInserir()
    {
        StartCoroutine(VerificaLoginBD(txtNick.text));
        
    }
    IEnumerator VerificaLoginBD(string nick)
    {
        WWWForm webForm = new WWWForm();
        webForm.AddField("SQL", "SELECT *                          " +
                                "  FROM jogador j                  " +
                                " WHERE j.nick = '" + nick + "' ");

        UnityWebRequest webRequest = UnityWebRequest.Post("https://spigo.net/sql_to_json.php", webForm);

        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Jogadores jogadoresContainer = JsonUtility.FromJson<Jogadores>(webRequest.downloadHandler.text);
            
            if (jogadoresContainer.objetos.Length == 0)
            {
                //Nick liberado para uso
                StartCoroutine(InsertLoginBD(txtNick.text, txtPass.text, meuTime.captionText.text, txtEmail.text, genero.captionText.text));
            }
            else if (jogadoresContainer.objetos.Length == 1)
            {
                Debug.Log("Nick ja utilizado");
            }

        }
    }
    IEnumerator InsertLoginBD(string nick,
                        string pass,
                        string meuTime,
                        string email,
                        string genero)
    {
        WWWForm webForm = new WWWForm();
        webForm.AddField("SQL", "INSERT INTO jogador  " +
                                "(nick, senha, time, level, email, genero, xp, moedas, capBag, capPokemon)  VALUES " +
                                "('" + nick + "', MD5('" + pass + 
                                "'), '" + meuTime + "', 1, '" + email + "', '" + genero + 
                                "', 0, 0, 200, 300)");

        UnityWebRequest webRequest = UnityWebRequest.Post("https://spigo.net/sql_to_json.php", webForm);

        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Debug.Log("YES");
        }
    }
}
