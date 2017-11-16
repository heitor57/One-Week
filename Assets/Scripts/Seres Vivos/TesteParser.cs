using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Xml;
using System.IO;

public class TesteParser{
	static XmlDocument doc = new XmlDocument();
	static XmlNode root;
 
	 

	public static void Ler(string contido){
		doc.LoadXml (contido);
		root = doc.DocumentElement;
	}

	public static string[] PegarFilhos(){
		List<string> aux = new List<string>();
		XmlElement aux2;
		XmlAttribute aux3;
		if (root.HasChildNodes) {
			for (int i = 0; i < root.ChildNodes.Count; i++) {
				aux2 = (XmlElement)root.ChildNodes [i];
				aux3 = aux2.GetAttributeNode ("texto");
				aux.Add(aux3.InnerText);
			}
		}
		return aux.ToArray();
	}

	public static string[] PegarNoSeguinte(int i){
		root = root.ChildNodes [i];
		return PegarFilhos();
	}

	public static string IDmissao(){
		
		XmlElement aux2;
		XmlAttribute aux3;
		aux2 = (XmlElement)root;
		if (aux2.GetAttributeNode ("missao") != null) {
			aux3 = aux2.GetAttributeNode ("missao");
			return aux3.InnerText;
		} else {
			return null;
		}
	}



}
