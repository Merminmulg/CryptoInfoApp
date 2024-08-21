# App For Browsing Cryptocurrencies
This is a test app that helps you browse cryptocurrencies. It also provides information about each currency and assists in finding potentially useful pairs on exchanges.
<br/>
Additionally, I have implemented a cryptocurrency converter that automatically finds exchanges for your conversion pair.

## Realized functionality
1. **Home Page** - Displays a list of cryptocurrencies sorted by their market cap. On this page, you can also change the language and theme (dark or light), and these settings will apply across all pages. <br/>
  * By clicking on the "i" button, you can access the Info Page for the selected currency.
  * The "Update" button refreshes the information in the list.
  * The "Conversion" button navigates you to the Conversion Page.
  * You can use the search field between the converter and language settings to search for cryptocurrencies by name or ID.
2. **Criptocurrency Info Page** - This page provides more detailed information about the selected cryptocurrency and lists all exchanges where you can trade or buy it.
  * Displaying chart of currency price changes for 7 days.
  * You can press the "Buy" button to open the exchange and the trading pair in your browser.
  * The "Back" button returns you to the Home Page.
3. **Convertation Page** - Allows you to convert one cryptocurrency to another and also searches for all pairs involving the selected currencies for easier trading.
  * To convert currencies, press the upper left field to select the base currency you want to convert. Below, enter the amount you wish to convert. Then, select the target currency in the upper right field and press the "Convert" button. The converted amount will be displayed below the target currency.
  * You can press the "Buy" button to open the exchange and the trading pair in your browser.
  * The "Back" button returns you to the Home Page.
## Frameworks Used
* WPF (C#)
* Community MVVM Toolkit
* Newtonsoft JSON Serializer
* LiveCharts2
## APIs Used
* CoinGecko API

## Visual Demonstration
### Dark Theme
![image](https://github.com/user-attachments/assets/73a84fbb-1617-4402-a37d-3cd1453cad16)
### Light Theme
![image](https://github.com/user-attachments/assets/864fffba-7d90-4034-aa98-1de0b204d55b)
### Currency Info Page
![image](https://github.com/user-attachments/assets/caab6c7c-aee7-4955-9231-bab9cf6296ad)
### Conversion Page
![image](https://github.com/user-attachments/assets/df4ab24d-b83f-417e-8cf5-fc17f35c5148)
