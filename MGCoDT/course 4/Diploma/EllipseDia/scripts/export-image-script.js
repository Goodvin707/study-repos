document.getElementsByTagName('svg')[0].setAttribute('id', 'svg');
var svg = document.getElementById("svg");

let svgStr = `<svg xmlns="http://www.w3.org/2000/svg" width="${svg.getAttribute('width')}" height="${svg.getAttribute('height')}" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" style="background-color: rgb(255, 255, 255);">`;
svgStr += svg.innerHTML;
svgStr += '</svg>';

function downloadSVG() {
    const downLink = document.createElement('a');
    downLink.download = document.title.slice(document.title.indexOf('- ') + 2) + '.svg';
    const blob = new Blob([svgStr]);
    downLink.href = URL.createObjectURL(blob);
    document.body.appendChild(downLink);
    downLink.click();
    document.body.removeChild(downLink);
}

window.onload = function () {
    let svgDoc = document.getElementById("svgDoc");
    svgDoc.setAttribute("style", "width:" + document.getElementsByTagName("svg")[0].getAttribute('width'));

    html2canvas(document.getElementById("svgDoc")).then(function (canvas) {
        var my_screen = canvas;
        document.getElementById("resultPNG").appendChild(my_screen);

        svgDoc.removeChild(document.getElementsByTagName('svg')[0]);
    });
}