function copyColorCode(colorCodeType) {
  let txt = document.getElementById('colorCode');
  let colorCode = (txt.innerText);
  switch (colorCodeType) {
    case 'rgb':
      colorCode = colorCode.slice(colorCode.indexOf("rgb"), colorCode.indexOf("hsl"));
      break;
    case 'hsl':
      colorCode = colorCode.slice(colorCode.indexOf("hsl"), colorCode.indexOf("#"));
      break;
    case 'hex':
      colorCode = colorCode.slice(colorCode.indexOf("#"), colorCode.length);
      break;
  }

  if (colorCode != '') {
    navigator.clipboard.writeText(colorCode)
      .then(() => {
        console.log('Копирование удалось: ' + colorCode);
      })
      .catch(err => {
        console.log('Копирование НЕ УДАЛОСЬ', err);
      })
  }
}

function colorPickerInit() {
  const container = document.querySelector('.color-picker');
  const canvas = document.createElement('canvas');
  const circle = document.createElement('div');
  const txt = document.createElement('div');

  if (container.childElementCount == 0) {
    container.appendChild(canvas);
    container.appendChild(circle);
    container.appendChild(txt);
  }

  container.style.position = 'relative';
  txt.id = 'colorCode';
  txt.style.cssText = `font-size: 0.9em; text-align: center;`;
  circle.style.cssText = `border: 2px solid; border-radius: 50%; width: 12px; height: 12px; position: absolute; top:0; left: 0; pointer-events: none; box-sizing: border-box;`;

  txt.innerHTML = '&nbsp;';
  const [width, height] = [container.offsetWidth, container.offsetHeight];
  [canvas.width, canvas.height] = [width, height];

  drawColors(canvas);
  canvas.addEventListener('mousemove', (e) => pickColor(e, canvas, circle, txt));
}

function detectLeftButtonPress(evt) {
  evt = evt || window.event;
  if ("buttons" in evt) {
    return evt.buttons == 1;
  }
  var button = evt.which || evt.button;
  return button == 1;
}

function pickColor(event, canvas, circle, txt) {
  if (detectLeftButtonPress(event)) {
    const rect = event.target.getBoundingClientRect();
    const x = event.clientX - rect.left; //x position within the element.
    const y = event.clientY - rect.top; //y position within the element.

    const context = canvas.getContext('2d');
    const imgData = context.getImageData(x, y, 1, 1);
    const [r, g, b] = imgData.data;
    const [h, s, l] = rgb2hsl(r, g, b);
    const txtColor = l < 0.5 ? '#FFF' : '#000';
    circle.style.top = y - 6 + 'px';
    circle.style.left = x - 6 + 'px';
    circle.style.borderColor = txtColor;

    txt.innerText = Object.values(toCss(r, g, b, h, s, l))
      .toString()
      .replace(/\)\,/g, ') ');
    txt.style.backgroundColor = toCss(r, g, b, h, s, l).hex;
    txt.style.color = txtColor;
    canvas.dispatchEvent(
      new CustomEvent('color-selected', {
        bubbles: true,
        detail: { r, g, b, h, s, l },
      })
    );
  }
}

function drawColors(canvas) {
  const context = canvas.getContext('2d');
  const { width, height } = canvas;

  //Colors - horizontal gradient
  const gradientH = context.createLinearGradient(0, 0, width, 0);
  gradientH.addColorStop(0, 'rgb(255, 0, 0)'); // red
  gradientH.addColorStop(1 / 6, 'rgb(255, 255, 0)'); // yellow
  gradientH.addColorStop(2 / 6, 'rgb(0, 255, 0)'); // green
  gradientH.addColorStop(3 / 6, 'rgb(0, 255, 255)');
  gradientH.addColorStop(4 / 6, 'rgb(0, 0, 255)'); // blue
  gradientH.addColorStop(5 / 6, 'rgb(255, 0, 255)');
  gradientH.addColorStop(1, 'rgb(255, 0, 0)'); // red
  context.fillStyle = gradientH;
  context.fillRect(0, 0, width, height);

  //Shades - vertical gradient
  const gradientV = context.createLinearGradient(0, 0, 0, height);
  gradientV.addColorStop(0, 'rgba(255, 255, 255, 1)');
  gradientV.addColorStop(0.5, 'rgba(255, 255, 255, 0)');
  gradientV.addColorStop(0.5, 'rgba(0, 0, 0, 0)');
  gradientV.addColorStop(1, 'rgba(0, 0, 0, 1)');
  context.fillStyle = gradientV;
  context.fillRect(0, 0, width, height);
}

function rgb2hsl(r, g, b) {
  (r /= 255), (g /= 255), (b /= 255);
  var max = Math.max(r, g, b),
    min = Math.min(r, g, b);
  var h,
    s,
    l = (max + min) / 2;

  if (max == min) {
    h = s = 0; // achromatic
  } else {
    var d = max - min;
    s = l > 0.5 ? d / (2 - max - min) : d / (max + min);

    switch (max) {
      case r:
        h = (g - b) / d + (g < b ? 6 : 0);
        break;
      case g:
        h = (b - r) / d + 2;
        break;
      case b:
        h = (r - g) / d + 4;
        break;
    }
    h /= 6;
  }

  return [h, s, l];
}

function toCss(r, g, b, h, s, l) {
  const int2hex = (num) =>
    (Math.round(num) < 16 ? '0' : '') + Math.round(num).toString(16);

  return {
    rgb: `rgb(${Math.round(r)},${Math.round(g)},${Math.round(b)})`,
    hsl: `hsl(${Math.round(360 * h)},${Math.round(100 * s)}%,${Math.round(
      100 * l
    )}%)`,
    hex: `#${int2hex(r)}${int2hex(g)}${int2hex(b)}`,
  };
}
