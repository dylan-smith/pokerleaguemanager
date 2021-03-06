﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EFSpike.Domain;

namespace PokerLeagueManager.Common.DTO
{
    [DataContract]
    public class GetGameResultsDto : BaseDataTransferObject
    {
        public GetGameResultsDto()
        {
            Players = new List<PlayerDto>();
        }

        [DataMember]
        public Guid GameId { get; set; }

        [DataMember]
        public DateTime GameDate { get; set; }

        [DataMember]
        public virtual ICollection<PlayerDto> Players { get; private set; }

        [DataMember]
        public virtual ICollection<BuyinDto> Buyins { get; private set; }

        public virtual ICollection<int> foo { get; private set; }
    }
}
