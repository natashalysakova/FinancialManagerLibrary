function AddCategory(data) {
    console.log(data);

    var category = $(data);
    $("#categories").append(category);
}

function OnError(error) {
    console.log("ERROR: " + error);
}