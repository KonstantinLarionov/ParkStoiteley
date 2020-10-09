$(document).ready(function(){
    var date = new Date();
    console.log(date.getFullYear() + '-' + date.getMonth() + '-' + date.getDay());
    $('#date').attr('value', date.getFullYear() + '-' + (date.getMonth() + '').padStart(2, "0") + '-' + (date.getDay() + '').padStart(2, "0"));
}); 

$('#addtextblock').click(function(){
    var textblock = $('<div class="border mb-2"><p class="p-2 m-1 mb-0" contenteditable="true">Новый блок текста - добавьте ваш текст сюда</p><div class="w-100" style="display: flex; justify-content: flex-end;"><button onclick="deleteblock(this);" class="btn btn-danger m-1 mr-0">Удалить блок</button></div></div>');
    $('#newcontainer').append(textblock);
});
$('#addimageblock').click(function(){
    var imageblock = $('<div class="border mb-2"><div class="m-2 row justify-content-around"><div><img class="img-fluid" src="../assets/img/mid.jpg"><p contenteditable="true" class="p-1 mt-2 text-center">Подпись к рисунку</p></div></div><div class="w-100" style="display: flex; justify-content: flex-end;"><button onclick="deleteblock(this);" class="btn btn-danger m-1 mr-0">Удалить блок</button></div></div>');
    $('#newcontainer').append(imageblock);
});
function deleteblock(e) {
    var block = $(e).parent().parent();
    block.remove();
};