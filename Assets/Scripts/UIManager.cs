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
    private struct ParametrosUIStruct
    {
        public float boasVindasPainelTime;
    }
    [SerializeField] private ParametrosUIStruct ParametrosUI;

    private void Awake()
    {
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
}
