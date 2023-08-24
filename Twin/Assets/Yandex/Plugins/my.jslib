mergeInto(LibraryManager.library, {
   
  GiveMePlayerData: function () {
	myGameInstance.SendMessage("Yandex", "SetName", player.getName());
	myGameInstance.SendMessage("Yandex", "SetPhoto", player.getPhoto("medium"));
  },
  
  GetLang: function () {
	var lang = ysdk.environment.i18n.lang;
	var bufferSize = lengthBytesUTF8(lang) + 1;
	var buffer = _malloc(bufferSize);
	stringToUTF8(lang, buffer, bufferSize);
    return buffer;
  },
  
  SaveExtern: function(date){
	  var dateString = UTF8ToString(date);
	  var myobj = JSON.parse(dateString);
	  player.setData(myobj);
  },
  
  LoadExtern: function(){
	  player.getData().then(_date => {
		  const myJSON = JSON.stringify(_date);
		  myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
	  });
  },
});