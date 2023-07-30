using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using PokeApiNet;

namespace PokemonSurvivors.Controllers
{
	[Route("Pokemon")]
	public class PokemonNetworkModelController : Controller
	{
		private static readonly PokeApiClient PokeClient = new PokeApiClient();
		private readonly ILogger<PokemonNetworkModelController> _logger;
		public PokemonNetworkModelController(ILogger<PokemonNetworkModelController> logger)
		{
			_logger = logger;
		}

		[HttpGet("{name}")]
		public async Task<ActionResult<PokemonNetworkModel>> Get(string name)
		{
            Pokemon pokemon = await PokeClient.GetResourceAsync<Pokemon>(name);
            if(pokemon == null)
            {
                return NotFound();
            }

            PokemonNetworkModel pokemonModel = new PokemonNetworkModel();
            pokemonModel.Name = pokemon.Name;
            pokemonModel.FrontSpriteUrl = pokemon.Sprites.FrontDefault;
            pokemonModel.BackSpriteUrl = pokemon.Sprites.BackDefault;

            pokemonModel.Hp = pokemon.Stats[0].BaseStat;
            pokemonModel.Defense = pokemon.Stats[1].BaseStat;
            pokemonModel.Attack = pokemon.Stats[2].BaseStat;
            pokemonModel.SpecialAttack = pokemon.Stats[3].BaseStat;
            pokemonModel.SpecialDefense = pokemon.Stats[4].BaseStat;
            pokemonModel.Speed = pokemon.Stats[5].BaseStat;

            List<Move> allMoves = await PokeClient.GetResourceAsync(pokemon.Moves.Select(move => move.Move));
            pokemonModel.Moves = allMoves.ToList().ConvertAll<PokemonMoveNetworkModel>(move => new PokemonMoveNetworkModel(move.Name, move.Power, move.Accuracy));

            return pokemonModel;
		}
	}
}