using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileManager : MonoBehaviour
{
    private string filePathStandAlone = "Dados/";
    private string filePath;
    [SerializeField] private string nomeArquivo;
    private string currentFile;


    public void Inicializa()
    {
#if UNITY_STANDALONE && !UNITY_EDITOR && !UNITY_ANDROID && !UNITY_IPHONE

        filePath = filePathStandAlone + "./" nomeArquivo + ".txt";
#else
        // este código executará no editor, iphone e android builds
        filePath = Application.persistentDataPath + "./" + nomeArquivo;
#endif

        currentFile = filePath + System.DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".txt";

        File.Create(currentFile);
    }

    public void GravaInicioSessao()
    {
        if(File.Exists(currentFile))
        {
            File.AppendAllText(currentFile, "Sessão Iniciada - " + System.DateTime.Now.ToString("dd/MM/yyyy\tHH:mm:ss") + "\n\n");
        }
    }

    public void GravaDadosGerados()
    {
        string content = "\tNome: " + AppManager.Instance.GetNome() + "\n" + "\tLocalidade: " + AppManager.Instance.GetLocalidade();
        File.AppendAllText(currentFile, content);

        content = "\n\n\tCartas Sentimentos: ";
        File.AppendAllText(currentFile, content);

        for(int i = 0; i < AppManager.Instance.GetCartasSentimentosSelecionadas().Count; i++)
        {
            Carta c = AppManager.Instance.GetCartasSentimentosSelecionadas()[i];
            if (i == AppManager.Instance.GetCartasSentimentosSelecionadas().Count - 1)
                content = "\t" + c.GetDados().nome;
            else content = "\t" + c.GetDados().nome + ",";
            File.AppendAllText(currentFile, content);
        }

        content = "\n\n\tCartas Necessidades: ";
        File.AppendAllText(currentFile, content);

        for (int i = 0; i < AppManager.Instance.GetCartasNecessidadesSelecionadas().Count; i++)
        {
            Carta c = AppManager.Instance.GetCartasNecessidadesSelecionadas()[i];
            if (i == AppManager.Instance.GetCartasNecessidadesSelecionadas().Count - 1)
                content = "\t" + c.GetDados().nome;
            else content = "\t" + c.GetDados().nome + ",";
            File.AppendAllText(currentFile, content);
        }

        string sugestao = UIManager.Instance.GetSugestao();
        content = "\n\n\tSugestão: ";
        File.AppendAllText(currentFile, content);

        if (sugestao != null)
        {
            content = sugestao;
            File.AppendAllText(currentFile, content);
        }

        content = "\n\nSessão Finalizada - " + System.DateTime.Now.ToString("dd/MM/yyyy\tHH:mm:ss") + "\n\n";
        File.AppendAllText(currentFile, content);

    }
//    public void Save()
//    {

//        // Prepara o arquivo que será salvo em disco
//        string filePath;

//#if UNITY_STANDALONE && !UNITY_EDITOR && !UNITY_ANDROID && !UNITY_IPHONE

//        filePath = filePathStandAlone;
//#else
//        // este código executará no editor, iphone e android builds
//        filePath = Application.persistentDataPath;
//#endif

//        if (VerificaSeArquivoExiste(filePath, nomeArquivo))
//        {
//            file = File.Open(filePath + nomeArquivo, FileMode.Open);
//        }
//        else
//        {
//            file = File.Create(filePath + nomeArquivo);
//        }

//        //Copia os dados para o arquivo
//        bf.Serialize(file, playerData);
//        file.Close();
//    }

//    public void Load()
//    {
//        //abre o arquivo que contem os dados em disco
//        FileStream file;
//        BinaryFormatter bf = new BinaryFormatter();
//        string nomeArquivo = "./appData.db";
//        string filePath;

//#if UNITY_STANDALONE && !UNITY_EDITOR && !UNITY_ANDROID && !UNITY_IPHONE

//        filePath = filePathStandAlone;
//#else
//        // este código executará no editor, iphone e android builds
//        filePath = Application.persistentDataPath;
//#endif


//        if (VerificaSeArquivoExiste(filePath, nomeArquivo))
//        {
//            file = File.Open(filePath + nomeArquivo, FileMode.Open);
//        }
//        else
//        {
//            file = File.Create(filePath + nomeArquivo);
//            //return;
//        }
//        // Prepara a estrutura de dados no app
//        PlayerData playerData = new PlayerData();
//        if (file.Length != 0)
//            playerData = (PlayerData)bf.Deserialize(file);

//        file.Close();


//        PreparaDadosCarregamento(playerData);
//    }

}
