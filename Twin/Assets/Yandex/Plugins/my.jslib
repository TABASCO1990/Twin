mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
	console.log("Hello, world!");
  },
   
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
});