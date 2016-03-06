 using UnityEngine;
using System.Collections;

public class DebugChangeCard : MonoBehaviour {
	CardFlipper flipper;
	CardModel cardModel;
	int cardIndex = 0;
	public GameObject card;

	void Awake () {
		flipper = card.GetComponent<CardFlipper>();
		cardModel = card.GetComponent<CardModel>();	
	}
	public void ButtonPress ()
	{
		
		if (cardIndex == cardModel.faces.Length) { 
			cardIndex = 0;
			flipper.FlipCard (cardModel.faces [cardModel.faces.Length - 1], cardModel.cardBack, -1);
		} else {
			if (cardIndex > 0) {
				flipper.FlipCard (cardModel.faces [cardIndex - 1], cardModel.faces [cardIndex], cardIndex);
			} else {
				flipper.FlipCard (cardModel.cardBack, cardModel.faces [cardIndex], cardIndex);
			}
			cardIndex++;
		}


	}


}
