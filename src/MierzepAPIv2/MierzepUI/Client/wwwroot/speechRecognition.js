let speechRecognition = new webkitSpeechRecognition();
let final_transcript = "";
let interim_transcript = "";

export function initStart() {

    speechRecognition.continuous = true;
    speechRecognition.interimResults = true;
    speechRecognition.lang = document.querySelector("#select_dialect").value;

    speechRecognition.onstart = () => {
        document.querySelector("#status").style.display = "block";
    };
    speechRecognition.onerror = () => {
        document.querySelector("#status").style.display = "none";
        console.log("Speech Recognition Error");
    };
    speechRecognition.onend = () => {
        document.querySelector("#status").style.display = "none";
        console.log("Speech Recognition Ended");
    };

    speechRecognition.onresult = (event) => {
        for (let i = event.resultIndex; i < event.results.length; ++i) {
            if (event.results[i].isFinal) {
                final_transcript += event.results[i][0].transcript;
                interim_transcript = "";
            } else {
                interim_transcript = "*";
            }
        }
        document.querySelector("#final").innerHTML = final_transcript;
        document.querySelector("#interim").innerHTML = interim_transcript;
    };
}

export function startSpeech() {
    speechRecognition.start();
}

export function stopSpeech() {
    speechRecognition.stop();
}

export function returnTranscript() {
    return final_transcript;
}

export function returnInterimTranscript() {
    return interim_transcript;
}

export function restartTranscript() {
    final_transcript = "";
    interim_transcript = "";
}


    //document.querySelector("#start").onclick = () => {
    //    speechRecognition.start();
    //};
    //document.querySelector("#stop").onclick = () => {
    //    speechRecognition.stop();
    //};
