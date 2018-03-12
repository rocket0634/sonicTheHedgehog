using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class sonicScript : MonoBehaviour {
	public KMBombInfo Bomb;
	public KMSelectable onButton;
	public KMSelectable offButton;
	public KMSelectable boots;
	public KMSelectable invincible;
	public KMSelectable life;
	public KMSelectable rings;
	public KMSelectable startButton;

	public KMAudio Audio;

	public Renderer pass1rend;
	public Renderer pass2rend;
	public Renderer pass3rend;
	public Renderer displayedImage;

	public Texture background;
	public Texture ringSprite;
	public Texture onOff;
	public Texture titleScreen;
	public Texture[] pic1Options;
	public Texture[] pic2Options;
	public Texture[] pic3Options;
	public Texture[] pic4Options;

	int stage = 1;
	static int moduleIdCounter = 1;
	int moduleId;

	string bootsPress;
	string invinciblePress;
	string lifePress;
	string ringsPress;
	string level1;
	string level2;
	string level3;
	Texture pic1;
	Texture pic2;
	Texture pic3;
	Texture pic4;
	private string TwitchHelpMessage = "Type '!{0} press' followed by either TVon, TVoff, RBt, In, EL, Rg or start (e.g. !{0} press TVon; !{0} press RBt;)";

	public KMSelectable[] ProcessTwitchCommand(string command)
	{
			if (command.Equals("press TVon", StringComparison.InvariantCultureIgnoreCase))
			{
					return new KMSelectable[] { onButton };
			}
			else if (command.Equals("press TVoff", StringComparison.InvariantCultureIgnoreCase))
			{
					return new KMSelectable[] { offButton };
			}
			else if (command.Equals("press RBt", StringComparison.InvariantCultureIgnoreCase))
			{
					return new KMSelectable[] { boots };
			}
			else if (command.Equals("press In", StringComparison.InvariantCultureIgnoreCase))
			{
					return new KMSelectable[] { invincible };
			}
			else if (command.Equals("press EL", StringComparison.InvariantCultureIgnoreCase))
			{
					return new KMSelectable[] { life };
			}
			else if (command.Equals("press Rg", StringComparison.InvariantCultureIgnoreCase))
			{
					return new KMSelectable[] { rings };
			}
			else if (command.Equals("press start", StringComparison.InvariantCultureIgnoreCase))
			{
					return new KMSelectable[] { startButton };
			}
			return null;
	}

	void Awake ()
	{
			moduleId = moduleIdCounter++;
			GetComponent<KMBombModule>().OnActivate += Begin;
			onButton.OnInteract += delegate () { OnonButton(); return false; };
			offButton.OnInteract += delegate () { OnoffButton(); return false; };
			boots.OnInteract += delegate () { ButtonPress ("boots"); return false; };
			invincible.OnInteract += delegate () { ButtonPress ("invincible"); return false; };
			life.OnInteract += delegate () { ButtonPress ("life"); return false; };
			rings.OnInteract += delegate () { ButtonPress ("rings"); return false; };
			startButton.OnInteract += delegate () { ButtonPress ("startButton"); return false; };
	}

	void Reset ()
	{
			displayedImage.GetComponent<Renderer>().material.mainTexture = pic4;
			pass1rend.GetComponent<Renderer>().enabled = false;
			pass2rend.GetComponent<Renderer>().enabled = false;
			pass3rend.GetComponent<Renderer>().enabled = false;
			stage = 1;
	}

	void Begin ()
	{
			int bootsPick = UnityEngine.Random.Range(0, 16);
			switch (bootsPick)
			{
					case 0:
							bootsPress = "boss";
							break;
					case 1:
							bootsPress = "breathe";
							break;
					case 2:
							bootsPress = "continueSFX";
							break;
					case 3:
							bootsPress = "drown";
							break;
					case 4:
							bootsPress = "emerald";
							break;
					case 5:
							bootsPress = "extraLife";
							break;
					case 6:
							bootsPress = "finalZone";
							break;
					case 7:
							bootsPress = "invincibleSFX";
							break;
					case 8:
							bootsPress = "jump";
							break;
					case 9:
							bootsPress = "lamppost";
							break;
					case 10:
							bootsPress = "marbleZone";
							break;
					case 11:
							bootsPress = "bumper";
							break;
					case 12:
							bootsPress = "skid";
							break;
					case 13:
							bootsPress = "spikes";
							break;
					case 14:
							bootsPress = "spin";
							break;
					case 15:
							bootsPress = "spring";
							break;
			}

			int invinciblePick = UnityEngine.Random.Range(0, 16);
			switch (invinciblePick)
			{
					case 0:
							invinciblePress = "boss";
							break;
					case 1:
							invinciblePress = "breathe";
							break;
					case 2:
							invinciblePress = "continueSFX";
							break;
					case 3:
							invinciblePress = "drown";
							break;
					case 4:
							invinciblePress = "emerald";
							break;
					case 5:
							invinciblePress = "extraLife";
							break;
					case 6:
							invinciblePress = "finalZone";
							break;
					case 7:
							invinciblePress = "invincibleSFX";
							break;
					case 8:
							invinciblePress = "jump";
							break;
					case 9:
							invinciblePress = "lamppost";
							break;
					case 10:
							invinciblePress = "marbleZone";
							break;
					case 11:
							invinciblePress = "bumper";
							break;
					case 12:
							invinciblePress = "skid";
							break;
					case 13:
							invinciblePress = "spikes";
							break;
					case 14:
							invinciblePress = "spin";
							break;
					case 15:
							invinciblePress = "spring";
							break;
			}

			int lifePick = UnityEngine.Random.Range(0, 16);
			switch (lifePick)
			{
					case 0:
							lifePress = "boss";
							break;
					case 1:
							lifePress = "breathe";
							break;
					case 2:
							lifePress = "continueSFX";
							break;
					case 3:
							lifePress = "drown";
							break;
					case 4:
							lifePress = "emerald";
							break;
					case 5:
							lifePress = "extraLife";
							break;
					case 6:
							lifePress = "finalZone";
							break;
					case 7:
							lifePress = "invincibleSFX";
							break;
					case 8:
							lifePress = "jump";
							break;
					case 9:
							lifePress = "lamppost";
							break;
					case 10:
							lifePress = "marbleZone";
							break;
					case 11:
							lifePress = "bumper";
							break;
					case 12:
							lifePress = "skid";
							break;
					case 13:
							lifePress = "spikes";
							break;
					case 14:
							lifePress = "spin";
							break;
					case 15:
							lifePress = "spring";
							break;
			}

			int ringsPick = UnityEngine.Random.Range(0, 16);
			switch (ringsPick)
			{
					case 0:
							ringsPress = "boss";
							break;
					case 1:
							ringsPress = "breathe";
							break;
					case 2:
							ringsPress = "continueSFX";
							break;
					case 3:
							ringsPress = "drown";
							break;
					case 4:
							ringsPress = "emerald";
							break;
					case 5:
							ringsPress = "extraLife";
							break;
					case 6:
							ringsPress = "finalZone";
							break;
					case 7:
							ringsPress = "invincibleSFX";
							break;
					case 8:
							ringsPress = "jump";
							break;
					case 9:
							ringsPress = "lamppost";
							break;
					case 10:
							ringsPress = "marbleZone";
							break;
					case 11:
							ringsPress = "bumper";
							break;
					case 12:
							ringsPress = "skid";
							break;
					case 13:
							ringsPress = "spikes";
							break;
					case 14:
							ringsPress = "spin";
							break;
					case 15:
							ringsPress = "spring";
							break;
			}
			Debug.LogFormat("[Sonic the Hedgehog #{0}] The boots monitor plays: {1}", moduleId, bootsPress);
			Debug.LogFormat("[Sonic the Hedgehog #{0}] The invincible monitor plays: {1}", moduleId, invinciblePress);
			Debug.LogFormat("[Sonic the Hedgehog #{0}] The life monitor plays: {1}", moduleId, lifePress);
			Debug.LogFormat("[Sonic the Hedgehog #{0}] The rings monitor plays: {1}", moduleId, ringsPress);


			int pic1Pick = UnityEngine.Random.Range(0, 5);
			pic1 = pic1Options[pic1Pick];

			int pic2Pick = UnityEngine.Random.Range(0, 5);
			pic2 = pic2Options[pic2Pick];

			int pic3Pick = UnityEngine.Random.Range(0, 5);
			pic3 = pic3Options[pic3Pick];

			int pic4Pick = UnityEngine.Random.Range(0,1);
			pic4 = pic4Options[pic4Pick];

			Debug.LogFormat("[Sonic the Hedgehog #{0}] The level 1 picture is: {1}", moduleId, pic1.name);
			Debug.LogFormat("[Sonic the Hedgehog #{0}] level 2 picture is: {1}", moduleId, pic2.name);
			Debug.LogFormat("[Sonic the Hedgehog #{0}] level 3 picture is: {1}", moduleId, pic3.name);



			if (pic1Pick == 0)
			{
					if (bootsPress == "marbleZone" || bootsPress == "boss" || bootsPress == "finalZone" || lifePress == "marbleZone" || lifePress == "boss" || lifePress == "finalZone" || invinciblePress == "marbleZone" || invinciblePress == "boss" || invinciblePress == "finalZone" || ringsPress == "marbleZone" || ringsPress == "boss" || ringsPress == "finalZone")
					{
							level1 = "invincible";
					}
					else if (bootsPress == lifePress || bootsPress == invinciblePress || bootsPress == ringsPress || lifePress == invinciblePress || lifePress == ringsPress || invinciblePress == ringsPress)
					{
							level1 = "boots";
					}
					else if (bootsPress == "emerald" || bootsPress == "spikes")
					{
							level1 = "life";
					}
					else
					{
							level1 = "rings";
					}
			}
			else if (pic1Pick == 1)
			{
					if (bootsPress == "marbleZone" || bootsPress == "boss" || bootsPress == "finalZone" || lifePress == "marbleZone" || lifePress == "boss" || lifePress == "finalZone" || invinciblePress == "marbleZone" || invinciblePress == "boss" || invinciblePress == "finalZone" || ringsPress == "marbleZone" || ringsPress == "boss" || ringsPress == "finalZone")
					{
							level1 = "boots";
					}
					else if (bootsPress == lifePress || bootsPress == invinciblePress || bootsPress == ringsPress || lifePress == invinciblePress || lifePress == ringsPress || invinciblePress == ringsPress)
					{
							level1 = "invincible";
					}
					else if (bootsPress == "emerald" || bootsPress == "spikes")
					{
							level1 = "life";
					}
					else
					{
							level1 = "rings";
					}
			}
			else if (pic1Pick == 2)
			{
					if (bootsPress == "marbleZone" || bootsPress == "boss" || bootsPress == "finalZone" || lifePress == "marbleZone" || lifePress == "boss" || lifePress == "finalZone" || invinciblePress == "marbleZone" || invinciblePress == "boss" || invinciblePress == "finalZone" || ringsPress == "marbleZone" || ringsPress == "boss" || ringsPress == "finalZone")
					{
							level1 = "life";
					}
					else if (bootsPress == lifePress || bootsPress == invinciblePress || bootsPress == ringsPress || lifePress == invinciblePress || lifePress == ringsPress || invinciblePress == ringsPress)
					{
							level1 = "rings";
					}
					else if (bootsPress == "emerald" || bootsPress == "spikes")
					{
							level1 = "boots";
					}
					else
					{
							level1 = "invincible";
					}
			}
			else if (pic1Pick == 3)
			{
					if (bootsPress == "marbleZone" || bootsPress == "boss" || bootsPress == "finalZone" || lifePress == "marbleZone" || lifePress == "boss" || lifePress == "finalZone" || invinciblePress == "marbleZone" || invinciblePress == "boss" || invinciblePress == "finalZone" || ringsPress == "marbleZone" || ringsPress == "boss" || ringsPress == "finalZone")
					{
							level1 = "invincible";
					}
					else if (bootsPress == lifePress || bootsPress == invinciblePress || bootsPress == ringsPress || lifePress == invinciblePress || lifePress == ringsPress || invinciblePress == ringsPress)
					{
							level1 = "life";
					}
					else if (bootsPress == "emerald" || bootsPress == "spikes")
					{
							level1 = "rings";
					}
					else
					{
							level1 = "boots";
					}
			}
			else if (pic1Pick == 4)
			{
					if (bootsPress == "marbleZone" || bootsPress == "boss" || bootsPress == "finalZone" || lifePress == "marbleZone" || lifePress == "boss" || lifePress == "finalZone" || invinciblePress == "marbleZone" || invinciblePress == "boss" || invinciblePress == "finalZone" || ringsPress == "marbleZone" || ringsPress == "boss" || ringsPress == "finalZone")
					{
							level1 = "rings";
					}
					else if (bootsPress == lifePress || bootsPress == invinciblePress || bootsPress == ringsPress || lifePress == invinciblePress || lifePress == ringsPress || invinciblePress == ringsPress)
					{
							level1 = "boots";
					}
					else if (bootsPress == "emerald" || bootsPress == "spikes")
					{
							level1 = "invincible";
					}
					else
					{
							level1 = "life";
					}
			}


			if (pic2Pick == 0)
			{
					if (lifePress == "extraLife" || invinciblePress == "invincibleSFX")
					{
							level2 = "rings";
					}
					else if (lifePress == "lamppost" || lifePress == "marbleZone" || bootsPress == "lamppost" || bootsPress == "marbleZone" || invinciblePress == "lamppost" || invinciblePress == "marbleZone" || ringsPress == "lamppost" || ringsPress == "marbleZone")
					{
							level2 = "boots";
					}
					else if (bootsPress == "spin" || ringsPress == "spring")
					{
							level2 = "life";
					}
					else if (pic1Pick == 4)
					{
							level2 = "boots";
					}
					else if (lifePress == "spikes" || bootsPress == "spikes" || invinciblePress == "spikes" || ringsPress == "spikes")
					{
							level2 = "invincible";
					}
					else if (lifePress == "drown" || bootsPress == "drown" || invinciblePress == "drown" || ringsPress == "drown" || pic1Pick == 3)
					{
							level2 = "life";
					}
					else if ((bootsPress == "boss" && invinciblePress == "emerald") || (bootsPress == "emerald" && invinciblePress == "boss") || (lifePress == "boss" && invinciblePress == "emerald") || (lifePress == "emerald" && invinciblePress == "boss") || (ringsPress == "boss" && lifePress == "emerald") || (ringsPress == "emerald" && lifePress == "boss") || (bootsPress == "skid" && invinciblePress == "emerald") || (bootsPress == "emerald" && invinciblePress == "skid") || (lifePress == "skid" && invinciblePress == "emerald") || (lifePress == "emerald" && invinciblePress == "skid") || (ringsPress == "skid" && lifePress == "emerald") || (ringsPress == "emerald" && lifePress == "skid"))
					{
							level2 = "rings";
					}
					else
					{
							level2 = "invincible";
					}
			}
			else if (pic2Pick == 1)
			{
					if (lifePress == "extraLife" || invinciblePress == "invincibleSFX")
					{
							level2 = "invincible";
					}
					else if (lifePress == "lamppost" || lifePress == "marbleZone" || bootsPress == "lamppost" || bootsPress == "marbleZone" || invinciblePress == "lamppost" || invinciblePress == "marbleZone" || ringsPress == "lamppost" || ringsPress == "marbleZone")
					{
							level2 = "life";
					}
					else if (bootsPress == "spin" || ringsPress == "spring")
					{
							level2 = "boots";
					}
					else if (pic1Pick == 4)
					{
							level2 = "rings";
					}
					else if (lifePress == "spikes" || bootsPress == "spikes" || invinciblePress == "spikes" || ringsPress == "spikes")
					{
							level2 = "rings";
					}
					else if (lifePress == "drown" || bootsPress == "drown" || invinciblePress == "drown" || ringsPress == "drown" || pic1Pick == 3)
					{
							level2 = "boots";
					}
					else if ((bootsPress == "boss" && invinciblePress == "emerald") || (bootsPress == "emerald" && invinciblePress == "boss") || (lifePress == "boss" && invinciblePress == "emerald") || (lifePress == "emerald" && invinciblePress == "boss") || (ringsPress == "boss" && lifePress == "emerald") || (ringsPress == "emerald" && lifePress == "boss") || (bootsPress == "skid" && invinciblePress == "emerald") || (bootsPress == "emerald" && invinciblePress == "skid") || (lifePress == "skid" && invinciblePress == "emerald") || (lifePress == "emerald" && invinciblePress == "skid") || (ringsPress == "skid" && lifePress == "emerald") || (ringsPress == "emerald" && lifePress == "skid"))
					{
							level2 = "life";
					}
					else
					{
							level2 = "invincible";
					}
			}
			else if (pic2Pick == 2)
			{
					if (lifePress == "extraLife" || invinciblePress == "invincibleSFX")
					{
							level2 = "invincible";
					}
					else if (lifePress == "lamppost" || lifePress == "marbleZone" || bootsPress == "lamppost" || bootsPress == "marbleZone" || invinciblePress == "lamppost" || invinciblePress == "marbleZone" || ringsPress == "lamppost" || ringsPress == "marbleZone")
					{
							level2 = "rings";
					}
					else if (bootsPress == "spin" || ringsPress == "spring")
					{
							level2 = "invincible";
					}
					else if (pic1Pick == 4)
					{
							level2 = "life";
					}
					else if (lifePress == "spikes" || bootsPress == "spikes" || invinciblePress == "spikes" || ringsPress == "spikes")
					{
							level2 = "boots";
					}
					else if (lifePress == "drown" || bootsPress == "drown" || invinciblePress == "drown" || ringsPress == "drown" || pic1Pick == 3)
					{
							level2 = "rings";
					}
					else if ((bootsPress == "boss" && invinciblePress == "emerald") || (bootsPress == "emerald" && invinciblePress == "boss") || (lifePress == "boss" && invinciblePress == "emerald") || (lifePress == "emerald" && invinciblePress == "boss") || (ringsPress == "boss" && lifePress == "emerald") || (ringsPress == "emerald" && lifePress == "boss") || (bootsPress == "skid" && invinciblePress == "emerald") || (bootsPress == "emerald" && invinciblePress == "skid") || (lifePress == "skid" && invinciblePress == "emerald") || (lifePress == "emerald" && invinciblePress == "skid") || (ringsPress == "skid" && lifePress == "emerald") || (ringsPress == "emerald" && lifePress == "skid"))
					{
							level2 = "boots";
					}
					else
					{
							level2 = "life";
					}
			}
			else if (pic2Pick == 3)
			{
					if (lifePress == "extraLife" || invinciblePress == "invincibleSFX")
					{
							level2 = "boots";
					}
					else if (lifePress == "lamppost" || lifePress == "marbleZone" || bootsPress == "lamppost" || bootsPress == "marbleZone" || invinciblePress == "lamppost" || invinciblePress == "marbleZone" || ringsPress == "lamppost" || ringsPress == "marbleZone")
					{
							level2 = "life";
					}
					else if (bootsPress == "spin" || ringsPress == "spring")
					{
							level2 = "rings";
					}
					else if (pic1Pick == 4)
					{
							level2 = "invincible";
					}
					else if (lifePress == "spikes" || bootsPress == "spikes" || invinciblePress == "spikes" || ringsPress == "spikes")
					{
							level2 = "life";
					}
					else if (lifePress == "drown" || bootsPress == "drown" || invinciblePress == "drown" || ringsPress == "drown" || pic1Pick == 3)
					{
							level2 = "rings";
					}
					else if ((bootsPress == "boss" && invinciblePress == "emerald") || (bootsPress == "emerald" && invinciblePress == "boss") || (lifePress == "boss" && invinciblePress == "emerald") || (lifePress == "emerald" && invinciblePress == "boss") || (ringsPress == "boss" && lifePress == "emerald") || (ringsPress == "emerald" && lifePress == "boss") || (bootsPress == "skid" && invinciblePress == "emerald") || (bootsPress == "emerald" && invinciblePress == "skid") || (lifePress == "skid" && invinciblePress == "emerald") || (lifePress == "emerald" && invinciblePress == "skid") || (ringsPress == "skid" && lifePress == "emerald") || (ringsPress == "emerald" && lifePress == "skid"))
					{
							level2 = "invincible";
					}
					else
					{
							level2 = "boots";
					}
			}
			else if (pic2Pick == 4)
			{
					if (lifePress == "extraLife" || invinciblePress == "invincibleSFX")
					{
							level2 = "life";
					}
					else if (lifePress == "lamppost" || lifePress == "marbleZone" || bootsPress == "lamppost" || bootsPress == "marbleZone" || invinciblePress == "lamppost" || invinciblePress == "marbleZone" || ringsPress == "lamppost" || ringsPress == "marbleZone")
					{
							level2 = "rings";
					}
					else if (bootsPress == "spin" || ringsPress == "spring")
					{
							level2 = "boots";
					}
					else if (pic1Pick == 4)
					{
							level2 = "boots";
					}
					else if (lifePress == "spikes" || bootsPress == "spikes" || invinciblePress == "spikes" || ringsPress == "spikes")
					{
							level2 = "life";
					}
					else if (lifePress == "drown" || bootsPress == "drown" || invinciblePress == "drown" || ringsPress == "drown" || pic1Pick == 3)
					{
							level2 = "invincible";
					}
					else if ((bootsPress == "boss" && invinciblePress == "emerald") || (bootsPress == "emerald" && invinciblePress == "boss") || (lifePress == "boss" && invinciblePress == "emerald") || (lifePress == "emerald" && invinciblePress == "boss") || (ringsPress == "boss" && lifePress == "emerald") || (ringsPress == "emerald" && lifePress == "boss") || (bootsPress == "skid" && invinciblePress == "emerald") || (bootsPress == "emerald" && invinciblePress == "skid") || (lifePress == "skid" && invinciblePress == "emerald") || (lifePress == "emerald" && invinciblePress == "skid") || (ringsPress == "skid" && lifePress == "emerald") || (ringsPress == "emerald" && lifePress == "skid"))
					{
							level2 = "invincible";
					}
					else
					{
							level2 = "rings";
					}
			}


			if (pic3Pick == 0)
			{
					if (lifePress == "invincibleSFX" || invinciblePress == "extraLife")
					{
							level3 = "life";
					}
					else if (pic1Pick == 2 && pic2Pick == 0)
					{
							level3 = "rings";
					}
					else if (bootsPress == "emerald" || invinciblePress == "emerald" || ringsPress == "emerald" || lifePress == "emerald" || pic2Pick == 2)
					{
							level3 = "boots";
					}
					else if ((bootsPress == "marbleZone" || bootsPress == "boss" || bootsPress == "finalZone" || lifePress == "marbleZone" || lifePress == "boss" || lifePress == "finalZone" || invinciblePress == "marbleZone" || invinciblePress == "boss" || invinciblePress == "finalZone" || ringsPress == "marbleZone" || ringsPress == "boss" || ringsPress == "finalZone") && (ringsPress == "spikes" || invinciblePress == "spikes" || lifePress == "spikes" || bootsPress == "spikes"))
					{
							level3 = "boots";
					}
					else if (pic1Pick == 0 || ringsPress == "continueSFX")
					{
							level3 = "invincible";
					}
					else if ((bootsPress == "skid" && invinciblePress == "spikes") || (bootsPress == "spikes" && invinciblePress == "skid") || (lifePress == "skid" && invinciblePress == "spikes") || (lifePress == "spikes" && invinciblePress == "skid") || (ringsPress == "spikes" && lifePress == "skid") || (ringsPress == "skid" && lifePress == "spikes") || (bootsPress == "spin" && invinciblePress == "spring") || (bootsPress == "spring" && invinciblePress == "spin") || (lifePress == "spring" && invinciblePress == "spin") || (lifePress == "spin" && invinciblePress == "spring") || (ringsPress == "spin" && lifePress == "spring") || (ringsPress == "spring" && lifePress == "spin"))
					{
							level3 = "rings";
					}
					else if (bootsPress == "finalZone" || ringsPress == "finalZone" || lifePress == "finalZone" || invinciblePress == "finalZone" || pic2Pick == 3)
					{
							level3 = "invincible";
					}
					else if ((bootsPress == "drown" && invinciblePress == "jump") || (bootsPress == "jump" && invinciblePress == "drown") || (lifePress == "drown" && invinciblePress == "jump") || (lifePress == "jump" && invinciblePress == "drown") || (ringsPress == "drown" && lifePress == "jump") || (ringsPress == "jump" && lifePress == "drown") || (bootsPress == "drown" && invinciblePress == "bumper") || (bootsPress == "bumper" && invinciblePress == "drown") || (lifePress == "drown" && invinciblePress == "bumper") || (lifePress == "bumper" && invinciblePress == "drown") || (ringsPress == "drown" && lifePress == "bumper") || (ringsPress == "bumper" && lifePress == "drown"))
					{
							level3 = "life";
					}
					else if ((bootsPress == "lamppost" || invinciblePress == "lamppost" || ringsPress == "lamppost" || lifePress == "lamppost") && (pic2Pick == 4))
					{
							level3 = "life";
					}
					else if (bootsPress == "finalZone" || invinciblePress == "finalZone" || ringsPress == "finalZone" || lifePress == "finalZone" || bootsPress == "spring" || invinciblePress == "spring" || ringsPress == "spring" || lifePress == "spring")
					{
							level3 = "boots";
					}
					else if (pic1Pick == 1 && pic2Pick == 1)
					{
							level3 = "invincible";
					}
					else
					{
							level3 = "rings";
					}
			}
			else if (pic3Pick == 1)
			{
					if (lifePress == "invincibleSFX" || invinciblePress == "extraLife")
					{
							level3 = "boots";
					}
					else if (pic1Pick == 2 && pic2Pick == 0)
					{
							level3 = "life";
					}
					else if (bootsPress == "emerald" || invinciblePress == "emerald" || ringsPress == "emerald" || lifePress == "emerald" || pic2Pick == 2)
					{
							level3 = "invincible";
					}
					else if ((bootsPress == "marbleZone" || bootsPress == "boss" || bootsPress == "finalZone" || lifePress == "marbleZone" || lifePress == "boss" || lifePress == "finalZone" || invinciblePress == "marbleZone" || invinciblePress == "boss" || invinciblePress == "finalZone" || ringsPress == "marbleZone" || ringsPress == "boss" || ringsPress == "finalZone") && (ringsPress == "spikes" || invinciblePress == "spikes" || lifePress == "spikes" || bootsPress == "spikes"))
					{
							level3 = "boots";
					}
					else if (pic1Pick == 0 || ringsPress == "continueSFX")
					{
							level3 = "rings";
					}
					else if ((bootsPress == "skid" && invinciblePress == "spikes") || (bootsPress == "spikes" && invinciblePress == "skid") || (lifePress == "skid" && invinciblePress == "spikes") || (lifePress == "spikes" && invinciblePress == "skid") || (ringsPress == "spikes" && lifePress == "skid") || (ringsPress == "skid" && lifePress == "spikes") || (bootsPress == "spin" && invinciblePress == "spring") || (bootsPress == "spring" && invinciblePress == "spin") || (lifePress == "spring" && invinciblePress == "spin") || (lifePress == "spin" && invinciblePress == "spring") || (ringsPress == "spin" && lifePress == "spring") || (ringsPress == "spring" && lifePress == "spin"))
					{
							level3 = "invincible";
					}
					else if (bootsPress == "finalZone" || ringsPress == "finalZone" || lifePress == "finalZone" || invinciblePress == "finalZone" || pic2Pick == 3)
					{
							level3 = "life";
					}
					else if ((bootsPress == "drown" && invinciblePress == "jump") || (bootsPress == "jump" && invinciblePress == "drown") || (lifePress == "drown" && invinciblePress == "jump") || (lifePress == "jump" && invinciblePress == "drown") || (ringsPress == "drown" && lifePress == "jump") || (ringsPress == "jump" && lifePress == "drown") || (bootsPress == "drown" && invinciblePress == "bumper") || (bootsPress == "bumper" && invinciblePress == "drown") || (lifePress == "drown" && invinciblePress == "bumper") || (lifePress == "bumper" && invinciblePress == "drown") || (ringsPress == "drown" && lifePress == "bumper") || (ringsPress == "bumper" && lifePress == "drown"))
					{
							level3 = "invincible";
					}
					else if ((bootsPress == "lamppost" || invinciblePress == "lamppost" || ringsPress == "lamppost" || lifePress == "lamppost") && (pic2Pick == 4))
					{
							level3 = "boots";
					}
					else if (bootsPress == "finalZone" || invinciblePress == "finalZone" || ringsPress == "finalZone" || lifePress == "finalZone" || bootsPress == "spring" || invinciblePress == "spring" || ringsPress == "spring" || lifePress == "spring")
					{
							level3 = "life";
					}
					else if (pic1Pick == 1 && pic2Pick == 1)
					{
							level3 = "invincible";
					}
					else
					{
							level3 = "boots";
					}
			}
			else if (pic3Pick == 2)
			{
					if (lifePress == "invincibleSFX" || invinciblePress == "extraLife")
					{
							level3 = "rings";
					}
					else if (pic1Pick == 2 && pic2Pick == 0)
					{
							level3 = "boots";
					}
					else if (bootsPress == "emerald" || invinciblePress == "emerald" || ringsPress == "emerald" || lifePress == "emerald" || pic2Pick == 2)
					{
							level3 = "life";
					}
					else if ((bootsPress == "marbleZone" || bootsPress == "boss" || bootsPress == "finalZone" || lifePress == "marbleZone" || lifePress == "boss" || lifePress == "finalZone" || invinciblePress == "marbleZone" || invinciblePress == "boss" || invinciblePress == "finalZone" || ringsPress == "marbleZone" || ringsPress == "boss" || ringsPress == "finalZone") && (ringsPress == "spikes" || invinciblePress == "spikes" || lifePress == "spikes" || bootsPress == "spikes"))
					{
							level3 = "invincible";
					}
					else if (pic1Pick == 0 || ringsPress == "continueSFX")
					{
							level3 = "boots";
					}
					else if ((bootsPress == "skid" && invinciblePress == "spikes") || (bootsPress == "spikes" && invinciblePress == "skid") || (lifePress == "skid" && invinciblePress == "spikes") || (lifePress == "spikes" && invinciblePress == "skid") || (ringsPress == "spikes" && lifePress == "skid") || (ringsPress == "skid" && lifePress == "spikes") || (bootsPress == "spin" && invinciblePress == "spring") || (bootsPress == "spring" && invinciblePress == "spin") || (lifePress == "spring" && invinciblePress == "spin") || (lifePress == "spin" && invinciblePress == "spring") || (ringsPress == "spin" && lifePress == "spring") || (ringsPress == "spring" && lifePress == "spin"))
					{
							level3 = "life";
					}
					else if (bootsPress == "finalZone" || ringsPress == "finalZone" || lifePress == "finalZone" || invinciblePress == "finalZone" || pic2Pick == 3)
					{
							level3 = "boots";
					}
					else if ((bootsPress == "drown" && invinciblePress == "jump") || (bootsPress == "jump" && invinciblePress == "drown") || (lifePress == "drown" && invinciblePress == "jump") || (lifePress == "jump" && invinciblePress == "drown") || (ringsPress == "drown" && lifePress == "jump") || (ringsPress == "jump" && lifePress == "drown") || (bootsPress == "drown" && invinciblePress == "bumper") || (bootsPress == "bumper" && invinciblePress == "drown") || (lifePress == "drown" && invinciblePress == "bumper") || (lifePress == "bumper" && invinciblePress == "drown") || (ringsPress == "drown" && lifePress == "bumper") || (ringsPress == "bumper" && lifePress == "drown"))
					{
							level3 = "rings";
					}
					else if ((bootsPress == "lamppost" || invinciblePress == "lamppost" || ringsPress == "lamppost" || lifePress == "lamppost") && (pic2Pick == 4))
					{
							level3 = "life";
					}
					else if (bootsPress == "finalZone" || invinciblePress == "finalZone" || ringsPress == "finalZone" || lifePress == "finalZone" || bootsPress == "spring" || invinciblePress == "spring" || ringsPress == "spring" || lifePress == "spring")
					{
							level3 = "invincible";
					}
					else if (pic1Pick == 1 && pic2Pick == 1)
					{
							level3 = "boots";
					}
					else
					{
							level3 = "invincible";
					}
			}
			else if (pic3Pick == 3)
			{
					if (lifePress == "invincibleSFX" || invinciblePress == "extraLife")
					{
							level3 = "invincible";
					}
					else if (pic1Pick == 2 && pic2Pick == 0)
					{
							level3 = "life";
					}
					else if (bootsPress == "emerald" || invinciblePress == "emerald" || ringsPress == "emerald" || lifePress == "emerald" || pic2Pick == 2)
					{
							level3 = "rings";
					}
					else if ((bootsPress == "marbleZone" || bootsPress == "boss" || bootsPress == "finalZone" || lifePress == "marbleZone" || lifePress == "boss" || lifePress == "finalZone" || invinciblePress == "marbleZone" || invinciblePress == "boss" || invinciblePress == "finalZone" || ringsPress == "marbleZone" || ringsPress == "boss" || ringsPress == "finalZone") && (ringsPress == "spikes" || invinciblePress == "spikes" || lifePress == "spikes" || bootsPress == "spikes"))
					{
							level3 = "life";
					}
					else if (pic1Pick == 0 || ringsPress == "continueSFX")
					{
							level3 = "boots";
					}
					else if ((bootsPress == "skid" && invinciblePress == "spikes") || (bootsPress == "spikes" && invinciblePress == "skid") || (lifePress == "skid" && invinciblePress == "spikes") || (lifePress == "spikes" && invinciblePress == "skid") || (ringsPress == "spikes" && lifePress == "skid") || (ringsPress == "skid" && lifePress == "spikes") || (bootsPress == "spin" && invinciblePress == "spring") || (bootsPress == "spring" && invinciblePress == "spin") || (lifePress == "spring" && invinciblePress == "spin") || (lifePress == "spin" && invinciblePress == "spring") || (ringsPress == "spin" && lifePress == "spring") || (ringsPress == "spring" && lifePress == "spin"))
					{
							level3 = "invincible";
					}
					else if (bootsPress == "finalZone" || ringsPress == "finalZone" || lifePress == "finalZone" || invinciblePress == "finalZone" || pic2Pick == 3)
					{
							level3 = "rings";
					}
					else if ((bootsPress == "drown" && invinciblePress == "jump") || (bootsPress == "jump" && invinciblePress == "drown") || (lifePress == "drown" && invinciblePress == "jump") || (lifePress == "jump" && invinciblePress == "drown") || (ringsPress == "drown" && lifePress == "jump") || (ringsPress == "jump" && lifePress == "drown") || (bootsPress == "drown" && invinciblePress == "bumper") || (bootsPress == "bumper" && invinciblePress == "drown") || (lifePress == "drown" && invinciblePress == "bumper") || (lifePress == "bumper" && invinciblePress == "drown") || (ringsPress == "drown" && lifePress == "bumper") || (ringsPress == "bumper" && lifePress == "drown"))
					{
							level3 = "boots";
					}
					else if ((bootsPress == "lamppost" || invinciblePress == "lamppost" || ringsPress == "lamppost" || lifePress == "lamppost") && (pic2Pick == 4))
					{
							level3 = "invincible";
					}
					else if (bootsPress == "finalZone" || invinciblePress == "finalZone" || ringsPress == "finalZone" || lifePress == "finalZone" || bootsPress == "spring" || invinciblePress == "spring" || ringsPress == "spring" || lifePress == "spring")
					{
							level3 = "rings";
					}
					else if (pic1Pick == 1 && pic2Pick == 1)
					{
							level3 = "life";
					}
					else
					{
							level3 = "rings";
					}
			}
			else if (pic3Pick == 4)
			{
					if (lifePress == "invincibleSFX" || invinciblePress == "extraLife")
					{
							level3 = "boots";
					}
					else if (pic1Pick == 2 && pic2Pick == 0)
					{
							level3 = "invincible";
					}
					else if (bootsPress == "emerald" || invinciblePress == "emerald" || ringsPress == "emerald" || lifePress == "emerald" || pic2Pick == 2)
					{
							level3 = "boots";
					}
					else if ((bootsPress == "marbleZone" || bootsPress == "boss" || bootsPress == "finalZone" || lifePress == "marbleZone" || lifePress == "boss" || lifePress == "finalZone" || invinciblePress == "marbleZone" || invinciblePress == "boss" || invinciblePress == "finalZone" || ringsPress == "marbleZone" || ringsPress == "boss" || ringsPress == "finalZone") && (ringsPress == "spikes" || invinciblePress == "spikes" || lifePress == "spikes" || bootsPress == "spikes"))
					{
							level3 = "rings";
					}
					else if (pic1Pick == 0 || ringsPress == "continueSFX")
					{
							level3 = "life";
					}
					else if ((bootsPress == "skid" && invinciblePress == "spikes") || (bootsPress == "spikes" && invinciblePress == "skid") || (lifePress == "skid" && invinciblePress == "spikes") || (lifePress == "spikes" && invinciblePress == "skid") || (ringsPress == "spikes" && lifePress == "skid") || (ringsPress == "skid" && lifePress == "spikes") || (bootsPress == "spin" && invinciblePress == "spring") || (bootsPress == "spring" && invinciblePress == "spin") || (lifePress == "spring" && invinciblePress == "spin") || (lifePress == "spin" && invinciblePress == "spring") || (ringsPress == "spin" && lifePress == "spring") || (ringsPress == "spring" && lifePress == "spin"))
					{
							level3 = "boots";
					}
					else if (bootsPress == "finalZone" || ringsPress == "finalZone" || lifePress == "finalZone" || invinciblePress == "finalZone" || pic2Pick == 3)
					{
							level3 = "rings";
					}
					else if ((bootsPress == "drown" && invinciblePress == "jump") || (bootsPress == "jump" && invinciblePress == "drown") || (lifePress == "drown" && invinciblePress == "jump") || (lifePress == "jump" && invinciblePress == "drown") || (ringsPress == "drown" && lifePress == "jump") || (ringsPress == "jump" && lifePress == "drown") || (bootsPress == "drown" && invinciblePress == "bumper") || (bootsPress == "bumper" && invinciblePress == "drown") || (lifePress == "drown" && invinciblePress == "bumper") || (lifePress == "bumper" && invinciblePress == "drown") || (ringsPress == "drown" && lifePress == "bumper") || (ringsPress == "bumper" && lifePress == "drown"))
					{
							level3 = "life";
					}
					else if ((bootsPress == "lamppost" || invinciblePress == "lamppost" || ringsPress == "lamppost" || lifePress == "lamppost") && (pic2Pick == 4))
					{
							level3 = "rings";
					}
					else if (bootsPress == "finalZone" || invinciblePress == "finalZone" || ringsPress == "finalZone" || lifePress == "finalZone" || bootsPress == "spring" || invinciblePress == "spring" || ringsPress == "spring" || lifePress == "spring")
					{
							level3 = "invincible";
					}
					else if (pic1Pick == 1 && pic2Pick == 1)
					{
							level3 = "rings";
					}
					else
					{
							level3 = "life";
					}
			}
			Debug.LogFormat("[Sonic the Hedgehog #{0}] The level 1 answer is: {1}", moduleId, level1);
			Debug.LogFormat("[Sonic the Hedgehog #{0}] The level 2 answer is: {1}", moduleId, level2);
			Debug.LogFormat("[Sonic the Hedgehog #{0}] The level 3 answer is: {1}", moduleId, level3);

	}


		public void OnonButton()
		{
				GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
				GetComponent<KMSelectable>().AddInteractionPunch();

				if (displayedImage.GetComponent<Renderer>().enabled == true)
				{
						Audio.PlaySoundAtTransform("tvOffSFX", transform);
				}
				else
				{
				Audio.PlaySoundAtTransform("tvOnSFX", transform);
				}

				displayedImage.GetComponent<Renderer>().enabled = true;
		}

		public void OnoffButton()
		{
				GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
				GetComponent<KMSelectable>().AddInteractionPunch();
				displayedImage.GetComponent<Renderer>().enabled = false;
				Audio.PlaySoundAtTransform("tvOffSFX", transform);
		}

		public void ButtonPress(string buttonName)
		{
				GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
				GetComponent<KMSelectable>().AddInteractionPunch();

				switch (stage)
				{
						case 1:
						if (buttonName == "boots")
						{
							  Audio.PlaySoundAtTransform(bootsPress, transform);
						}
						else if (buttonName == "invincible")
						{
							  Audio.PlaySoundAtTransform(invinciblePress, transform);
						}
						else if (buttonName == "life")
						{
								Audio.PlaySoundAtTransform(lifePress, transform);
						}
						else if (buttonName == "rings")
						{
								Audio.PlaySoundAtTransform(ringsPress, transform);
						}
						else
						{
							Audio.PlaySoundAtTransform("gameStart", transform);
							displayedImage.GetComponent<Renderer>().material.mainTexture = pic1;
							stage++;
						}
						break;

						case 2:
						if (buttonName == level1)
						{
								displayedImage.GetComponent<Renderer>().material.mainTexture = pic2;
								Audio.PlaySoundAtTransform("ringCollect", transform);
								pass1rend.GetComponent<Renderer>().enabled = true;
								Debug.LogFormat("[Sonic the Hedgehog #{0}] You pressed the {1} monitor. That was correct.", moduleId, level1);
								stage++;
						}
						else
						{
								Audio.PlaySoundAtTransform("ringLoss", transform);
								GetComponent<KMBombModule>().HandleStrike();
								Debug.LogFormat("[Sonic the Hedgehog #{0}] Strike! You pressed the {1} monitor. I was expecting the {2} monitor. Module reset.", moduleId, buttonName, level1);
								Reset();
								Begin();
						}
						break;

						case 3:
						if (buttonName == level2)
						{
								displayedImage.GetComponent<Renderer>().material.mainTexture = pic3;
								Audio.PlaySoundAtTransform("ringCollect", transform);
								pass2rend.GetComponent<Renderer>().enabled = true;
								Debug.LogFormat("[Sonic the Hedgehog #{0}] You pressed the {1} monitor. That was correct.", moduleId, level2);
								stage++;
						}
						else
						{
								Audio.PlaySoundAtTransform("ringLoss", transform);
								GetComponent<KMBombModule>().HandleStrike();
								Debug.LogFormat("[Sonic the Hedgehog #{0}] Strike! You pressed the {1} monitor. I was expecting the {2} monitor. Module reset.", moduleId, buttonName, level2);
								Reset();
								Begin();
						}
						break;

						case 4:
						if (buttonName == level3)
						{
								displayedImage.GetComponent<Renderer>().material.mainTexture = pic4;
								Audio.PlaySoundAtTransform("disarmed", transform);
								pass3rend.GetComponent<Renderer>().enabled = true;
								GetComponent<KMBombModule>().HandlePass();
								Debug.LogFormat("[Sonic the Hedgehog #{0}] You pressed the {1} monitor. That was correct. Module disarmed.", moduleId, level3);
								stage++;
						}
						else
						{
								Audio.PlaySoundAtTransform("ringLoss", transform);
								GetComponent<KMBombModule>().HandleStrike();
								Debug.LogFormat("[Sonic the Hedgehog #{0}] Strike! You pressed the {1} monitor. I was expecting the {2} monitor. Module reset.", moduleId, buttonName, level3);
								Reset();
								Begin();
						}
						break;

						default:
						break;
				}
		}
	}
