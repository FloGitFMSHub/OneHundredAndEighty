﻿#region Usings

using System.Collections.Generic;
using OneHundredAndEightyCore.Common;
using OneHundredAndEightyCore.Domain;
using OneHundredAndEightyCore.Windows.Score;

#endregion

namespace OneHundredAndEightyCore.Game.Processors
{
    public class FreeThrowsDoubleWriteOffPointsProcessor : ProcessorBase
    {
        private readonly int writeOffPoints;

        public FreeThrowsDoubleWriteOffPointsProcessor(Domain.Game game,
                                                       List<Player> players,
                                                       DBService dbService,
                                                       ScoreBoardService scoreBoard,
                                                       int writeOffPoints)
            : base(game, players, dbService, scoreBoard)
        {
            this.writeOffPoints = writeOffPoints;
            players.ForEach(p => p.LegPoints = writeOffPoints);
        }

        public override void OnThrow(DetectedThrow thrw)
        {
            if (IsLegOver(thrw))
            {
                ConvertAndSaveThrow(thrw, ThrowResult.LegWon);

                dbService.StatisticUpdateAddLegsPlayedForPlayers(Game.Id);
                dbService.StatisticUpdateAddLegsWonForPlayer(PlayerOnThrow, Game.Id);

                foreach (var player in Players)
                {
                    player.LegPoints = writeOffPoints;
                    scoreBoard.SetPointsTo(player, writeOffPoints);
                    scoreBoard.CheckPointsHintFor(player);
                }

                ClearPlayerOnThrowHand();

                TogglePlayerOnThrow();
                return;
            }

            if (IsFault(thrw))
            {
                ConvertAndSaveThrow(thrw, ThrowResult.Fault);

                OnFault();
                return;
            }

            PlayerOnThrow.HandPoints += thrw.TotalPoints;
            PlayerOnThrow.LegPoints -= thrw.TotalPoints;
            scoreBoard.AddPointsTo(PlayerOnThrow, thrw.TotalPoints * -1);

            var dbThrow = ConvertAndSaveThrow(thrw, ThrowResult.Ordinary);

            PlayerOnThrow.HandThrows.Push(dbThrow);

            if (IsHandOver())
            {
                Check180();
                ClearPlayerOnThrowHand();
                scoreBoard.CheckPointsHintFor(PlayerOnThrow);
                TogglePlayerOnThrow();
            }
            else
            {
                PlayerOnThrow.ThrowNumber += 1;
                scoreBoard.SetThrowNumber(PlayerOnThrow.ThrowNumber);
                scoreBoard.CheckPointsHintFor(PlayerOnThrow);
            }
        }
    }
}