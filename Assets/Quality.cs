using UnityEngine;
using UnityEngine.UI;
public class Quality : MonoBehaviour {
	public Dropdown d;
	void Start(){ d.value = QualitySettings.GetQualityLevel(); }
	public void troca(){ QualitySettings.SetQualityLevel(d.value); }
}