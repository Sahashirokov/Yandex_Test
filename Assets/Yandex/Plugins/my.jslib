
mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
      console.log("Hello, world!");
  },
GiveMePlayerData: function () {

   myGameInstance.SendMessage('Yandex', 'SetName',player.getName());
   myGameInstance.SendMessage('Yandex', 'SetPhoto',player.getPhoto("medium"));

      console.log();
      console.log();
  },


Rategame: function () {


    var pleobg = player.getMode();
    var sentq=false;
            if(pleobg === 'lite'){
                butauth();
                myGameInstance.SendMessage('Yandex', 'proverkaRate', pleobg);
            }else{

                ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        sentq=true;
                        myGameInstance.SendMessage('Yandex', 'conncetRate', sentq);
                        console.log(feedbackSent);


                    })
            } else {
                console.log(reason)
            }
        })


          }





  },

SaveExtern: function(date) {
        var dateString = UTF8ToString(date);
        var myobj = JSON.parse(dateString);
        player.setData(myobj);
      },

      LoadExtern: function(){
        player.getData().then(_date => {
            const myJSON = JSON.stringify(_date);
            myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
            console.log(myJSON);
        });
  },
SetToLeaderboard: function(value){

    ysdk.getLeaderboards()
  .then(lb => {

    lb.setLeaderboardScore('Height', value);

  });
},

GetLang : function(){
    var lang =  ysdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(lang)+1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang,buffer,bufferSize);
    return buffer;
},

ShowAdv : function()
    {

ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
            console.log("------------------------closed---------------")
          // some action after close
        },
        onError: function(error) {
          // some action on error
        }
    }
})

},

    AutchPlayer: function(){

//ysdk.auth.openAuthDialog();


            var pleobg = player.getMode();
            if(pleobg === 'lite'){
                butauth();
                myGameInstance.SendMessage('YandexAuth', 'SetButton', pleobg);
            }else{
                  myGameInstance.SendMessage('YandexAuth', 'SetButton', pleobg);
            }




            //myGameInstance.SendMessage('YandexAuth', 'SetButton', pleobg);



    },



   AddCoinExtern : function(value){
       ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
        },
        onRewarded: () => {
          console.log('Rewarded!');
            myGameInstance.SendMessage("CoinManager","AddCoins",value);
        },
        onClose: () => {
          console.log('Video ad closed.');
        },
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
    }
})
   }
});


