"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Boton enviar desactivado hasta no realizarse la conexion correctamente
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);    
    li.textContent = `${user} dice :`;
    var ul = document.createElement("ul");
    document.getElementById("messagesList").appendChild(ul);
    ul.textContent = `${message}`;
    
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});