using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    FileManager fileManager;
    [SerializeField] private List<Carta> cartasNecessidadesSelecionadas;
    [SerializeField] private List<Carta> cartasSentimentosSelecionadas;
    [SerializeField] private List<CartaScrObj> DB_CartasNecessidades;
    [SerializeField] private List<CartaScrObj> DB_CartasSentimentos;
    [SerializeField] private string nome;
    [SerializeField] private string localidade;

    private static AppManager _instance;
    public static AppManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("AppManager is null");
            }

            return _instance;
        }
    }

    public string GetNome()
    {
        return nome;
    }

    public void SetNome(string n)
    {
        nome = n;
    }

    public string GetLocalidade()
    {
        return localidade;
    }

    public void SetLocalidade(string l)
    {
        localidade = l;
    }

    public List<Carta> GetCartasSentimentosSelecionadas()
    {
        return cartasSentimentosSelecionadas;
    }

    public List<Carta> GetCartasNecessidadesSelecionadas()
    {
        return cartasNecessidadesSelecionadas;
    }

    private void SingletonInitialization()
    {
        if (_instance != this && _instance != null)
        {

            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        _instance = this;
    }

    private void Awake()
    {
        SingletonInitialization();

        if (UIManager.Instance) UIManager.Instance.Inicializa();

        fileManager = GetComponent<FileManager>();
        if (fileManager) fileManager.Inicializa();
    }

    public void AddCartaSelecionada(Carta c)
    {
        switch (c.GetDados().tipo)
        {
            case CartaScrObj.CartaTipo.NECESSIDADE:
                cartasNecessidadesSelecionadas.Add(c);
                UIManager.Instance.SelecionaCartaNecessidade(c);
                break;
            case CartaScrObj.CartaTipo.SENTIMENTO:
                cartasSentimentosSelecionadas.Add(c);
                UIManager.Instance.SelecionaCartaSentimento(c);
                break;
            default:
                break;
        }
        c.SelecionaCarta();
    }

    public void RemoveCartaSelecionada(Carta c)
    {
        Carta csel = c.GetDados().RefSelecionada;
        Carta cdisp = c.GetDados().RefDisponivel;
        switch (cdisp.GetDados().tipo)
        {
            case CartaScrObj.CartaTipo.NECESSIDADE:
                cartasNecessidadesSelecionadas.Remove(cdisp);
                break;
            case CartaScrObj.CartaTipo.SENTIMENTO:
                cartasSentimentosSelecionadas.Remove(cdisp);
                break;
            default:
                break;
        }
        cdisp.DeselecionaCarta();
        Destroy(csel.gameObject);
    }

    public List<CartaScrObj> GetNecessidadesDB()
    {
        return DB_CartasNecessidades;
    }

    public List<CartaScrObj> GetSentimentosDB()
    {
        return DB_CartasSentimentos;
    }
}
