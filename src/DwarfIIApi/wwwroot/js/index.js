dowork();
const baseUrl = "wss://localhost:7122/ws"; //    ws://192.168.88.1:/ 9900

async function dowork() {
    document.getElementById("btnOn").addEventListener("click", async function () {
        let cameraId = getCameraId();
        TurnCameraOn(cameraId);
    });

    document.getElementById("btnOff").addEventListener("click", async function () {
        let cameraId = getCameraId();
        TurnCameraOff(cameraId);
    });

    document.getElementById("btnSingleShot").addEventListener("click", async function () {
        let cameraId = getCameraId();
        TakePhoto(cameraId, 0, 1)
    });

    document.getElementById("btnMultiShot").addEventListener("click", async function () {
        let cameraId = getCameraId();
        let count = document.getElementById("txtMultiShot").valueAsNumber;
        TakePhoto(cameraId, 1, count)
    });
}

function getCameraId() {
    let camera = document.querySelector('input[name="aspect"]:checked').value;
    return parseInt(camera);
}

async function TurnCameraOn(camera) {
    let socket = new WebSocket(baseUrl); 
    socket.onmessage = function (event) {
        console.log(event.data);
        socket.close();
    };
    socket.onclose = function (e) {
        console.log("connection closed");
    };
    socket.onopen = function (event) {
        let msg = new D2Message();
        msg.interface = 10000;
        msg.camId = camera;
        let json = JSON.stringify(msg);
        socket.send(json);
    };
}

async function TurnCameraOff(camera) {
    let socket = new WebSocket(baseUrl);
    socket.onmessage = function (event) {
        console.log(event.data);
        socket.close();
    };
    socket.onclose = function (e) {
        console.log("connection closed");
    };
    socket.onopen = function (event) {
        let msg = new D2Message();
        msg.interface = 10017;
        msg.camId = camera;
        let json = JSON.stringify(msg);
        socket.send(json);
    };
}

async function TakePhoto(camera, mode, count) {
    let socket = new WebSocket(baseUrl);
    socket.onmessage = function (event) {
        console.log(event.data);
        socket.close();
    };
    socket.onclose = function (e) {
        console.log("connection closed");
    };
    socket.onopen = function (event) {
        let msg = new D2Message();
        msg.interface = 10006;
        msg.camId = camera;
        msg.mode = mode;
        msg.count = count;
        let json = JSON.stringify(msg);
        socket.send(json);
    };
}

async function SetExposureMode(camera) {
    let socket = new WebSocket(baseUrl);
    socket.onmessage = function (event) {
        console.log(event.data);
        socket.close();
    };
    socket.onclose = function (e) {
        console.log("connection closed");
    };
    socket.onopen = function (event) {
        socket.send('{"interface":10001,"camId":0,"mode":0}');
    };
}

async function SetExposureValue() {
    let socket = new WebSocket(baseUrl);
    socket.onmessage = function (event) {
        console.log(event.data);
        socket.close();
    };
    socket.onclose = function (e) {
        console.log("connection closed");
    };
    socket.onopen = function (event) {
        socket.send('{"interface":10002,"camId":0,"value":0}');
    };
}
/*
file:///C:/Users/spuri/source/repos/DwarfIIApi/DWARF_II_API_V1.0-704a098a-9c08-4add-9c12-120a92f3eec5.pdf

10000 - Turn on the camera
{
    "interface":10000,
    "camId":0                - 0:Long focal camera 1:Wide-ang camera
}
return
{
    "interface":10000,
    "camId":0,               - 0:Long focal camera 1:Wide-ang camera
    "code":0                 - Error code
}
*/
/*
10017 - Turn off the camera
{
    "interface":10017,
    "camId":0                - 0:Long focal camera 1:Wide-ang camera
}
return
{
    "interface":10017,
    "camId":0,               - 0:Long focal camera 1:Wide-ang camera
    "code":0                 - Error code
}

1. Long lens preview  http://192.168.88.1:8092/mainstream
2. Wide-angle preview http://192.168.88.1:8092/thirdstream
*/

/*
10006 - Take photo(s)
{
    "interface":10006,
    "camId":0,               - 0:Long focal camera 1:Wide-ang camera
    "mode":0                 - 0:Single shot 1:Continuous Capture
    "count":1                - Number of continuous shots
    "name":"filename"        - Filename
}
return
{
    "interface":10006,
    "camId":0,               - 0:Long focal camera 1:Wide-ang camera
    "code":0                 - Error code
}
*/

/*
10001 - Set exposure mode
{
    "interface":10001,
    "camId":0,               - 0:Long focal camera 1:Wide-ang camera
    "mode":0
}

10002 - Set exposure value
{
    "interface":10002,
    "camId":0,               - 0:Long focal camera 1:Wide-ang camera
    "value":0
}

*/

class D2Message {
    interface;
    camId;
    code;
    mode;
    name;
    interval;
    outTime;
    value;
    centerX;
    centerY;
}