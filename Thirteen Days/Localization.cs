using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThirteenDays {
	class I18N {
		public static Dictionary<string, Dictionary<string, string>> message = new Dictionary<string, Dictionary<string, string>>() {
		{
			"english",
			new Dictionary<string, string>() {
				{ "", "" },
				{ "main menu", "main menu" },
				{ "start game", "start game" },
				{ "options", "options" },
				{ "exit", "exit" },
				{ "back", "back" },

				{ "audio", "audio" },

				{ "video", "video" },

				{ "controls", "controls" },
				
				{ "language", "language" },
				{ "english", "english" },
				{ "japanese", "japanese" },

				{ "ok", "ok" },
				{ "cancel", "cancel" },

				{ "loading", "loading" },



				{ "resume", "resume" },

				{ "paused", "paused" }
			}
		}, 
		{
			"japanese",
			new Dictionary<string, string>() {
				{ "", "" },
				{ "main menu", "トップメニュー" },
				{ "start game", "スタート" },
				{ "options", "オプション" },
				{ "exit", "終了" },
				{ "back", "戻る" },

				{ "audio", "オーディオ" },

				{ "video", "ビデオ" },

				{ "controls", "コントロール" },
				
				{ "language", "言語" },
				{ "english", "英語" },
				{ "japanese", "日本語" },

				{ "ok", "ok" },
				{ "cancel", "キャンセル" },

				{ "loading", "ロード中" },



				{ "resume", "遣り直す" },

				{ "paused", "中止しました" }
			}
		}};

		public static string _(string msgid) {
			try {
				return message[AvailableLanguages[currentLanguage]][msgid];
			} catch(Exception) {
				return msgid;
			}
		}

		public static int currentLanguage = 0;
		public static string[] AvailableLanguages = { "english", "japanese" };

		public static string CurrentLanguage {
			get {
				return AvailableLanguages[currentLanguage];
			}
		}
	}
}
