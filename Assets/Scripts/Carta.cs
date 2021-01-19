using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Carta : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private CartaScrObj dadosCarta;
    [SerializeField] private Text nome;
    [SerializeField] private Image imagem;
    public void OnPointerClick(PointerEventData eventData)
    {
        UIManager.Instance.SelecionarCarta(this);
    }

    private void Awake()
    {
        if (dadosCarta.nome != null)
            nome.text = dadosCarta.nome;
        if (dadosCarta.imagem != null)
            imagem.sprite = dadosCarta.imagem;
        
    }

    public string GetName()
    {
        return nome.text;
    }

    public Sprite GetImage()
    {
        return imagem.sprite;
    }

    public string GetDescricao()
    {
        return dadosCarta.descricao;
    }

}
