using UnityEngine;

[CreateAssetMenu(fileName = "NovoDadosCarta", menuName = "ScriptableObjects/DadosCartaAsset", order = 1)]
public class CartaScrObj : ScriptableObject
{
    public string nome;
    public Sprite imagem;
    public string descricao;
}
