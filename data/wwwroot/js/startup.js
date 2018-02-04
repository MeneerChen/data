
$(document).ready(function() {
    loadSensorData();
});

function loadSensorData() {
    console.log("running loadSensorData");
    if ($("#sensorDataCheckbox").is(":checked")) {
        $("#sensorData").load("Home/Random");
    }
    var from = +$("#sensorDataRandomFrom").val();
    var to = +$("#sensorDataRandomTo").val();
    var random = randomIntFromInterval(from, to);
    window.setTimeout(loadSensorData, random * 1000);
}

function randomIntFromInterval(min, max) {
    return Math.floor(Math.random() * (max - min + 1) + min);
}