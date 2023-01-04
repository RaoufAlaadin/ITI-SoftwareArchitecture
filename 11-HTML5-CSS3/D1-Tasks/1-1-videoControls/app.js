

/* notes and guides

https://developer.mozilla.org/en-US/docs/Learn/JavaScript/Client-side_web_APIs/Video_and_audio_APIs */


var mainVideo = document.getElementById("frozen");
var durationSlider = document.getElementById("durationSlider")

mainVideo.addEventListener("timeupdate", sliderAnimation);
durationSlider.addEventListener("click", sliderClicked);


document.getElementById("play").addEventListener("click", playVideo);
document.getElementById("pause").addEventListener("click", pauseVideo);

document.getElementById("backAll").addEventListener("click", backAll);
document.getElementById("backFiveSeconds").addEventListener("click", backFiveSeconds);
document.getElementById("forwardFiveSeconds").addEventListener("click", forwardFiveSeconds);
document.getElementById("forwardAll").addEventListener("click", forwardAll);

document.getElementById("volumeSlider").addEventListener("click", volumeSlider);
document.getElementById("mute").addEventListener("click", muteVolume);

document.getElementById("speedControl").addEventListener("click", speedControl);




function sliderAnimation() {
    // console.log("imeeeee");

    moveSliderBasedOnTime();
    
    var current = getTimeInMinutesAndSeconds(mainVideo.currentTime);
    var full = getTimeInMinutesAndSeconds(mainVideo.duration);
    document.getElementById("currentDuration").innerText = `${current[0]}:${current[1]}/ ${full[0]}:${full[1]}`;

}

function moveSliderBasedOnTime()
{   
    //intilize the input range
    durationSlider.max = mainVideo.duration;
    durationSlider.min = 0;
    //updating the current value.
    durationSlider.value = mainVideo.currentTime;

}
function getTimeInMinutesAndSeconds(timeInSeconds) {

    //1- we change the time from seconds to mins by diving by 60
    var minutes = Math.floor(timeInSeconds / 60);
    //2- we get the leftover seconds by subtracting full seconds value - the one where we removed leftovers. 
    var seconds = Math.floor(timeInSeconds - minutes * 60);
    /*  3- to add zeros to the timer until we reach 2 digits, we need our number as a string.
      then we use padStart()
             https://www.geeksforgeeks.org/javascript-padstart-method/
      */
    var minutesValue = minutes.toString().padStart(2, 0);
    var secondsValue = seconds.toString().padStart(2, 0);

    return [minutesValue, secondsValue];

}

function sliderClicked() {
    // this line is important to change the current time if I press the slider
    mainVideo.currentTime = durationSlider.value;
}

function playVideo() {mainVideo.play();}

function pauseVideo() {mainVideo.pause();}

function backAll() {    mainVideo.currentTime = 0;}

function backFiveSeconds() { mainVideo.currentTime -= 5;}

function forwardFiveSeconds() { mainVideo.currentTime += 5;}

function forwardAll() {mainVideo.currentTime = mainVideo.duration;}

// it was really important to add steps in the range volume tag !!!
function volumeSlider() { mainVideo.volume = this.value}

function muteVolume() { mainVideo.muted ? mainVideo.muted = false : mainVideo.muted = true }

function speedControl() { mainVideo.playbackRate = this.value}
