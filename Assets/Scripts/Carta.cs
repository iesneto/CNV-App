using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Carta : MonoBehaviour, IPointerClickHandler
{
    public enum TipoPainel { DISPONIVEL, SELECIONADO}
    [SerializeField] private CartaScrObj dadosCarta;
    [SerializeField] private Text nome;
    [SerializeField] private Image imagem;
    [SerializeField] private bool selecionada;
    [SerializeField] private Text descricao;
    [SerializeField] private Image check;
    [SerializeField] Vector3 scaleUp;
    [SerializeField] Vector3 scaleDown;
    [SerializeField] private TipoPainel painel;
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (painel)
        {
            // Comportamento da carta quando no Painel disponível
            case TipoPainel.DISPONIVEL:
                if (selecionada)
                {
                    //UIManager.Instance.SelecionarCarta(this);
                    AppManager.Instance.RemoveCartaSelecionada(this);
                    

                }
                else
                {
                    AppManager.Instance.AddCartaSelecionada(this);
                    
                }
                break;

            // Comportamento da carta quando no Painel Selecionada
            case TipoPainel.SELECIONADO:
                AppManager.Instance.RemoveCartaSelecionada(this);
                break;
            default:
                break;
        }
    }

    private void InicializaCarta()
    {
        if (dadosCarta.nome != null)
            nome.text = dadosCarta.nome.ToUpper();
        //if (dadosCarta.imagem != null)
        //    imagem.sprite = dadosCarta.imagem;
        //else imagem.enabled = false;
        if (dadosCarta.descricao != null)
            descricao.text = dadosCarta.descricao;
        if (painel == TipoPainel.DISPONIVEL)
        {
            check.enabled = false;
            selecionada = false;
            gameObject.GetComponent<RectTransform>().localScale = scaleDown;
        }
        
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

    public TipoPainel GetPainel()
    {
        return painel;
    }

    public void SetDados(CartaScrObj dados)
    {
        dadosCarta = dados;
        InicializaCarta();
    }

    public void DeselecionaCarta()
    {
        selecionada = false;
        check.enabled = false;
        gameObject.GetComponent<RectTransform>().localScale = scaleDown;
    }

    public void SelecionaCarta()
    {
        selecionada = true;
        check.enabled = true;
        gameObject.GetComponent<RectTransform>().localScale = scaleUp;
    }
}
