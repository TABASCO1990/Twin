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
				console.log('LoadEmpty');
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

	ShowWindowAuthorization: function(){
		if (player.getMode() === 'lite'){
			myGameInstance.SendMessage('Yandex', 'ShowScreen');
		}
		else{
			myGameInstance.SendMessage('Yandex', 'CloseScreen');
		}
	},

	InitAuthorization: function(){
		 ysdk.auth.openAuthDialog();
	},

	SetToLeaderboard: function(value){
		ysdk.getLeaderboards()
		.then(lb => {
			lb.setLeaderboardScore('ScoresPlayers', value);
		});
	},

	GetPlayerRank: function(){
		ysdk.getLeaderboards()
		.then(lb => lb.getLeaderboardPlayerEntry('ScoresPlayers'))
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
          			myGameInstance.SendMessage('Yandex','ContinuePlaySound');
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
					myGameInstance.SendMessage('Yandex','ContinuePlaySound');
				}, 
				onError: (e) => {
					console.log('Error while open video ad:', e);
				}
			}
		})
	},

	ExitGame: function(){
		ysdk.dispatchEvent(ysdk.EVENTS.EXIT);
	},
});