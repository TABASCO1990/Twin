mergeInto(LibraryManager.library, {
   
  GiveMePlayerData: function () {
	myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
	myGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("medium"));
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

  SetToLeaderboard: function(value){
  	ysdk.getLeaderboards()
  		.then(lb => {
    	lb.setLeaderboardScore('Scores', value);
  	});
  },

  GiveLeaderRank: function(){
		ysdk.getLeaderboards()
  		.then(lb => lb.getLeaderboardPlayerEntry('leaderboard2021'))
  		.then(res => console.log(res.rank))
  		.catch(err => {
    	if (err.code === 'LEADERBOARD_PLAYER_NOT_PRESENT') {
      // Срабатывает, если у игрока нет записи в лидерборде
    }
  });
  },

  
});