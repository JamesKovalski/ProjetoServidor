using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class APIClient : MonoBehaviour
{
    public Text nome;
    public Text detalhe;
    public Text poder;
    public Text tamanho;


    const string baseUrl = "http://localhost:60475/API";

	// Use this for initialization
	void Start ()
	{
		//StartCoroutine(PostItemApiAsync());
		StartCoroutine(GetItensApiAsync());

	}

	private IEnumerator PostItemApiAsync()
	{
		WWWForm form = new WWWForm();

        form.AddField("Tamanho", "ItemFromUnity 5");
        form.AddField("Poder", "ItemFromUnity 4");
        form.AddField("Detalhe", "ItemFromUnity 3");
        form.AddField ("Nome", "ItemFromUnity 2");
		form.AddField("ID", "1");

		using (UnityWebRequest request = UnityWebRequest.Post(baseUrl + "/Personas", form))
		{
			// obsoleto (Unity 2017.1)
			yield return request.Send();

			// (Unity 2017.2)
			//yield return request.SendWebRequest();


			if (request.isNetworkError || request.isHttpError)
			{
				Debug.Log(request.error);
			}
			else
			{
				Debug.Log("Envio do item efetuado com sucesso");
			}

		}
	}

	IEnumerator GetItensApiAsync()
	{
		UnityWebRequest request = UnityWebRequest.Get(baseUrl + "/Personas");

		// obsoleto (Unity 2017.1)
		yield return request.Send();

		// (Unity 2017.2)
		//yield return request.SendWebRequest();

		if (request.isNetworkError || request.isHttpError)
		{
			Debug.Log(request.error);
		}
		else
		{
			string response = request.downloadHandler.text;
			//Debug.Log(response);

			//byte[] bytes = request.downloadHandler.data;

			Person[] itens = JsonHelper.getJsonArray<Person>(response);

			foreach (Person i in itens)
			{
				ImprimirItem(i);
			}

		}
	}

	private void ImprimirItem(Person i)
	{//qq coisa mudar pra detalhe detalhe detalhe
		Debug.Log("======= Dados Objeto ==========");

		Debug.Log("Id: " + i.ID);
		Debug.Log("Nome: " + i.Nome);
        Debug.Log("Detalhe " + i.Detalhe);
        Debug.Log("Poder " + i.Poder);
        Debug.Log("Tamanho " + i.Tamanho);

        nome.text = i.Nome;
        detalhe.text = i.Detalhe;
        poder.text = i.Poder.ToString();
        tamanho.text = i.Tamanho.ToString();

    }
}