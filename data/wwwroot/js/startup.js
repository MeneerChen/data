
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


function setAutoGenerate() {
    var switchValue = $("#sensorDataCheckbox").is(":checked");
    var from = +$("#sensorDataRandomFrom").val();
    var to = +$("#sensorDataRandomTo").val();
    $.ajax("/Home/SetAutoGenerate", 
        { 
            type: "POST", 
            data: JSON.stringify({ SwitchValue: switchValue, FromRandom: from, ToRandom: to }), 
            contentType : "application/json",
            dataType: "json"
        });
}