﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using log4net;
using Microsoft.Practices.Unity;
using PokerLeagueManager.Common.Commands.Infrastructure;
using PokerLeagueManager.Common.DTO;
using PokerLeagueManager.UI.Wpf.Infrastructure;
using PokerLeagueManager.UI.Wpf.Views;

namespace PokerLeagueManager.UI.Wpf.ViewModels
{
    public class PlayerStatisticsViewModel : BaseViewModel, INotifyPropertyChanged, IPlayerStatisticsViewModel
    {
        private ObservableCollection<GetPlayerStatisticsDto> _players;

        public PlayerStatisticsViewModel(ICommandService commandService, IQueryService queryService, IMainWindow mainWindow, ILog logger)
            : base(commandService, queryService, mainWindow, logger)
        {
            _players = new ObservableCollection<GetPlayerStatisticsDto>(_QueryService.GetPlayerStatistics());

            GamesCommand = new RelayCommand(x => NavigateToGamesView());

            Height = 400;
            Width = 385;
            WindowTitle = "Player Statistics";
        }

        public IEnumerable<string> Players
        {
            get
            {
                return _players.OrderByDescending(p => p.Winnings)
                             .Select(p => string.Format(
                                 "{0} - Games Played: {1} - Winnings: ${2} - Pay In: ${3} - Profit: {4} - Profit Per Game: {5}",
                                 p.PlayerName,
                                 p.GamesPlayed,
                                 p.Winnings,
                                 p.PayIn,
                                 p.Profit,
                                 p.ProfitPerGame.ToString()));
            }
        }

        public System.Windows.Input.ICommand GamesCommand { get; set; }

        private void NavigateToGamesView()
        {
            var view = Resolver.Container.Resolve<IViewGamesListView>();
            _MainWindow.ShowView(view);
        }
    }
}