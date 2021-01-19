using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject objectPanels;
    [SerializeField] private List<GameObject> listPanels;
    [SerializeField] private GameObject currentPanel;
    [SerializeField] private int panelIndex;

    [System.Serializable]
    private struct CartaSelecionadaStruct
    {
        public GameObject gameObject;
        public Text nome;
        public Image imagem;
        public Text descricao;
    }
    [SerializeField] private CartaSelecionadaStruct cartaSelecionadaUI;

    [System.Serializable]
    private struct ParametrosUIStruct
    {
        public float boasVindasPainelTime;
    }
    [SerializeField] private ParametrosUIStruct ParametrosUI;


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

   
        

    private void Awake()
    {

        SingletonInitialization();

        panelIndex = 0;
        
        foreach(Transform child in objectPanels.transform)
        {
            child.gameObject.SetActive(false);
            listPanels.Add(child.gameObject);
        }

        currentPanel = listPanels[panelIndex];
        currentPanel.SetActive(true);
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
        // desabilita painel atual
        currentPanel.SetActive(false);
        // aponta para o proximo
        panelIndex++;
        // pega o proximo painel
        currentPanel = listPanels[panelIndex];
        // habilita o proximo painel
        currentPanel.SetActive(true);
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

    public void SelecionarCarta(Carta c)
    {

        cartaSelecionadaUI.gameObject.SetActive(true);
        cartaSelecionadaUI.nome.text = c.GetName();
        cartaSelecionadaUI.imagem.sprite = c.GetImage();
        cartaSelecionadaUI.descricao.text = c.GetDescricao();
    }

    public void CancelarSelecaoCarta()
    {
        cartaSelecionadaUI.nome.text = null;
        cartaSelecionadaUI.imagem.sprite = null;
        cartaSelecionadaUI.descricao.text = null;
        cartaSelecionadaUI.gameObject.SetActive(false);
        
    }
}
