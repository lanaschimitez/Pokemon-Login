using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarScene : MonoBehaviour
{
    public void CriarLogin()
    {
        SceneManager.LoadScene("PokemonCreateLogin");
    }

    public void FazerLogin()
    {
        SceneManager.LoadScene("PokemonLogin");
    }
}
