// <copyright file="ValorantPUUIDGrabber.cs" company="MillerMatt">
// Copyright (c) MillerMatt. All rights reserved.
// </copyright>

namespace ValorantPUUIDGrabber
{
    using System.Diagnostics;
    using System.Text.Json;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Main Valorant PUUID Grabber Class.
    /// </summary>
    public class ValorantPUUIDGrabber
    {
        private readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Gets or Sets the APIKey for RiotAPI.
        /// </summary>
        public string? APIKey { get; set; }

        /// <summary>
        /// Gets or Sets the account to grab data from.
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// Sets the APIKey and APISecret.
        /// </summary>
        public void InitializeAPIStrings()
        {
            // Initialize API Key
            var builder = new ConfigurationBuilder();

            builder.AddUserSecrets<ValorantPUUIDGrabber>();
            IConfigurationRoot configuration = builder.Build();
            var selectedSecrets = configuration.GetSection("MySecrets");

            this.APIKey = selectedSecrets["APIKey"];
        }

        /// <summary>
        /// Handles connecting to the API.
        /// </summary>
        /// <param name="gameName">gameName of the account. </param>
        /// <param name="tagLine">tagLine of the account. </param>
        public void InitializeAPIConnection(string gameName, string tagLine)
        {
            // Initialize HttpClient

            // Initialize Account API url based on gameName and tagLine
            Uri api_url = new Uri($"https://americas.api.riotgames.com/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}?api_key={this.APIKey}");

            // Parse response body into AccountDto Object
            var request = new HttpRequestMessage
            {
                RequestUri = api_url,
                Method = HttpMethod.Get,
            };
            var response = this.client.SendAsync(request).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;
            this.Account = JsonSerializer.Deserialize<AccountDto>(responseBody);

            // Print out PUUID
            if (this.Account != null)
            {
                Console.WriteLine($"PUUID for the user {this.Account.GameName}#{this.Account.TagLine} is: \n{this.Account.PUUID}");
            }
        }
    }
}
