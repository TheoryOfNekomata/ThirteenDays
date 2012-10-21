#region Descriptions

#region File
/**
 * Name:			Weapon.cs
 * Description:		Source file for weapons.
 * Date Created:	‎2012 ‎October ‎21 - 03:29 [+8]
 */
#endregion

#region Author
/**
 * Name:			Temoto-kun
 * E-mail Address:	kiiroifuriku@hotmail.com
 * Website:			http://nihilist-philanthropy.co.cc
 */
#endregion

#region Team
/**
 * Name:			theShrine
 * E-mail Address:	N/A
 * Website:			http://shrine.nihilist-philanthropy.co.cc
 */
#endregion

#region Project
/**
 * Name:			Thirteen Days
 * Genre:			Platformer, Shmup, RPG, Puzzle
 */
#endregion

#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace ThirteenDays.Elements {
	/// <summary>
	/// Weapon that the game avails for the player to use.
	/// </summary>
	abstract class Weapon {
		#region Fields


		string name;
		int minDamage;
		int maxDamage;


		#endregion

		#region Properties


		/// <summary>
		/// Gets or sets the <code>Weapon</code>'s name.
		/// </summary>
		public string Name {
			get { return name; }
			set { name = value; }
		}

		/// <summary>
		/// Gets or sets the <code>Weapon</code>'s minimum damage by hit points.
		/// </summary>
		public int MinimumDamage {
			get { return minDamage; }
			set { minDamage = value; }
		}

		/// <summary>
		/// Gets or sets the <code>Weapon</code>'s maximum damage by hit points.
		/// </summary>
		public int MaximumDamage {
			get { return maxDamage; }
			set { maxDamage = value; }
		}


		#endregion

		#region Initializations


		/// <summary>
		/// Creates a new <code>Weapon</code> given a range for damage hit points.
		/// </summary>
		/// <param name="name">The <code>Weapon</code>'s name.</param>
		/// <param name="minDamage">The <code>Weapon</code>'s minimum damage.</param>
		/// <param name="maxDamage">The <code>Weapon</code>'s maximum damage.</param>
		public Weapon(string name, int minDamage, int maxDamage) {
			Name = name;
			MinimumDamage = minDamage;
			MaximumDamage = maxDamage;
		}

		/// <summary>
		/// Creates a new <code>Weapon</code> with the specified damage. The damage of
		/// the <code>Weapon</code> will be static.
		/// </summary>
		/// <param name="name">The <code>Weapon</code>'s name.</param>
		/// <param name="damage">The <code>Weapon</code>'s damage.</param>
		public Weapon(string name, int damage)
			: this(name, damage, damage) {
			Name = name;
			MinimumDamage = damage;
			MaximumDamage = damage;
		}


		#endregion
	}


	/// <summary>
	/// Melee <code>Weapon</code>, used for CQC.
	/// </summary>
	class MeleeWeapon : Weapon {
		#region Fields


		MeleeWeaponType type;
		float length;


		#endregion

		#region Properties


		/// <summary>
		/// Gets or sets the <code>MeleeWeapon</code>'s <code>MeleeWeaponType</code>.
		/// </summary>
		public MeleeWeaponType Type {
			get { return type; }
			set { type = value; }
		}

		/// <summary>
		/// Gets or sets the <code>MeleeWeapon</code>'s length.
		/// </summary>
		public float Length {
			get { return length; }
			set { length = value; }
		}


		#endregion

		#region Initializations


		/// <summary>
		/// Creates a new <code>MeleeWeapon</code> with the specified damage. The damage of the <code>MeleeWeapon</code> will be static.
		/// </summary>
		/// <param name="name">The <code>MeleeWeapon</code>'s name.</param>
		/// <param name="damage">The <code>MeleeWeapon</code>'s damage.</param>
		/// <param name="type">The <code>MeleeWeapon</code>'s <code>MeleeWeaponType</code>.</param>
		/// <param name="length">The length of the <code>MeleeWeapon</code></param>
		public MeleeWeapon(string name, int damage, MeleeWeaponType type, float length)
			: this(name, damage, damage, type, length) {
		}

		/// <summary>
		/// Creates a new <code>MeleeWeapon</code> given a range for damage hit points.
		/// </summary>
		/// <param name="name">The <code>MeleeWeapon</code>'s name.</param>
		/// <param name="minDamage">The <code>MeleeWeapon</code>'s minimum damage.</param>
		/// <param name="maxDamage">The <code>MeleeWeapon</code>'s maximum damage.</param>
		/// <param name="type">The <code>MeleeWeapon</code>'s <code>MeleeWeaponType</code></param>
		/// <param name="length">The length of the <code>MeleeWeapon</code></param>
		public MeleeWeapon(string name, int minDamage, int maxDamage, MeleeWeaponType type, float length)
			: base(name, minDamage, maxDamage) {
			Type = type;
			Length = length;
		}


		#endregion
	}


	/// <summary>
	/// <code>MeleeWeapon</code> types.
	/// </summary>
	enum MeleeWeaponType {
		/// <summary>
		/// Melee weapon having a short grip length.
		/// </summary>
		ShortGrip,
		/// <summary>
		/// Melee weapon having a medium grip length.
		/// </summary>
		MediumGrip,
		/// <summary>
		/// Melee weapon having a long grip length with tipped blade.
		/// </summary>
		LongGripTip,
		/// <summary>
		/// Melee weapon having a long grip length with broad blade.
		/// </summary>
		LongGripBroad
	}


	/// <summary>
	/// Ranged <code>Weapon</code>, used for ranged attacks.
	/// </summary>
	class RangedWeapon : Weapon {
		#region Fields


		RangedWeaponType type;
		int minAOERadius;
		int maxAOERadius;


		#endregion

		#region Properties


		/// <summary>
		/// Gets or sets the <code>RangedWeapon</code>'s <code>RangedWeaponType</code>.
		/// </summary>
		public RangedWeaponType Type {
			get { return type; }
			set { type = value; }
		}

		/// <summary>
		/// Gets or sets the minimum AOE (area-of-effect) radius of the <code>RangedWeapon</code>.
		/// 
		/// If the <code>RangedWeapon</code> does not trigger AOE when projectile hits the target, set this value to 0.
		/// </summary>
		public int MinimumAOERadius {
			get { return minAOERadius; }
			set { minAOERadius = value; }
		}

		/// <summary>
		/// Gets or sets the maximum AOE (area-of-effect) radius of the <code>RangedWeapon</code>.
		/// 
		/// If the <code>RangedWeapon</code> does not trigger AOE when projectile hits the target, set this value to 0.
		/// </summary>
		public int MaximumAOERadius {
			get { return maxAOERadius; }
			set { maxAOERadius = value; }
		}


		#endregion

		#region Initializations


		/// <summary>
		/// Creates a new <code>RangedWeapon</code> with the specified damage. The damage of the <code>RangedWeapon</code> will be static.
		/// </summary>
		/// <param name="name">The <code>RangedWeapon</code>'s name.</param>
		/// <param name="damage">The <code>RangedWeapon</code>'s damage.</param>
		/// <param name="type">The <code>RangedWeapon</code>'s <code>RangedWeaponType</code>.</param>
		/// <param name="minAOERadius">Minimum AOE (area-of-effect) radius.
		/// Set this to 0 if the <code>RangedWeapon</code> does not employ AOE.
		/// </param>
		/// <param name="maxAOERadius">Maximum AOE (area-of-effect) radius.
		/// Set this to 0 if the <code>RangedWeapon</code> does not employ AOE.
		/// </param>
		public RangedWeapon(string name,
							int damage,
							RangedWeaponType type,
							int minAOERadius = 0,
							int maxAOERadius = 0)
			: this(name, damage, damage, type, minAOERadius, maxAOERadius) {
			//Name = name;
			//MinimumDamage = damage;
			//MaximumDamage = damage;
			//Type = type;
			//MinimumAOERadius = minAOERadius;
			//MaximumAOERadius = maxAOERadius;
		}

		/// <summary>
		/// Creates a new weapon given a range for damage hit points.
		/// </summary>
		/// <param name="name">The <code>RangedWeapon</code>'s name.</param>
		/// <param name="minDamage">The <code>RangedWeapon</code>'s minimum damage.</param>
		/// <param name="maxDamage">The <code>RangedWeapon</code>'s maximum damage.</param>
		/// <param name="type">The <code>RangedWeapon</code>'s <code>RangedWeaponType</code>.</param>
		/// <param name="minAOERadius">Minimum AOE (area-of-effect) radius.
		/// Set this to 0 if the <code>RangedWeapon</code> does not employ AOE.
		/// </param>
		/// <param name="maxAOERadius">Maximum AOE (area-of-effect) radius.
		/// Set this to 0 if the <code>RangedWeapon</code> does not employ AOE.
		/// </param>
		public RangedWeapon(string name,
							int minDamage,
							int maxDamage,
							RangedWeaponType type,
							int minAOERadius = 0,
							int maxAOERadius = 0)
			: base(name, minDamage, maxDamage) {
			//Name = name;
			//MinimumDamage = minDamage;
			//MaximumDamage = maxDamage;
			Type = type;
			MinimumAOERadius = minAOERadius;
			MaximumAOERadius = maxAOERadius;
		}


		#endregion
	}


	/// <summary>
	/// <code>RangedWeapon</code> types.
	/// </summary>
	enum RangedWeaponType {
		/// <summary>
		/// Handgun, or small firearm.
		/// </summary>
		Handgun,

		/// <summary>
		/// Sawed-off shotgun.
		/// </summary>
		ShotgunSawedOff,

		/// <summary>
		/// Pump shotgun.
		/// </summary>
		ShotgunPump,

		/// <summary>
		/// Semi-automatic shotgun.
		/// </summary>
		ShotgunSemi,

		/// <summary>
		/// Automatic shotgun.
		/// </summary>
		ShotgunAuto,

		/// <summary>
		/// Submachine gun.
		/// </summary>
		SubmachineGun,

		/// <summary>
		/// Assault rifle.
		/// </summary>
		AssaultRifle,

		/// <summary>
		/// Special ranged weapon.
		/// </summary>
		Special
	}
}
