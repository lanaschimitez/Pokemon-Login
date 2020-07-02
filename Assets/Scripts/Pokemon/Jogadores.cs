[System.Serializable]
public struct Jogadores
{
    [System.Serializable]
    public struct Jogador
    {
        public int idJogador;
        public string nick;
        private string senha;
        public string time;
        public int level;
        public string email;
        public string genero;
        public int xp;
        public int moedas;
        public int capBag;
        public int capPokemon;
    }

    public Jogador[] objetos;
}