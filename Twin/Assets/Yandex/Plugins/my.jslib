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

	GetPlayerRank: function(){
		ysdk.getLeaderboards()
		.then(lb => lb.getLeaderboardPlayerEntry('Scores'))
		.then(res => {
			console.log(res);
			myGameInstance.SendMessage('Progress', 'SetInfo', res.rank);
		})
		.catch(err => {
			if (err.code === 'LEADERBOARD_PLAYER_NOT_PRESENT') {
      // Срабатывает, если у игрока нет записи в лидерборде    		
			}
		});
	},

	ShowFullScreenAdv: function() {
		ysdk.adv.showFullscreenAdv({
			callbacks: {
				onClose: function(wasShown) {
          // some action after close
				},
				onError: function(error) {
          // some action on error
				}
			}
		})
	},

	AddTimeForAdv: function(value){
		ysdk.adv.showRewardedVideo({
			callbacks: {
				onOpen: () => {
					console.log('Video ad open.');
				},
				onRewarded: () => {
					console.log('Rewarded!');
					myGameInstance.SendMessage('Yandex','AddTime',value);
				},
				onClose: () => {
					console.log('Video ad closed.');
				}, 
				onError: (e) => {
					console.log('Error while open video ad:', e);
				}
			}
		})
	},
});