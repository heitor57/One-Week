using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour {

	public s fin;
	public Sangue fin2;
	public Porta_Leste fin3;
	public Machado_CAbana fin4;
	public Castelo_Final finaly;
	public static string final;

	void Start(){
		fin = GameObject.Find ("Sangues/blood7").GetComponent<s> ();
		fin2 = GameObject.Find ("Sangues/blood1").GetComponent<Sangue> ();
		fin3 = GameObject.Find ("Mapa/Itens_Mapa/Casa dos Capitães (1)").GetComponent<Porta_Leste> ();
		fin4 = GameObject.Find ("Machado").GetComponent<Machado_CAbana> ();
		final = "";
	}
	public void setFinaly(){
		finaly = GameObject.Find ("Mapa/Itens_Mapa/Castelo").GetComponent<Castelo_Final> ();
	}
	public string getFim(){
		return final;
	}

	public void geraFim(){
		string fim = "";
		if (fin.final1 || fin2.final2) {
			fim += "\nOrion, mesmo confuso sobre o que houve consigo mesmo,\n seguiu cumprindo seus deveres de capitão da guarda e\n conseguiu mostrar porque estáem tal patente.\n\n";
		}
		if ((fin.final1) && (fin2.final2)) {
			fim += "\nO capitão do oeste colocou seus compromissos com a coroa e principalmente com o povo de Boreas em primeiro lugar.\n Ele seguiu seu dever e ajudou aqueles que lhe pediram por ajuda quando algum parente ou amigo se via perdido.\n\n";
		}
		if (fin3.final3) {
			fim += "\nDeveras cheio de problemas, Orion buscou por ajuda em Viridis, porém seu amigo, o capitão do leste, Petr, não se via presente.\n O mesmo havia sido mandado pelo regente para investigar uma falsa pista nos montes cinzas.\n Sozinho,Orion teve que se virar.\n\n";			
		}
		if (fin3.final3 && fin.final1 && fin2.final2) {
			fim += "\nComo um verdadeiro guerreiro, em meio a boatos e especulações sobre o golpe, Orion seguiu seus deveres e sua conciência, se doando ao máximo por sua terra.\n\n";			
		}
		if (finaly.finaly) {
			fim += "\nBatalhando por seu povo e buscando sempre honrar seu título, Orion caminhou até Verus e fez tudo que estava ao seu alcance para impedir o golpe.\n O cavaleiro passou correndo pela entrada de pedra do castelo e derrotando alguns rebeldes aliados do regente,\n o mesmo se dirigiu ao salão principal.\n Lá, ele pode encontrar vários corpos de amigos e aliados mortos pelo chão, junto com a  rainha, que jazia em um canto da sala.\n Em frente ao magestoso trono, o rei Magnus, já sem espada, se encontrava ferido e o regente caminhava na direção da magestade, com um leve sorriso de ironia.\n Orion saltou sobre ele e com um golpe arrancou-lhe a mão.\n Os gritos do traidor erradiaram sobre as pedras gastas do salão.\n O cavaleiro se pos de pé, e com lágrimas nos olhos, cortou a cabeça de seu superior.\n O golpe estava encerrado.\n\n";
		} else {
			fim += "\nMesmo com ares suspeitos sobre Sperare, Orion não se fez presente no dia do suposto golpe, algo que o mesmo viria a se arrepender.\n Com uma ravolta violenta em Verus, o regente aniquilou junto com seus soldados, todo aquele que se colocou em seu caminho\n e matou brutalmente o rei e a rainha, na sala do trono.\n Com tais atos, todas as cidadelas de Sperare foram forçadas a aceitar seu novo regime de reinado de terror, e Orion acabou atormentado por não conseguir impedir tal ato, já que a decisão estava em suas mãos.\n\n";
		}
		final=fim;
		SceneManager.LoadScene (3);
	}
}
