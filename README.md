# Lykke.Service.Stellar.Sign
Blockchain.SignService implementation for the [Stellar](https://www.stellar.org/) ledger based on the [Lykke Blockchains integration](https://docs.google.com/document/d/1KVd-2tg-Ze5-b3kFYh1GUdGn9jvoo7HFO3wH_knpd3U/edit) guide. To integrate with the Stellar network the [csharp-stellar-framework](https://github.com/schindlo/csharp-stellar-framework) is used. The framework component `csharp-stellar-base` is referenced as nuget package.

Find the `Lykke.Service.Stellar.Api` module [here](https://github.com/schindlo/Lykke.Service.Stellar.Api).

# Configuration
Available configuration variables are documented below. See [developing](https://github.com/LykkeCity/lykke.dotnettemplates/tree/master/Lykke.Service.LykkeService#developing) for more information on how to work with app and launch settings.
```
{
  "StellarSignService": {
    "Db": {
      // Connection string to the Azure storage account where the StellarSignLog table with logs is stored
      "LogsConnString": ""
    },
    // The network passphrase used when signing transactions. The following passphrases are currently in use:
    // Test: "Test SDF Network ; September 2015"
    // Live: "Public Global Stellar Network ; September 2015"
    "NetworkPassphrase": ""
  },
  "SlackNotifications": {
    "AzureQueue": {
      // Connection string to the Azure storage account where slack notifications are queued
      "ConnectionString": "",
      // The name of the queue for the slack notifications
      "QueueName": ""
    }
  }
}
```
