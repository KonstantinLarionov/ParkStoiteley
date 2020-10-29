$(document).ready(function(){ // выставляем текущую дату в инпут-дата
    var date = new Date();
    $('#date').attr('value', date.getFullYear() + '-' + ((date.getMonth() + 1) + '').padStart(2, "0") + '-' + (date.getDate() + '').padStart(2, "0"));
}); 

$('#addtextblock').click(function(){// создаем блок для добавления текста
    var textblock = $('<div class="border mb-2"><div class="w-100" style="display: flex; justify-content: flex-end;"><button title="Удалить этот блок" onclick="deleteblock(this);" class="btn btn-danger m-1 mr-0">✕</button></div><p class="p-2 m-1 mb-0" contenteditable="true">Новый блок текста - добавьте ваш текст сюда</p></div>');
    $('#newcontainer').append(textblock);
});
$('#addimageblock').click(function(){ // создаем блок для добавления изображений
    var imageblock = $('<div class="border mb-2"><div class="w-100" style="display: flex; justify-content: flex-end;"><button title="Удалить этот блок" onclick="deleteblock(this);" class="btn btn-danger m-1 mr-0">✕</button></div><div class="m-2 row justify-content-around"><div><div title="Нажмите чтобы добавить\изменить изображение" onclick="addimage(this)" style="display: flex; justify-content: center; cursor: pointer;"><input type="file" style="display: none;"><img class="img-fluid" src="adding.png"></div><p contenteditable="true" class="p-1 mt-2 text-center">Добавьте подпись к рисунку</p></div></div></div>');
    imageblock.find('input[type=file]').bind('change', function(){ // находим в элементе инпут-файл
        var img = $(this).next();                                  // добавляем на него обработчик на выюор файла
    var reader = new FileReader();
    reader.onload = function (e) {
        img.attr('src', e.target.result);                           // создаем превьюшку изображения
    };
    reader.readAsDataURL(this.files[0]);
    });
    $('#newcontainer').append(imageblock); // добавляем его на страницу
});
$('#addvideoblock').click(function(){ // создаем блок для добавления кода видео
    var textblock = $('<div class="border mb-2"><div class="w-100" style="display: flex; justify-content: flex-end;"><button title="Удалить этот блок" onclick="deleteblock(this);" class="btn btn-danger m-1 mr-0">✕</button></div><div class="w-100" style="display: flex;"><textarea class="m-2 w-100 p-2" rows="5" style="resize: vertical;" placeholder="Это поле для вставки кода видео"></textarea></div></div>');
    $('#newcontainer').append(textblock);
});
function deleteblock(e) { // удаление блока
    var block = $(e).parent().parent(); // находим родителя от кликнутой кнопки
    block.remove(); // удаляем
};
function addimage(elem){
    $(elem).children()[0].click(); // делаем клик по инпут-файлу
}