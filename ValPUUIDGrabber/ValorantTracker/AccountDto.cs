// <copyright file="AccountDto.cs" company="MillerMatt">
// Copyright (c) MillerMatt. All rights reserved.
// </copyright>

namespace ValorantPUUIDGrabber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Account data of the player.
    /// </summary>
    public class AccountDto
    {
        /// <summary>
        /// Gets or Sets the PUUID of the player account.
        /// </summary>
        [JsonPropertyName("puuid")]
        public string? PUUID { get; set; }

        /// <summary>
        /// Gets or Sets the gameName of the player account.
        /// </summary>
        [JsonPropertyName("gameName")]
        public string? GameName { get; set; }

        /// <summary>
        /// Gets or Sets the tagLine of the player account.
        /// </summary>
        [JsonPropertyName("tagLine")]
        public string? TagLine { get; set; }
    }
}
