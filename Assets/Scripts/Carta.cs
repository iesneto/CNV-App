using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Carta : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private CartaScrObj dadosCarta;
    [SerializeField] private Text nome;
    [SerializeField] private Image imagem;
    [SerializeField] private bool selecionada;
    public void OnPointerClick(PointerEventData eventData)
    {
        UIManager.Instance.SelecionarCarta(this);
    }

    private void InicializaCarta()
    {
        if (dadosCarta.nome != null)
            nome.text = dadosCarta.nome;
        if (dadosCarta.imagem != null)
            imagem.sprite = dadosCarta.imagem;
        else imagem.enabled = false;
        
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

    public CartaScrObj GetDados()
    {
        return dadosCarta;
    }

    public void SetDados(CartaScrObj dados)
    {
        dadosCarta = dados;
        InicializaCarta();
    }

    public void AlteraStatusSelecao()
    {
        selecionada = true ? false : true;
    }

}
