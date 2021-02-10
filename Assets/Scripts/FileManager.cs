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


    public void Inicializa()
    {
#if UNITY_STANDALONE && !UNITY_EDITOR && !UNITY_ANDROID && !UNITY_IPHONE

        filePath = filePathStandAlone + nomeArquivo + ".txt";
#else
        // este código executará no editor, iphone e android builds
        filePath = Application.persistentDataPath + nomeArquivo + ".txt";
#endif
    }

    public void GravaInicioSessao()
    {
        if(File.Exists(filePath))
        {
            File.AppendAllText(filePath, "Sessão Iniciada - " + System.DateTime.Now + "\n\n");
        }
    }

    public void GravaDadosGerados()
    {

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
