//Funcion para prevenir devolverse a la pagina anterior
function preventBack() { window.history.forward(); }
setTimeout("preventBack()", 0);
window.onunload = function () { null };

