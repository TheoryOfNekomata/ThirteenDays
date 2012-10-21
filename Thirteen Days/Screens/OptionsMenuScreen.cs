#region File Description
//-----------------------------------------------------------------------------
// OptionsMenuScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using Microsoft.Xna.Framework;
#endregion

namespace ThirteenDays {
	/// <summary>
	/// The options screen is brought up over the top of the main menu
	/// screen, and gives the user a chance to configure the game
	/// in various hopefully useful ways.
	/// </summary>
	class OptionsMenuScreen : MenuScreen {
		#region Fields

		MenuEntry meAudio;
		MenuEntry meVideo;
		MenuEntry meControls;
		MenuEntry meLanguage;

		enum Ungulate {
			BactrianCamel,
			Dromedary,
			Llama,
		}

		static Ungulate currentUngulate = Ungulate.Dromedary;

		static bool frobnicate = true;

		static int elf = 23;

		#endregion

		#region Initialization


		/// <summary>
		/// Constructor.
		/// </summary>
		public OptionsMenuScreen()
			: base("options") {
			// Create our menu entries.
			meAudio = new MenuEntry(string.Empty);
			meVideo = new MenuEntry(string.Empty);
			meControls = new MenuEntry(string.Empty);
			meLanguage = new MenuEntry(string.Empty);

			SetMenuEntryText();

			MenuEntry back = new MenuEntry("back");

			// Hook up menu event handlers.
			meAudio.Selected += UngulateMenuEntrySelected;
			meVideo.Selected += ElfMenuEntrySelected;
			meControls.Selected += FrobnicateMenuEntrySelected;
			meLanguage.Selected += LanguageMenuEntrySelected;
			back.Selected += OnCancel;

			// Add entries to the menu.
			MenuEntries.Add(meAudio);
			MenuEntries.Add(meVideo);
			MenuEntries.Add(meControls);
			MenuEntries.Add(meLanguage);
			MenuEntries.Add(back);
		}


		/// <summary>
		/// Fills in the latest values for the options screen menu text.
		/// </summary>
		void SetMenuEntryText() {
			meAudio.Text = I18N._("audio") + ": " + currentUngulate;
			meVideo.Text = I18N._("video") + ": " + elf;
			meControls.Text = I18N._("controls") + ": " + (frobnicate ? "on" : "off");
			meLanguage.Text = I18N._("language") + ": " + I18N._(I18N.CurrentLanguage);
		}


		#endregion

		#region Handle Input


		/// <summary>
		/// Event handler for when the Ungulate menu entry is selected.
		/// </summary>
		void UngulateMenuEntrySelected(object sender, PlayerIndexEventArgs e) {
			currentUngulate++;

			if(currentUngulate > Ungulate.Llama)
				currentUngulate = 0;

			SetMenuEntryText();
		}


		/// <summary>
		/// Event handler for when the Language menu entry is selected.
		/// </summary>
		void LanguageMenuEntrySelected(object sender, PlayerIndexEventArgs e) {
			I18N.currentLanguage = (I18N.currentLanguage + 1) % I18N.AvailableLanguages.Length;

			SetMenuEntryText();
		}


		/// <summary>
		/// Event handler for when the Frobnicate menu entry is selected.
		/// </summary>
		void FrobnicateMenuEntrySelected(object sender, PlayerIndexEventArgs e) {
			frobnicate = !frobnicate;

			SetMenuEntryText();
		}


		/// <summary>
		/// Event handler for when the Elf menu entry is selected.
		/// </summary>
		void ElfMenuEntrySelected(object sender, PlayerIndexEventArgs e) {
			elf++;

			SetMenuEntryText();
		}


		#endregion
	}
}
