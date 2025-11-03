using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> discard = new List<Card>();
    public GameObject deckFull;
	public Transform[] cardSlots;
	public bool[] avalCardSlots;
    public int avalSlotCount;

    public static Deck me;

	public int[] DrawTimer;

	//public i

    //public Card SelectedCard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		DrawTimer[0] = DrawTimer[1];
        Random.InitState(0);
        me = this;
        deck.Clear ();
		discard.Clear ();
		foreach(Transform child in deckFull.transform){
			deck.Add (child.gameObject.GetComponent<Card> ());
			//deck.Add (child.gameObject.GetComponent<Card> ());
		}
        avalSlotCount = avalCardSlots.Length;
        //Shuffle();
        //DrawCard();
    }

    public void DrawCard(){
		//draw a random card from deck
		if (deck.Count >= 1) {
			//Random.seed = System.DateTime.Now.Millisecond;
			Card randCard = deck[Random.Range(0, deck.Count)];

			for(int i = 0; i < cardSlots.Length; i++){
				if(avalCardSlots[i]){
					deck.Remove (randCard);
					//Debug.Log(randCard.ID + " #" + i);
					avalSlotCount--;
					randCard.handInd = i;
					randCard.transform.transform.position = cardSlots[i].position;
					randCard.transform.gameObject.SetActive(true);
					randCard.played = false;
					avalCardSlots[i] = false;
					randCard.Activate();
					return;
				}
			}
		}
	}

    public void Shuffle(){
		//shuffle the deck
		if (discard.Count >= 1) {
			foreach(Card card in discard){
				deck.Add (card);
			}
			discard.Clear ();
		}
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		if(avalSlotCount > 0){if(DrawTimer[0] > 0){DrawTimer[0]--;} else {DrawTimer[0] = DrawTimer[1]; DrawCard();} }
        if(deck.Count >= 0){
			Shuffle();
		}
    }
}
