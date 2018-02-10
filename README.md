# Lykke.Service.Stellar.Sign

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
