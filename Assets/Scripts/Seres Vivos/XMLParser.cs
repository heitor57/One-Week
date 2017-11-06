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
			if(reader.IsStartElement("dialogo")) {
				if(current != null){
					conversa.Add(current);
				}
				current = new Missao ();
			}
			if (current != null) {
				if (reader.IsStartElement ("id")) {
					current.id = reader.ReadElementContentAsInt ();
				}
				if (reader.IsStartElement ("texto")) {
					current.texto = reader.ReadElementContentAsString ();
				}
				if (reader.IsStartElement ("quemfala")) {
					current.quemfala = reader.ReadElementContentAsString ();
				}	
				if (reader.IsStartElement ("missao")) {
					current.nome = reader.ReadElementContentAsString ();
				}
				if (reader.IsStartElement ("xp")) {
					current.id = reader.ReadElementContentAsInt ();
				}
				if (reader.IsStartElement ("quantidade")) {
					current.id = reader.ReadElementContentAsInt ();
				}
				if (reader.IsStartElement ("tipo")) {
					current.quemfala = reader.ReadElementContentAsString ();
				}
				if (reader.IsStartElement ("recompensaID")) {
					current.id = reader.ReadElementContentAsInt ();
				}
				if (reader.IsStartElement ("pedidoID")) {
					current.id = reader.ReadElementContentAsInt ();
				}
					
			}

		}
		if(current != null){
			conversa.Add(current);
		}

		return conversa.ToArray ();
	}

}
