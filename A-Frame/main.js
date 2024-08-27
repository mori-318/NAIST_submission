"use strict";

AFRAME.registerComponent('audio_listner', {   
    init: function () {
        const sound01 = document.getElementById("park_sound");
        this.el.addEventListener('click', function (evt) {
            const sound = sound01.components.sound;
            console.log("audio_ok")
            if(sound.isPlaying){// 音源が再生されているかどうかを判定
                sound.pauseSound();// 音源を停止
            }else{
                sound.playSound();// 音源を再生
            }
        });
    }
});

AFRAME.registerComponent('cat_listner', {   
    init: function () {
        const cat_video = document.getElementById("cat_video");
        this.el.addEventListener('click', function (evt) {
            console.log("cat_ok")
            if(cat_video.paused){// 動画が停止しているかどうかを判定
                cat_video.play();// 動画を再生
            }else{
                cat_video.pause();// 動画を停止
            }
        });
    }
});

AFRAME.registerComponent('dog_listner', {
    init: function () {
        const dog_video = document.getElementById("dog_video");
        this.el.addEventListener('click', function (evt) {
            console.log("dog_ok")
            if(dog_video.paused){// 動画が停止しているかどうかを判定
                dog_video.play();// 動画を再生
            }else{
                dog_video.pause();// 動画を停止
            }
        });
    }
});

AFRAME.registerComponent('bird_listner', {
    init: function () {
        const bird_video = document.getElementById("bird_video");
        this.el.addEventListener('click', function (evt) {
            console.log("bird_ok")
            if(bird_video.paused){// 動画が停止しているかどうかを判定
                bird_video.play();// 動画を再生
            }else{
                bird_video.pause();// 動画を停止
            }
        });
    }
});
