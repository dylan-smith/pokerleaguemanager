﻿using System;
using PokerLeagueManager.Commands.Domain.Aggregates;
using PokerLeagueManager.Commands.Domain.Infrastructure;
using PokerLeagueManager.Common;
using PokerLeagueManager.Common.Commands;
using PokerLeagueManager.Common.Queries;

namespace PokerLeagueManager.Commands.Domain.CommandHandlers
{
    public class EnterGameResultsHandler : BaseCommandHandler, IHandlesCommand<EnterGameResultsCommand>
    {
        public void Execute(EnterGameResultsCommand command)
        {
            if (Repository.DoesAggregateExist(command.GameId))
            {
                throw new ArgumentException("Cannot enter game results for a previously existing Game Id", "GameId");
            }

            var gameCount = new GetGameCountByDateQuery(command.GameDate).Execute(QueryService);
            if (gameCount > 0)
            {
                throw new ArgumentException("Cannot enter multiple game results for the same date", "GameDate");
            }

            var game = new Game(command.GameId, command.GameDate);

            if (command.Players != null)
            {
                foreach (var player in command.Players)
                {
                    game.AddPlayer(player.PlayerName, player.Placing, player.Winnings, player.PayIn);
                }
            }

            game.ValidateGame();

            Repository.PublishEvents(game, command);
        }
    }
}
