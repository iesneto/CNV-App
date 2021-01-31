using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{

    [SerializeField] private List<Carta> cartasNecessidadesSelecionadas;
    [SerializeField] private List<Carta> cartasSentimentosSelecionadas;
    [SerializeField] private List<CartaScrObj> DB_CartasNecessidades;
    [SerializeField] private List<CartaScrObj> DB_CartasSentimentos;

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
