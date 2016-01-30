using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States{
	cell, mirror, sheets0, lock0, cell_mirror, sheets1, lock1, lock1_mirror, 
	corridor, corridor_cells, stairs0, stairs1, corridor1, corridor2, closet0, closet1, 
	hairclip, closet2, corridor3, stairs2, corridor_disguise, stairs3, freedom};

	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (myState == States.cell) 				{state_cell ();} 
		else if (myState == States.sheets0) 		{state_sheets0 ();} 
		else if (myState == States.mirror) 			{state_mirror ();} 
		else if (myState == States.lock0) 			{state_lock0 ();} 
		else if (myState == States.cell_mirror) 	{state_cell_mirror ();} 
		else if (myState == States.sheets1) 		{state_sheets1 ();} 
		else if (myState == States.lock1) 			{state_lock1 ();} 
		else if (myState == States.lock1_mirror) 	{state_lock1_mirror();} 

		else if (myState == States.stairs0) 		{state_stairs0();}
		else if (myState == States.stairs1) 		{state_stairs1();}
		else if (myState == States.stairs2) 		{state_stairs2();}
		else if (myState == States.stairs3) 		{state_stairs3();}

		else if (myState == States.closet0) 		{state_closet0();}
		else if (myState == States.closet1) 		{state_closet1();}
		else if (myState == States.closet2) 		{state_closet2();}

		else if (myState == States.corridor) 		{state_corridor();}
		else if (myState == States.corridor_cells) 	{state_corridor_cells();}
		else if (myState == States.corridor1) 		{state_corridor1();}
		else if (myState == States.corridor2) 		{state_corridor2();}
		else if (myState == States.corridor3) 		{state_corridor3();}
		else if (myState == States.corridor_disguise) 	{state_corridor_disguise();}


		else if (myState == States.hairclip) 		{state_hairclip();}
		else if (myState == States.freedom) 		{state_freedom();}
	

	}

	void state_cell (){
		text.text = "You are in a prison cell and you want to escape.\n" +
		"Looking around, you can see some sheets on the bed, a mirror on " +
		"the wall and the door which is locked from the outside.\n\n" +
		"Press S to examine the sheets, M to examine the mirror and L to " +
		"examine the lock.";
		if (Input.GetKeyDown (KeyCode.S)) 			{myState = States.sheets0;} 
		else if (Input.GetKeyDown (KeyCode.M)) 		{myState = States.mirror;} 
		else if (Input.GetKeyDown (KeyCode.L)) 		{myState = States.lock0;} 
	}

	void state_sheets0 (){
		text.text = "You pick up the sheets and look at them. The quality is " +
					"poor and there's not much you can do with them.\n\n" +
					"Press R to put them down.";
		if (Input.GetKeyDown (KeyCode.R)) 			{myState = States.cell;}
	}

	void state_mirror (){
		text.text = "It's a small mirror, loosely bolted onto the poured concrete " +
		"wall. You could probably pull it off the wall with little force\n\n" +
		"Press P to pull the mirror off the wall or press R to return to " +
		"roaming your cell.";
		if (Input.GetKeyDown (KeyCode.R)) 			{myState = States.cell;} 
		else if (Input.GetKeyDown (KeyCode.P)) 		{myState = States.cell_mirror;}
	} 

	void state_lock0 (){
		text.text = "It's a combination lock, covered in dirt and dust. If only " + 
					"you could see the fingerprints on the numbers, but you can't " + 
					"from this angle.\n\n Press R to return to roaming your cell";
		if (Input.GetKeyDown (KeyCode.R)) 			{myState = States.cell;}
	}

	void state_cell_mirror() {
		text.text = "You give it a good tug, but it doesn't move much. After a " + 
					"few wiggles, you feel the concrete around the bolts begin to " +
					"crumble and another good tug and its free. Well done. Now what?\n\n" +
					"Press S to examine the sheets or press L to examine the lock.";

		if (Input.GetKeyDown (KeyCode.S)) 			{myState = States.sheets1;} 
		else if (Input.GetKeyDown (KeyCode.L)) 		{myState = States.lock1;}
	}

	void state_sheets1() {
		text.text = "You pick up the sheets and look at them. The quality is " +
					"poor and there's not much you can do with them.\n\n" +
					"Press R to put them down.";

		if (Input.GetKeyDown (KeyCode.R)) 			{myState = States.cell_mirror;}
	}

	void state_lock1 (){
		text.text = "It's a combination lock, covered in dirt and dust. If only " +
		"you could see the fingerprints on the numbers, but you can't " +
		"from this angle.\n\n Press R to return to roaming your cell " +
		"or press M to use the mirror";
		if (Input.GetKeyDown (KeyCode.R)) 			{myState = States.cell_mirror;} 
		else if (Input.GetKeyDown (KeyCode.M)) 		{myState = States.lock1_mirror;}
	}

	void state_lock1_mirror() {
		text.text = "You push the mirror through the bars of the door and use " +
					"the reflection to start trying combinations of the keys with " + 
					"obvious finger smudges on them. Eventually you find it: 1234\n\n" +
					"Press P to push the door open";
		if(Input.GetKeyDown(KeyCode.P)) 			{myState = States.corridor;}
	}

	void state_corridor() {
		text.text = "Outside your cell you can see a row of other locked doors, " + 
					"a staircase leading up towards the guards station, and a closed " +
					"closet door opposite marked 'Maintenance'.\n\n Do you want to:\n" +
					"Investigate the other cells, press C\nInvestigate the " + 
					"maintenance closet, press M\nInvestivate the stairs, press S\n" +
					"or to look around the corridor press L";
		if (Input.GetKeyDown (KeyCode.C)) 			{myState = States.corridor_cells;} 
		else if (Input.GetKeyDown (KeyCode.S)) 		{myState = States.stairs0;}
		else if (Input.GetKeyDown (KeyCode.M)) 		{myState = States.closet0;}
		else if (Input.GetKeyDown (KeyCode.L)) 		{myState = States.corridor1;}
	}

	void state_corridor_cells (){
		text.text = "The other cells are also locked by combination locks and if you " + 
					"wanted to you could let all the other prisoners out. Best not to " +
					"or you're bound to be heard\n\n Do you want to:\nInvestigate the " + 
					"maintenance closet, press M\n or investivate the stairs, press S";
		if (Input.GetKeyDown (KeyCode.S)) 		{myState = States.stairs0;}
		else if (Input.GetKeyDown (KeyCode.M)) 		{myState = States.closet0;}
	}

	void state_stairs0 (){
		text.text = "You start up the stairs but you hear the sounds of guards chatting " +
					"somewhere near the top. Wearing your orange jumpsuit there's no way " +
					"you could sneak past them.\n\n Press R to return to the corridor";
		if (Input.GetKeyDown (KeyCode.R)) 		{myState = States.corridor;}
	}

	void state_closet0 (){
		text.text = "Hmm, a maintenance closet, I wonder if there's anything useful in " + 
					"there? You try the handle but it's locked, with a small keyhole " +
			"below the handle\n\n Press R to return to the corridor";
		if (Input.GetKeyDown (KeyCode.R)) 		{myState = States.corridor;}
	}

	void state_corridor1 (){
		text.text = "As you walk quietly down the corridor, you kick something small and " +
					"metallic along the floor. You see it is a small hairclip and you " +
					"bend down to pick it up. Nice. Now you can keep that pesky hair from " +
					"flopping into your eyes.\n\nDo you want to:\n" +
					"Investigate the maintenance closet, press M\n or investivate the " +
					"stairs, press S\n";
		if (Input.GetKeyDown (KeyCode.M)) 			{myState = States.closet1;} 
		else if (Input.GetKeyDown (KeyCode.S)) 		{myState = States.stairs1;}
	}

	void state_stairs1 (){
		text.text = "Halfway up the stairs you can hear the guards laughing and shouting " +
					"near the top. Wait..did he say 'full house'?.. are they playing " +
					"poker? Still, even distracted they'd notice you trying to sneak past\n\n"+
					"press R to return to the corridor"; 
		if (Input.GetKeyDown (KeyCode.R)) 			{myState = States.corridor2;} 
	}

	void state_corridor2 (){
		text.text = "Now that your hair is pinned back out of your eyes, you can truly " +
					"enjoy this bleak grey-walled corridor.\n\nDo you want to:\n" +
					"Investigate the maintenance closet, press M\n or investivate the " +
					"stairs, press S\n";
		if (Input.GetKeyDown (KeyCode.M)) 			{myState = States.closet1;} 
		else if (Input.GetKeyDown (KeyCode.S)) 		{myState = States.stairs1;}
	}

	void state_closet1 (){
		text.text = "The locked door seems to mock you, you can almost hear it saying " +
					"'You'll never guess what I've got in here'.\n\nDo you want to:\n" +
					"Look around the corridor some more, press R\nor try to pick the lock " +
					"with your hairclip, press H";
		if (Input.GetKeyDown (KeyCode.R)) 			{myState = States.corridor2;} 
		else if (Input.GetKeyDown (KeyCode.H)) 		{myState = States.hairclip;}	
	}

	void state_hairclip (){
		text.text = "Not the hairclip! Nooo, now how will you make yourself look super " +
					"cool? Aw well, you bend the clip and push one end into the lock, " +
					"jiggle it a bit and voila.. the lock clicks open\n\nPress P to push " +
					"open the door";
		if (Input.GetKeyDown (KeyCode.P)) 			{myState = States.closet2;} 
	}

	void state_closet2 (){
		text.text = "Inside the closet are some cleaning supplies, a mop in bucket, " +
					"bottles of some generic disinfectant and a crumpled janitor's " +
					"jumpsuit hanging on a peg. Nothing that would make a good weapon." +
					"\n\nDo you want to:\nReturn to the corridor, Press R\n or Put on " +
					"the jumpsuit, press J";

		if (Input.GetKeyDown (KeyCode.R)) 			{myState = States.corridor3;} 	
		else if (Input.GetKeyDown (KeyCode.J)) 		{myState = States.corridor_disguise;} 
	}

	void state_corridor3 (){
		text.text = "Damn this corridor is boring, you consider using the mop handle " +
					"from the closet as a lightsabre to do some sweet sword moves, " +
					"but seriously what now?\n\nDo you want to:\nTry the stairs again, " +
					"press S\nor Go back to the closet, press C";
		if (Input.GetKeyDown (KeyCode.S)) 			{myState = States.stairs2;} 	
		else if (Input.GetKeyDown (KeyCode.C)) 		{myState = States.closet2;} 
	}

	void state_stairs2 (){
		text.text = "Yep, the guards at the top are definitely playing poker. Damn you " +
					"miss that game. First thing you decide to do when you get out is " +
					"phone up the guys and organise a game... actually screw those guys! " +
					"Those arseholes haven't come to visit once!!\n\nPress R to return to " +
					"the corridor";
		if (Input.GetKeyDown (KeyCode.R)) 			{myState = States.corridor3;} 	 
	}

	void state_corridor_disguise() {
		text.text = "This jumpsuit is awesome. There was even a fake mustache and glasses " +
					"in the pocket. Looking at yourself in your mirror, you can hardly " +
					"recognise yourself. You could probably walk right past the guards " +
					"like this. Sweet!\n\nPress S to go check out the stairs.";
		
		if (Input.GetKeyDown (KeyCode.S)) 		{myState = States.stairs3;} 
	}

	void state_stairs3 (){
		text.text = "You walk casually up the stairs and try not to look at the table " + 
					"where the guards are sitting as you walk past. One of the guards " +
					"sees you approach the door to the outside, slams down his cards " +
					"and says 'Read 'em and weep boys, 3 ladies!', then he stands up " +
					"and saunters over to the door infront of you, briefly making eye " +
					"contact and giving you a slight nod before he unlocks the door and " +
					"lets you out\n\nPress W to walk through the door";
		if (Input.GetKeyDown (KeyCode.W)) 		{myState = States.freedom;} 
	}

	void state_freedom (){
		text.text = "Whoooo Freeeeeeedoooooom!!";
	}
}