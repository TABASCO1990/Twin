mergeInto(LibraryManager.library, {

	GetLang: function () {
		var lang = ysdk.environment.i18n.lang;
		var bufferSize = lengthBytesUTF8(lang) + 1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(lang, buffer, bufferSize);
		return buffer;
	},
	
	SaveExtern: function (data) {
		try {

			var dataString = UTF8ToString(data);
			var myobj = JSON.parse(dataString);
			player.setData(myobj);

		} catch (e) {

			console.log('non save');
		}
	},
	
	LoadExtern: function(){
		try {
			if (!PlayerExist) {
				myGameInstance.SendMessage('Progress','LoadEmpty'); 
			} else {
				console.log('LoadExternBeforeGetData');
				player.getData().then(_date => {
					const myJSON = JSON.stringify(_date);
					myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
				});
			}

		} catch (e) {			
			console.log('non load');
		}
	},

	OpenAuthDialog: function(){
		if (player.getMode() === 'lite'){
			ysdk.auth.openAuthDialog();
		}
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
					myGameInstance.SendMessage('Yandex','PauseGame');
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

	ExitGame: function{
		ysdk.dispatchEvent(ysdk.EVENTS.EXIT);
	},
});