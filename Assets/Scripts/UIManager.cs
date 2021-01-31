using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private GameObject objectPanels;
    [SerializeField] private List<GameObject> listPanels;
    [SerializeField] private GameObject currentPanel;
    [SerializeField] private int panelIndex;
    [SerializeField] private GameObject contentNecessidadesDisponiveis;
    [SerializeField] private GameObject contentNecessidadesSelecionadas;
    [SerializeField] private GameObject contentSentimentosDisponiveis;
    [SerializeField] private GameObject contentSentimentosSelecionados;
    [SerializeField] private GameObject PrefabCartaNecessidadeDisponivel;
    [SerializeField] private GameObject PrefabCartaNecessidadeSelecionada;
    [SerializeField] private GameObject PrefabCartaSentimentoDisponivel;
    [SerializeField] private GameObject PrefabCartaSentimentoSelecionada;
    #endregion


    #region STRUCTS
    //[System.Serializable]
    //private struct UICartaSelecionadaStruct
    //{
    //    public GameObject gameObject;
    //    public Text nome;
    //    public Image imagem;
    //    public Text descricao;
    //}
    //[SerializeField] private UICartaSelecionadaStruct cartaSelecionadaUI;

    [System.Serializable]
    private struct UIParametrosStruct
    {
        public float boasVindasPainelTime;
    }
    [SerializeField] private UIParametrosStruct ParametrosUI;
    #endregion

    #region SINGLETON
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UIManager is null");
            }

            return _instance;
        }
    }
    #endregion


    private void Awake()
    {

        SingletonInitialization();
    }

    public void Inicializa()
    {
        panelIndex = 0;

        foreach (Transform child in objectPanels.transform)
        {
            child.gameObject.SetActive(false);
            listPanels.Add(child.gameObject);
        }

        foreach (CartaScrObj scrobj in AppManager.Instance.GetNecessidadesDB())
        {
            PreparePrefabNecessidadeDisponivel(scrobj);
        }

        foreach (CartaScrObj scrobj in AppManager.Instance.GetSentimentosDB())
        {
            PreparePrefabSentimentoDisponivel(scrobj);
        }

        currentPanel = listPanels[panelIndex];
        currentPanel.SetActive(true);

        // Arruma o Grid LayoutGroup dos contents para se adequar a resolução do app
        // contentNecessidadesDisponiveis.GetComponent<GridLayoutGroup>().

        StartCoroutine(BemVindoCoroutine());
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

    public void NextPanel()
    {
        if (panelIndex < listPanels.Count - 1)
        {
            // desabilita painel atual
            currentPanel.SetActive(false);
            // aponta para o proximo
            panelIndex++;
            // pega o proximo painel
            currentPanel = listPanels[panelIndex];
            // habilita o proximo painel
            currentPanel.SetActive(true);
        }
        else Debug.Log("Fim dos Paineis");
    }

    public void PreviousPanel()
    {
        // desabilita painel atual
        currentPanel.SetActive(false);
        // aponta para o anterior
        panelIndex--;
        // pega o painel anterior
        currentPanel = listPanels[panelIndex];
        // habilita o painel anterior
        currentPanel.SetActive(true);
    }

    IEnumerator BemVindoCoroutine()
    {
        yield return new WaitForSeconds(ParametrosUI.boasVindasPainelTime);
        NextPanel();
    }

    public void SelecionaCartaNecessidade(Carta c)
    {
        GameObject cartaSel = Instantiate(PrefabCartaNecessidadeSelecionada);
        cartaSel.GetComponent<Carta>().SetDados(c.GetDados());
        cartaSel.transform.SetParent(contentNecessidadesSelecionadas.transform);
        c.GetDados().RefSelecionada = cartaSel.GetComponent<Carta>();
    }

    public void SelecionaCartaSentimento(Carta c)
    {
        GameObject cartaSel = Instantiate(PrefabCartaSentimentoSelecionada);
        cartaSel.GetComponent<Carta>().SetDados(c.GetDados());
        cartaSel.transform.SetParent(contentSentimentosSelecionados.transform);
        c.GetDados().RefSelecionada = cartaSel.GetComponent<Carta>();
    }


    public void DeselecionaCarta(Carta c)
    {
       

    }

    

    //public void AddCartaSentimentos()
    //{

    //}


    private void PreparePrefabNecessidadeDisponivel(CartaScrObj scrObj)
    {
        GameObject carta = Instantiate(PrefabCartaNecessidadeDisponivel);
        scrObj.RefDisponivel = carta.GetComponent<Carta>();
        carta.GetComponent<Carta>().SetDados(scrObj);
        carta.transform.SetParent(contentNecessidadesDisponiveis.transform);
        
    }

    private void PreparePrefabSentimentoDisponivel(CartaScrObj scrObj)
    {
        GameObject carta = Instantiate(PrefabCartaSentimentoDisponivel);
        scrObj.RefDisponivel = carta.GetComponent<Carta>();
        carta.GetComponent<Carta>().SetDados(scrObj);
        carta.transform.SetParent(contentSentimentosDisponiveis.transform);
    }

    

}
