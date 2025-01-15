using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
  //Tiempo en el que se tarda en hacer el efecto de fade.
  public float fadeTime = 1;

  [Tooltip("Manda la imagen a color sólido")]
  public int sceneToChange;

  //La imagen que va a hacer el efecto de fade.
  public Image fadeImage;

    void Start()
    {
      //iniciar con un color sin transparencia.
      fadeImage.color = Color.black;
      FadeOut();  
		}

  /// <summary>
  /// Manda la imagen a color sólido
  /// </summary>
  public void FadeIn()
  {
    //Cambiar de escena al finalizar el tween
		fadeImage.DOFade(1, fadeTime).OnComplete(SceneChange);
	}

	/// <summary>
	/// Manda la imagen a transparencia.
	/// </summary>
	public void FadeOut() 
  {
		//DoFade hace una interpolación a la transparencia de la imagen.
		//0 = transparencia, 1 = color sólido.
		fadeImage.DOFade(0, fadeTime);
	}

  /// <summary>
  /// Cambio de escena, llamar de preferencia al final del Tween
  /// </summary>
  private void SceneChange()
  {
    SceneManager.LoadScene(sceneToChange);
  }
}
