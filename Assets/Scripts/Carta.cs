using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Carta : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private CartaScrObj dadosCarta;
    [SerializeField] private Text nome;
    [SerializeField] private Image imagem;
    [SerializeField] private bool selecionada;
    [SerializeField] private Text descricao;
    [SerializeField] private Image check;
    [SerializeField] Vector3 scaleUp;
    [SerializeField] Vector3 scaleDown;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (selecionada)
        {
            //UIManager.Instance.SelecionarCarta(this);
            AppManager.Instance.RemoveCartaSelecionada(this);
            selecionada = false;
            check.enabled = false;
            gameObject.GetComponent<RectTransform>().localScale = scaleDown;

        }
        else
        {
            AppManager.Instance.AddCartaSelecionada(this);
            selecionada = true;
            check.enabled = true;
            check.enabled = true;
            gameObject.GetComponent<RectTransform>().localScale = scaleUp;
        }
    }

    private void InicializaCarta()
    {
        if (dadosCarta.nome != null)
            nome.text = dadosCarta.nome;
        if (dadosCarta.imagem != null)
            imagem.sprite = dadosCarta.imagem;
        else imagem.enabled = false;
        if (dadosCarta.descricao != null)
            descricao.text = dadosCarta.descricao;
        check.enabled = false;
        selecionada = false;
        gameObject.GetComponent<RectTransform>().localScale = scaleDown;
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

    //public void AlteraStatusSelecao()
    //{
    //    selecionada = true ? false : true;
    //}

}
