﻿using PokerLeagueManager.Commands.Domain.QueryServiceReference;
using PokerLeagueManager.Common.Commands.Infrastructure;

namespace PokerLeagueManager.Commands.Domain.Infrastructure
{
    public interface IHandlesCommand<T> where T: ICommand
    {
        IEventRepository Repository { get; set; }
        IQueryService QueryService { get; set; }
        void Execute(T command);
    }
}
