function AddCategory(data) {
    console.log(data);
    var category = $(data);
    $("#categories").append(category);
}

function AddIncome(data) {
    console.log(data);
    var category = $(data);
    $("#incomes").append(category);
}

function AddTransaction(data) {
    console.log(data);
    var category = $(data);
    $("#transactions").append(category);
}

function AddWallet(data) {
    console.log(data);
    var category = $(data);
    $("#wallets").append(category);
}

function OnError(error) {
    console.log("ERROR: " + error);
}