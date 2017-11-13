using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class XMLParser {

	public static Missao[] Dialogo(string contido){
		XmlReader reader = XmlReader.Create (new StringReader (contido));
		List<Missao> conversa = new List<Missao> ();
		Missao current = null;
		while (reader.Read()) {
			if(reader.IsStartElement("missao")) {
				if(current != null){
					conversa.Add(current);
				}
				current = new Missao ();
			}
			if (current != null) {
				if (reader.IsStartElement ("id")) {
					current.id = reader.ReadElementContentAsString ();
				}
				if (reader.IsStartElement ("nome")) {
					current.nome = reader.ReadElementContentAsString ();
				}
				if (reader.IsStartElement ("pedidoID")) {
					current.pedidoID = reader.ReadElementContentAsInt ();
				}
				if (reader.IsStartElement ("quantidade")) {
					current.quantidade = reader.ReadElementContentAsInt ();
				}
				if (reader.IsStartElement ("xp")) {
					current.xp = reader.ReadElementContentAsInt ();
				}
				if (reader.IsStartElement ("recompensaID")) {
					current.recompensaID = reader.ReadElementContentAsInt ();
				}
				if (reader.IsStartElement ("tipo")) {
					current.tipo = reader.ReadElementContentAsString ();
				}

					
			}

		}
		if(current != null){
			conversa.Add(current);
		}

		return conversa.ToArray ();
	}

}
