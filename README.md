# NOTA BENE

`App.xaml` e il suo code behind non li devi toccare. <br>
<br> 
Nella nostra `MainWindow` andiamo a definire il frame che conterra' tutte le altre pagine della navigazione, nel suo code behind andiamo a prendere l'id del frame e andiamo a usare il metodo che naviga direttamente nella nuova pagina
```c#
rootFrame.Navigate(typeof(MainPage));
```

<br>

Nella altre pagine se vogliamo navigare, al posto di utilizzare `rootFrame` che era l'id del frame nella pagina xaml, utilizziamo `Frame` e poi navigate
