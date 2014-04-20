﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace PokerLeagueManager.UI.Wpf.TestFramework
{
    public class EnterGameResultsScreen : BaseScreen
    {
        public EnterGameResultsScreen(ApplicationUnderTest app)
            : base(app)
        {
        }

        public EnterGameResultsScreen EnterGameDate(string gameDate)
        {
            GameDatePicker.DateAsString = gameDate;
            return this;
        }

        public EnterGameResultsScreen EnterPlayerName(string playerName)
        {
            PlayerNameTextBox.Text = playerName;
            return this;
        }

        public EnterGameResultsScreen EnterPlacing(string playerPlacing)
        {
            PlacingTextBox.Text = playerPlacing;
            return this;
        }

        public EnterGameResultsScreen EnterWinnings(string playerWinnings)
        {
            WinningsTextBox.Text = playerWinnings;
            return this;
        }

        public EnterGameResultsScreen ClickAddPlayer()
        {
            Mouse.Click(AddPlayerButton);
            return this;
        }

        public ViewGamesListScreen ClickSaveGame()
        {
            Mouse.Click(SaveGameButton);
            return new ViewGamesListScreen(App);
        }

        private WpfDatePicker GameDatePicker
        {
            get
            {
                var ctl = new WpfDatePicker(App);
                ctl.SearchProperties.Add(WpfDatePicker.PropertyNames.AutomationId, "GameDatePicker");
                return ctl;
            }
        }

        private WpfEdit PlayerNameTextBox
        {
            get
            {
                var ctl = new WpfEdit(App);
                ctl.SearchProperties.Add(WpfEdit.PropertyNames.AutomationId, "PlayerNameTextBox");
                return ctl;
            }
        }

        private WpfEdit PlacingTextBox
        {
            get
            {
                var ctl = new WpfEdit(App);
                ctl.SearchProperties.Add(WpfEdit.PropertyNames.AutomationId, "PlacingTextBox");
                return ctl;
            }
        }

        private WpfEdit WinningsTextBox
        {
            get
            {
                var ctl = new WpfEdit(App);
                ctl.SearchProperties.Add(WpfEdit.PropertyNames.AutomationId, "WinningsTextBox");
                return ctl;
            }
        }

        private WpfButton AddPlayerButton
        {
            get
            {
                var ctl = new WpfButton(App);
                ctl.SearchProperties.Add(WpfButton.PropertyNames.AutomationId, "AddPlayerButton");
                return ctl;
            }
        }

        private WpfButton SaveGameButton
        {
            get
            {
                var ctl = new WpfButton(App);
                ctl.SearchProperties.Add(WpfButton.PropertyNames.AutomationId, "SaveGameButton");
                return ctl;
            }
        }
    }
}
