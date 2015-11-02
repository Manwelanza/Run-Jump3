using UnityEngine;
using System.Collections;

public class ReproductorSonidos : MonoBehaviour {

	/// <summary>
	/// Singleton
	/// </summary>
	public static ReproductorSonidos Instancia;
	
	public AudioClip sonidoJetPack;
	public AudioClip sonidoPerder;
	public AudioClip sonidoEstrella;
	public AudioClip sonidoCaer;
	
	void Awake()
	{
		// Registramos el singleton
		if (Instancia != null)
		{
			Debug.LogError("Muchas instancias de ReproducirSonidos!");
		}
		Instancia = this;
	}
	
	public void ReproducirSonidoJetPack(Vector3 posicion)
	{
		ReproducirSonido(sonidoJetPack, posicion);
	}
	
	public void ReproducirSonidoPerder(Vector3 posicion)
	{
		ReproducirSonido(sonidoPerder, posicion);
	}
	
	public void ReproducirSonidoEstrella(Vector3 posicion)
	{
		ReproducirSonido(sonidoEstrella, posicion);
	}

	public void ReproducirSonidoCaer (Vector3 posicion)
	{
		ReproducirSonido (sonidoCaer, posicion);
	}

	
	/// <summary>
	/// Reproducir un sonido
	/// </summary>
	private void ReproducirSonido(AudioClip clipOriginal, Vector3 posicion)
	{
		AudioSource.PlayClipAtPoint(clipOriginal, posicion);
	}
}
