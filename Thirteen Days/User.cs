using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ThirteenDays {
	static class User {
		public static Dictionary<Action, List<object>> KeyMapping
			= new Dictionary<Action, List<object>>()
			{
				{ Action.MoveLeft,			new List<object>() { Keys.Left } },
				{ Action.MoveRight,			new List<object>() { Keys.Right } },
				{ Action.Jump,				new List<object>() { Keys.Up } },
				{ Action.LookUp,			new List<object>() { Keys.Up } },
				{ Action.Duck,				new List<object>() { Keys.Down } },
				{ Action.LookDown,			new List<object>() { Keys.Down } },
				{ Action.Attack,			new List<object>() { Keys.V } },
				{ Action.Interact,			new List<object>() { Keys.C } },
				{ Action.UseItem,			new List<object>() { Keys.X } },
				{ Action.Block,				new List<object>() { Keys.Z } },
				{ Action.NextWeapon,		new List<object>() { Keys.F } },
				{ Action.PreviousWeapon,	new List<object>() { Keys.A } },
				{ Action.SwapWeapons,		new List<object>() { Keys.Space } },
				{ Action.NextItem,			new List<object>() { Keys.D } },
				{ Action.PreviousItem,		new List<object>() { Keys.S } },
				{ Action.Pause,				new List<object>() { Keys.Enter } }
			};

		/// <summary>
		/// Checks if a control mapped to a certain action has been done.
		/// </summary>
		public static bool IsActionDone(Action action) {
			KeyboardState keyboardState = new KeyboardState();
			bool actionDone = false;

			foreach(object control in KeyMapping[action]) {
				if(control is Keys) {
					Keys key = (Keys) control;
					Keys[] pressedKeys = keyboardState.GetPressedKeys();
					foreach(Keys pressedKey in pressedKeys)
						actionDone = actionDone || (pressedKey == key);
				}
			}

			return actionDone;
		}
	}


	public enum Action {
		MoveLeft,
		MoveRight,
		Jump,
		LookUp,
		Duck,
		LookDown,
		Attack,
		Interact,
		UseItem,
		Block,
		NextWeapon,
		PreviousWeapon,
		SwapWeapons,
		NextItem,
		PreviousItem,
		Pause
	}
}
