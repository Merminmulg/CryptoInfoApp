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
![image](https://github.com/user-attachments/assets/dad6e5a0-747e-4431-9742-2feeda5beb21)
### Light Theme
![image](https://github.com/user-attachments/assets/2894c85e-66b0-4464-9be1-13e4a3b4aa39)
### Currency Info Page
![image](https://github.com/user-attachments/assets/e8a6843b-c2a6-4258-bea7-466d2578edab)
### Conversion Page
![image](https://github.com/user-attachments/assets/7bac551c-977a-4823-8b56-09a3747284c5)




