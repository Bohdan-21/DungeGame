using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LicenseURL : MonoBehaviour
{
	
    private const string PenzillaUI = "https://penzilla.itch.io/basic-gui-bundle";
	private const string MusicByClementPanchout = "http://www.clementpanchout.com/";
	private const string MusicByMinifantazyDungeon = "https://leohpaz.itch.io/minifantasy-dungeon-sfx-pack";
	private const string SoundByRPGEssentialsSFX = "https://leohpaz.itch.io/rpg-essentials-sfx-free";
	private const string SoundByZapslat = "https://www.zapsplat.com/";
	private const string DevByKlinch = "https://klinch.itch.io/";

	public void OpenPenzillaUI() => 
		Application.OpenURL(PenzillaUI);

	public void OpenMusicByClementPanchout() =>
		Application.OpenURL(MusicByClementPanchout);
		
	public void OpenMusicByMinifantazyDungeon() =>
		Application.OpenURL(MusicByMinifantazyDungeon);
		
	public void OpemSoundByRPGEssentialsSFX() => 
		Application.OpenURL(SoundByRPGEssentialsSFX);
		
	public void OpenSoundByZapslat() =>
		Application.OpenURL(SoundByZapslat);
		
	public void OpenDevByKlinch() =>
		Application.OpenURL(DevByKlinch);
}
