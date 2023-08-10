using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
	public class PokemonMoveNetworkModel
	{
        public PokemonMoveNetworkModel() {}
        public PokemonMoveNetworkModel(string name, string? type , string? damageClass, int? damage, int? accuracy)
        {
            Name = name;
			Type = type;
			DamageClass = damageClass;
            Damage = damage;
            Accuracy = accuracy;
        }
		public string? Name { get; set; }
		public string? Type { get; set; }
		public string? DamageClass { get; set; }
		public int? Damage { get; set; }
		public int? Accuracy { get; set; }
	}

	public class PokemonNetworkModel
	{
		public string? Name { get; set; }
		public List<string>? Types { get; set; } = new List<string>();
		public string? FrontSpriteUrl { get; set; }
		public string? BackSpriteUrl { get; set; }
		public int Hp { get; set; }
		public int Attack { get; set; }
		public int Defense { get; set; }
		public int SpecialAttack { get; set; }
		public int SpecialDefense { get; set; }
		public int Speed { get; set; }
        public List<PokemonMoveNetworkModel>? Moves {get;set;}
	}
}