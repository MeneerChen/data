
$(document).ready(function() {
    loadSensorData();
});

function loadSensorData(guid) {
    console.log("loadSensorData");
    $.get("Home/GetRivision",
        function(rivision) {
            if (guid !== rivision)
                $("#sensorData").load("Home/GetSensorData");

            window.setTimeout(loadSensorData, 1000, rivision);
        });
}

function generateOutofbed() {
    $.post("Data/Outofbed",
        function(data) {
            $("#sensorData").html(data);
        });
}
function generateLeftside() {
    $.post("Data/Leftside",
        function(data) {
            $("#sensorData").html(data);
        });
}
function generateRightside() {
    $.post("Data/Rightside",
        function(data) {
            $("#sensorData").html(data);
        });
}
function generateBack() {
    $.post("Data/Back",
        function(data) {
            $("#sensorData").html(data);
        });
}
function generateBelly() {
    $.post("Data/Belly",
        function(data) {
            $("#sensorData").html(data);
        });
}


function setAutoGenerate() {
    var switchValue = $("#sensorDataCheckbox").is(":checked");
    var from = +$("#sensorDataRandomFrom").val();
    var to = +$("#sensorDataRandomTo").val();
    $.ajax("/Home/SetAutoGenerate",
        {
            type: "POST",
            data: JSON.stringify({ SwitchValue: switchValue, FromRandom: from, ToRandom: to }),
            contentType: "application/json",
            dataType: "json"
        });
}