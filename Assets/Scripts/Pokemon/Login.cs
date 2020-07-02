using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField txtNick;
    public InputField txtPass;
    public Text txtMsg;

    public void BotaoLogin()
    {
        StartCoroutine(LoginBD(txtNick.text, txtPass.text));
    }
    IEnumerator LoginBD(string nick, string pass)
    {
        WWWForm webForm = new WWWForm();
        webForm.AddField("SQL", "SELECT *                          " +
                                "  FROM jogador j                  " +
                                " WHERE j.nick = '" + nick + "' " +
                                "   AND j.senha = MD5('" + pass + "')");

        UnityWebRequest webRequest = UnityWebRequest.Post("https://spigo.net/sql_to_json.php", webForm);

        yield return webRequest.SendWebRequest();
        
        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            txtMsg.text = "Erro...";
            Debug.Log(webRequest.error);
        }
        else
        {
            Jogadores jogadoresContainer = JsonUtility.FromJson<Jogadores>(webRequest.downloadHandler.text);
            txtMsg.text = "";

            if (jogadoresContainer.objetos.Length == 0)
            {
                txtMsg.text = "Usuário e/ou senha incorreto";
            }
            else if(jogadoresContainer.objetos.Length == 1)
            {
                Jogadores.Jogador jogadorLogado = jogadoresContainer.objetos[0];

                txtMsg.text = string.Concat("Olá ", jogadorLogado.nick);

                string jsonDoPlayer = JsonUtility.ToJson(jogadorLogado);

                PlayerPrefs.SetString("Player", jsonDoPlayer);

                SceneManager.LoadScene("PokemonJogo");
            }

        }
    }
}
